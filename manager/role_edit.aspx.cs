using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using Bright.Data;
using Maticsoft.Common;
using System.Data;

public partial class manager_role_edit : BasePage
{
    private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
    private int id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        string _action = DTRequest.GetQueryString("action");
        this.id = DTRequest.GetQueryInt("id");
        if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
        {
            this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
            if (this.id == 0)
            {
                JscriptMsg("传输参数不正确！", "back", "Error");
                return;
            }
            
        }
        if (!Page.IsPostBack)
        {
            //ChkAdminLevel("manager_role", DTEnums.ActionEnum.View.ToString()); //检查权限
            RoleTypeBind(); //绑定角色类型
            NavBind(); //绑定导航
            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                ShowInfo(this.id);
            }
        }
    }
    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();
        string strSQL = "select * from dt_manager_role where id='" + _id + "'";
        db.DB2Obj.GetRs(strSQL, out Rs);
        if (Rs.RowCount > 0)
        {
            txtRoleName.Text = Rs[0, "role_name"].ToString();
            ddlRoleType.SelectedValue = Rs[0, "role_type"].ToString();
        }
        //管理权限

        for (int i = 0; i < rptList.Items.Count; i++)
        {
            string navName = ((HiddenField)rptList.Items[i].FindControl("hidName")).Value;
            CheckBoxList cblActionType = (CheckBoxList)rptList.Items[i].FindControl("cblActionType");
            for (int n = 0; n < cblActionType.Items.Count; n++)
            {
                ResultDataSet Rs1 = new ResultDataSet();
                database_inte db1 = new database_inte();
                string strSQL1 = "select * from dt_manager_role_value where role_id='" + _id + "' and nav_name='" + navName + "' and action_type='" + cblActionType.Items[n].Value + "'";
                db1.DB2Obj.GetRs(strSQL1, out Rs1);
                if (Rs1.RowCount > 0)
                {
                    cblActionType.Items[n].Selected = true;
                }
                //Model.manager_role_value modelt = model.manager_role_values.Find(p => p.nav_name == navName && p.action_type == cblActionType.Items[n].Value);
                //if (modelt != null)
                //{
                //    cblActionType.Items[n].Selected = true;
                //}
            }
        }
        
    }
    #endregion

    #region 导航菜单=================================
    private void NavBind()
    {
        DataTable dt = GetList(0, DTEnums.NavigationEnum.System.ToString());
        this.rptList.DataSource = dt;
        this.rptList.DataBind();
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
        //复制结构
        DataTable newData = dt.Clone();
        //调用迭代组合成DAGATABLE
        GetChilds(dt, newData, parent_id);
        return newData;
    }
    #endregion
    /// <summary>
    /// 从内存中取得所有下级类别列表（自身迭代）
    /// </summary>
    private void GetChilds(DataTable oldData, DataTable newData, int parent_id)
    {
        DataRow[] dr = oldData.Select("parent_id=" + parent_id);
        for (int i = 0; i < dr.Length; i++)
        {
            //添加一行数据
            DataRow row = newData.NewRow();
            row["id"] = int.Parse(dr[i]["id"].ToString());
            row["nav_type"] = dr[i]["nav_type"].ToString();
            row["name"] = dr[i]["name"].ToString();
            row["title"] = dr[i]["title"].ToString();
            row["sub_title"] = dr[i]["sub_title"].ToString();
            row["link_url"] = dr[i]["link_url"].ToString();
            row["sort_id"] = int.Parse(dr[i]["sort_id"].ToString());
            row["is_lock"] = int.Parse(dr[i]["is_lock"].ToString());
            row["remark"] = dr[i]["remark"].ToString();
            row["parent_id"] = int.Parse(dr[i]["parent_id"].ToString());
            row["class_list"] = dr[i]["class_list"].ToString();
            row["class_layer"] = int.Parse(dr[i]["class_layer"].ToString());
            row["channel_id"] = int.Parse(dr[i]["channel_id"].ToString());
            row["action_type"] = dr[i]["action_type"].ToString();
            row["is_sys"] = int.Parse(dr[i]["is_sys"].ToString());
            newData.Rows.Add(row);
            //调用自身迭代
            this.GetChilds(oldData, newData, int.Parse(dr[i]["id"].ToString()));
        }
    }
    #region 角色类型=================================
    private void RoleTypeBind()
    {
        
        int id = Convert.ToInt32(Request.QueryString["id"]);
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();
        string strSQL = "select * from dt_manager_role where id='" + id + "'";
        db.DB2Obj.GetRs(strSQL, out Rs);
        if (Rs.RowCount > 0)
        {
            ddlRoleType.Items.Clear();
            ddlRoleType.Items.Add(new ListItem("请选择类型...", ""));
            if (Convert.ToInt32(Rs[0, "role_type"]) < 2)
            {
                ddlRoleType.Items.Add(new ListItem("超级用户", "1"));
            }
            ddlRoleType.Items.Add(new ListItem("系统用户", "2"));
            ddlRoleType.SelectedValue = Rs[0, "role_type"].ToString();
            txtRoleName.Text = Rs[0, "role_name"].ToString();
        }
        else
        {
            ddlRoleType.Items.Clear();
            ddlRoleType.Items.Add(new ListItem("请选择类型...", ""));
            if (Convert.ToInt32(Rs[0, "role_type"]) < 2)
            {
                ddlRoleType.Items.Add(new ListItem("超级用户", "1"));
            }
            ddlRoleType.Items.Add(new ListItem("系统用户", "2"));
        }
        
    }
    #endregion
    //美化列表
    protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            //美化导航树结构
            Literal LitFirst = (Literal)e.Item.FindControl("LitFirst");
            HiddenField hidLayer = (HiddenField)e.Item.FindControl("hidLayer");
            string LitStyle = "<span style=\"display:inline-block;width:{0}px;\"></span>{1}{2}";
            string LitImg1 = "<span class=\"folder-open\"></span>";
            string LitImg2 = "<span class=\"folder-line\"></span>";

            int classLayer = Convert.ToInt32(hidLayer.Value);
            if (classLayer == 1)
            {
                LitFirst.Text = LitImg1;
            }
            else
            {
                LitFirst.Text = string.Format(LitStyle, (classLayer - 2) * 24, LitImg2, LitImg1);
            }
            //绑定导航权限资源
            string[] actionTypeArr = ((HiddenField)e.Item.FindControl("hidActionType")).Value.Split(',');
            CheckBoxList cblActionType = (CheckBoxList)e.Item.FindControl("cblActionType");
            cblActionType.Items.Clear();
            for (int i = 0; i < actionTypeArr.Length; i++)
            {
                if (Utils.ActionType().ContainsKey(actionTypeArr[i]))
                {
                    cblActionType.Items.Add(new ListItem(" " + Utils.ActionType()[actionTypeArr[i]] + " ", actionTypeArr[i]));
                }
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
        {
            ChkAdminLevel("manager_role", DTEnums.ActionEnum.Edit.ToString()); //检查权限
            if (!DoEdit(this.id))
            {
                JscriptMsg("保存过程中发生错误！", "", "Error");
                Response.Redirect("role_list.aspx");
                return;
            }
            JscriptMsg("修改管理角色成功！", "role_list.aspx", "Success");
            Response.Redirect("role_list.aspx");
        }
        else //添加
        {
            ChkAdminLevel("manager_role", DTEnums.ActionEnum.Add.ToString()); //检查权限
            if (!DoAdd())
            {
                JscriptMsg("保存过程中发生错误！", "", "Error");
                return;
            }
            JscriptMsg("添加管理角色成功！", "role_list.aspx", "Success");
            Response.Redirect("role_list.aspx");
        }
        
    }
    #region 修改操作=================================
    private bool DoEdit(int _id)
    {
        bool result = false;
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();
        string strSQL = "select * from dt_manager_role where id='" + _id + "'";
        db.DB2Obj.GetRs(strSQL, out Rs);
        if (Rs.RowCount > 0)
        {
            txtRoleName.Text = Rs[0, "role_name"].ToString();
            ddlRoleType.SelectedValue = Rs[0, "role_type"].ToString();
        }

        string nav_name, action_type;
        ResultDataSet Rs3 = new ResultDataSet();
        database_inte db3 = new database_inte();
        string sql3 = "delete from dt_manager_role_value where role_id='"+_id+"'";
        db3.DB2Obj.Exec(sql3);
        for (int i = 0; i < rptList.Items.Count; i++)
        {
            string navName = ((HiddenField)rptList.Items[i].FindControl("hidName")).Value;
            CheckBoxList cblActionType = (CheckBoxList)rptList.Items[i].FindControl("cblActionType");
            for (int n = 0; n < cblActionType.Items.Count; n++)
            {
                if (cblActionType.Items[n].Selected == true)
                {
                    nav_name = navName;
                    action_type = cblActionType.Items[n].Value;
                    ResultDataSet Rs2 = new ResultDataSet();
                    database_inte db2 = new database_inte();
                    string sql2 = "insert into dt_manager_role_value (role_id,nav_name,action_type) values ('" + id + "','" + nav_name + "','" + action_type + "')";
                    if (db2.DB2Obj.Exec(sql2))
                    {
                        result = true;
                    }
                }
            }
        }
        return result;
    }
    #endregion

    #region 增加操作=================================
    private bool DoAdd()
    {
        bool result = false;
        int id = 0;

        string role_name = txtRoleName.Text.Trim();
        int role_type = int.Parse(ddlRoleType.SelectedValue);
        ResultDataSet Rs2 = new ResultDataSet();
        database_inte db2 = new database_inte();
        string sql2 = "insert into dt_manager_role (role_name,role_type,is_sys) values ('" + role_name + "','" + role_type + "','0')";
        db2.DB2Obj.Exec(sql2);
        string sql3 = "select top 1 * from dt_manager_role order by id desc";
        db2.DB2Obj.GetRs(sql3, out Rs2);
        if (Rs2.RowCount > 0)
        {
            id = Convert.ToInt32(Rs2[0, "id"]);
        }
        string nav_name, action_type;
        //管理权限
        for (int i = 0; i < rptList.Items.Count; i++)
        {
            string navName = ((HiddenField)rptList.Items[i].FindControl("hidName")).Value;
            CheckBoxList cblActionType = (CheckBoxList)rptList.Items[i].FindControl("cblActionType");
            for (int n = 0; n < cblActionType.Items.Count; n++)
            {
                if (cblActionType.Items[n].Selected == true)
                {
                    nav_name = navName;
                    action_type = cblActionType.Items[n].Value;
                    ResultDataSet Rs = new ResultDataSet();
                    database_inte db = new database_inte();
                    string sql = "insert into dt_manager_role_value (role_id,nav_name,action_type) values ('" + id + "','" + nav_name + "','" + action_type + "')";
                    if (db.DB2Obj.Exec(sql))
                    {
                        result = true;
                    }
                }
            }
        }
        return result;
    }
    #endregion
}