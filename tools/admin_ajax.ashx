<%@ WebHandler Language="C#" Class="admin_ajax" %>

using System;
using System.Web;
using DTcms.Common;
using Bright.Data;
using Maticsoft.Common;
using System.Data;
using DBWebService;

public class admin_ajax : IHttpHandler, System.Web.SessionState.IRequiresSessionState {
    SqlDB db = new SqlDB();
    public void ProcessRequest (HttpContext context) {
        //取得处事类型
        string action = DTRequest.GetQueryString("action");

        switch (action)
        {
            case "get_navigation_list": //获取后台导航字符串
                get_navigation_list(context);
                break;
            case "edit_order_status":
                edit_order_status(context);
                break;       
        }
    }
    private void edit_order_status(HttpContext context) 
    {
        string workflow = "", real_name = "", sql="";
        if (context.Session["user_name"] != null)
        {
            real_name = db.getRealName(context.Session["user_name"].ToString());
        }
        string order_no = DTRequest.GetFormString("order_no").Trim();
        string order_details = DTRequest.GetFormString("order_details").Trim();
        string order_ddlRoleId = DTRequest.GetFormString("order_ddlRoleId").Trim();
        string _add_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        workflow = real_name + "→" + db.getRealName(order_ddlRoleId) + "→" + order_details + "    " + _add_time;
        
        ResultDataSet Rs2 = new ResultDataSet();
        database_inte db2 = new database_inte();
        string strSQL = "select * from dt_order_child where child_id='" + order_no + "'";
        db2.DB2Obj.GetRs(strSQL, out Rs2);
        if (Rs2.RowCount > 0)
        {
            string workflows = Rs2[0, "child_details"].ToString() + "," + workflow;
            sql = "update dt_order_child set child_details='" + workflows + "',child_user_name='" + order_ddlRoleId + "' where child_id='" + order_no + "'";
        }
        else
        {
            sql = "insert into dt_order_child (child_id,child_details,child_user_name) values ('" + order_no + "','" + workflow + "','" + order_ddlRoleId + "')";
        }
        
        if (db2.DB2Obj.Exec(sql))
        {
            context.Response.Write("{\"status\": 1, \"msg\": \"提交成功！\"}");
        }
        else
        {
            context.Response.Write("{\"status\": 0, \"msg\": \"提交失败！\"}");
        }
    }
    #region 获取后台导航字符串==============================
    private void get_navigation_list(HttpContext context)
    {
        string user = context.Session["user_name"].ToString();
        string sql = "select * from dt_manager where user_name='" + user + "'";
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();
        db.DB2Obj.GetRs(sql, out Rs);
        int role_id =0;
        if (Rs.RowCount > 0)
        {
            role_id =Convert.ToInt32(Rs[0, "role_id"]);
            
        }
        else
        {
            string _OARole = System.Configuration.ConfigurationManager.AppSettings["OARole"].ToString();
            role_id = Convert.ToInt32(_OARole);
        }
        string sql2 = "select * from dt_manager_role where id='"+role_id+"'";
        db.DB2Obj.GetRs(sql2, out Rs);
        if (Rs.RowCount > 0)
        {
            DataTable dt = GetList(0, DTEnums.NavigationEnum.System.ToString());
            this.get_navigation_childs(context, dt, 0, "", Convert.ToInt32(Rs[0, "role_type"]), role_id);
        }
        else
        {
            return;
        }
        

    }
    public DataTable GetList(int parent_id, string nav_type)
    {
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();
        string sql = "select id,nav_type,name,title,sub_title,link_url,sort_id,is_lock,remark,parent_id,class_list,class_layer,channel_id,action_type,is_sys from dt_navigation where nav_type='" + nav_type + "' order by sort_id asc,id asc";
        db.DB2Obj.GetRs(sql, out Rs);
        DataTable dt = ((DataSet)Rs).Tables[0];
        if (dt == null)
        {
            return null;
        }
        return dt;
    }
    private void get_navigation_childs(HttpContext context, DataTable oldData, int parent_id, string parent_name, int role_type,int role_id)
    {
        DataRow[] dr = oldData.Select("parent_id=" + parent_id);
        bool isWrite = false;
        for (int i = 0; i < dr.Length; i++)
        {
            //检查是否显示在界面上====================
            bool isActionPass = true;
            if (int.Parse(dr[i]["is_lock"].ToString()) == 1)
            {
                isActionPass = false;
            }
            //检查管理员权限==========================
            if (isActionPass && role_type > 1)
            {
                string[] actionTypeArr = dr[i]["action_type"].ToString().Split(',');
                foreach (string action_type_str in actionTypeArr)
                {
                    //如果存在显示权限资源，则检查是否拥有该权限
                    if (action_type_str == "Show")
                    {
                        ResultDataSet Rs1 = new ResultDataSet();
                        database_inte db1 = new database_inte();
                        string strSQL1 = "select * from dt_manager_role_value where role_id='" + role_id + "' and nav_name='" + dr[i]["name"].ToString() + "' and action_type='Show'";
                        db1.DB2Obj.GetRs(strSQL1, out Rs1);
                        if (Rs1.RowCount < 1)
                        {
                            isActionPass = false;
                        }
                    }
                }
            }
            //如果没有该权限则不显示
            if (!isActionPass)
            {
                if (isWrite && i == (dr.Length - 1) && parent_id > 0 && parent_name != "sys_contents")
                {
                    context.Response.Write("</ul>\n");
                }
                continue;
            }
            //输出开始标记
            if (i == 0 && parent_id > 0 && parent_name != "sys_contents")
            {
                isWrite = true;
                context.Response.Write("<ul class=\"nav nav-pills nav-stacked\">\n");
            }
            //以下是输出选项内容=======================
            if (int.Parse(dr[i]["class_layer"].ToString()) == 1)
            {
                context.Response.Write("<li class=\"ajax-link\"><a href=\"" + dr[i]["link_url"].ToString() + "\" target=\"mainFrame\"><i class=\"glyphicon glyphicon-home\"></i><span> \n");
                if (dr[i]["name"].ToString() != "sys_contents")
                {
                    context.Response.Write("" + dr[i]["title"].ToString() + "</span></a>\n");
                }
                //调用自身迭代
                this.get_navigation_childs(context, oldData, int.Parse(dr[i]["id"].ToString()), dr[i]["name"].ToString(), role_type, role_id);
                context.Response.Write("</li>\n");
            }
            else if (int.Parse(dr[i]["class_layer"].ToString()) == 2 )
            {
                context.Response.Write("<li><a href=\"#\" target=\"mainFrame\">" + dr[i]["title"].ToString() + "</a></li>\n");
                //调用自身迭代
                this.get_navigation_childs(context, oldData, int.Parse(dr[i]["id"].ToString()), dr[i]["name"].ToString(), role_type, role_id);
            }
            else
            {
                context.Response.Write("<li class=\"accordion\">\n");
                context.Response.Write("<a href=\"#\"><i class=\"glyphicon glyphicon-plus\"></i><span>");
                //if (!string.IsNullOrEmpty(dr[i]["link_url"].ToString()))
                //{
                //    if (int.Parse(dr[i]["channel_id"].ToString()) > 0)
                //    {
                //        context.Response.Write(" href=\"" + dr[i]["link_url"].ToString() + "?channel_id=" + dr[i]["channel_id"].ToString() + "\" target=\"mainFrame\"");
                //    }
                //    else
                //    {
                //        context.Response.Write(" href=\"" + dr[i]["link_url"].ToString() + "\" target=\"mainFrame\"");
                //    }
                //}
                context.Response.Write("" + dr[i]["title"].ToString() + "</span>\n");
                context.Response.Write("</a>\n");
                //调用自身迭代
                this.get_navigation_childs(context, oldData, int.Parse(dr[i]["id"].ToString()), dr[i]["name"].ToString(), role_type, role_id);
                context.Response.Write("</li>\n");
            }
            //以上是输出选项内容=======================
            //输出结束标记
            if (i == (dr.Length - 1) && parent_id > 0 )
            {
                context.Response.Write("</ul>\n");
            }
        }
    }
    #endregion
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}