using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Bright.Data;
using Maticsoft.Common;
using DTcms.Common;
using System.Text;

/// <summary>
///BasePage 的摘要说明
/// </summary>
public class BasePage : System.Web.UI.Page
{
	public BasePage()
	{
        this.Load += new EventHandler(BasePage_Load);
	}
    private void BasePage_Load(object sender, EventArgs e)
    {
        //if (base.Session["user_name"] == null || base.Session["role_id"] == null || base.Session["group_id"] == null)
        //{
        //    //Response.Write("<script>parent.location.href='../Login.aspx'</script>");
        //    //Response.Write("<script>alert('页面超时，请重新登录！')</script>");
        //    Response.Write("<script>top.location.href='../login.aspx'</script>");
        //    Response.End();
        //}
        if (!IsAdminLogin())
        {
            Response.Write("<script>top.location.href='../login.aspx'</script>");
            Response.End();
        }
    }
    /// <summary>
    /// 判断管理员是否已经登录(解决Session超时问题)
    /// </summary>
    public bool IsAdminLogin()
    {
        if (base.Session["user_name"] != null || base.Session["role_id"] != null || base.Session["group_id"] != null)
        {
            return true;
        }
        else
        {
            //检查Cookies
            string adminname = Utils.GetCookie("DTRememberName");
            string adminpwd = Utils.GetCookie("password123");
            if (adminname != "" && adminpwd != "")
            {
                ResultDataSet Rs = new ResultDataSet();
                database_inte db = new database_inte();
                string strSQL = "select * from dt_manager where user_name='" + adminname + "' and password='" + adminpwd + "' and is_lock='0'";
                db.DB2Obj.GetRs(strSQL, out Rs);
                if (Rs.RowCount > 0)
                {
                    Session["user_name"] = Rs[0, "user_name"].ToString();
                    Session["role_id"] = Rs[0, "role_id"].ToString();
                    Session["group_id"] = Rs[0, "group_id"].ToString();
                    return true;
                }
                else
                {

                    ResultDataSet Rs2 = new ResultDataSet();
                    database_inte db2 = new database_inte();
                    string strSQL2 = "select UserName,UserId from Users where UserId='" + adminname + "' and Password ='" + adminpwd + "'";
                    db2.DBObj.GetRs(strSQL2, out Rs2);
                    if (Rs2.RowCount > 0)
                    {
                        string _OARole = ConfigurationManager.AppSettings["OARole"].ToString();
                        Session["user_name"] = Rs2[0, "UserId"].ToString();
                        Session["role_id"] = _OARole;
                        Session["group_id"] = Rs2[0, "UserId"].ToString();
                        return true;
                    }
                }
            }
        }
        return false;
    }
    protected override void OnInit(EventArgs e)
    {
        //if (base.Session["user_name"] == null || base.Session["role_id"] == null)
        //{
        //    Response.Redirect("~/Login.aspx");
        //}
    }
    public void ChkAdminLevel(string nav_name, string action_type)
    {
        string url = Request.RawUrl; 
        int role_id = Convert.ToInt32(Session["role_id"]);
        if (role_id > 1)
        {
            ResultDataSet Rs1 = new ResultDataSet();
            database_inte db1 = new database_inte();
            string strSQL1 = "select id from dt_manager_role_value where role_id='" + role_id + "' and nav_name='" + nav_name + "' and action_type='" + action_type + "'";
            db1.DB2Obj.GetRs(strSQL1, out Rs1);
            if (Rs1.RowCount < 1)
            {
                Response.Write("<script>alert('您没有管理该页面的权限，请勿非法进入！');window.location.href ='" + url + "'</script>");
                Response.End();
            }
        }
    }
    public string ChkGroup(string _sql)
    {
        int role_id = Convert.ToInt32(Session["role_id"]);
        //int group_id = Convert.ToInt32(Session["group_id"]);
        string _username=Session["user_name"].ToString();
        string group_id = Session["group_id"].ToString();
        if (role_id > 1)
        {
            //OA用户登录的情况
            if (_username == group_id)
            {
                _sql += " and (group_id like '" + group_id + "%' or username ='" + _username + "' or update_name ='" + _username + "' or deptID ='" + getOADeptID(_username) + "' or deptID ='" + getGroupIDByUserName(_username) + "') ";
                return _sql;
            }
            else
            {
                _sql += " and (group_id like '" + group_id + "%' or username ='" + _username + "' or update_name ='" + _username + "' or deptID ='" + getGroupIDByUserName(_username) + "') ";
                return _sql;
            }
            
            
        }
        return _sql;
    }
    public string getOrderSqlWhere(string managerWhere)
    {
        int role_id = Convert.ToInt32(Session["role_id"]);
        string _username = Session["user_name"].ToString();
        string group_id = Session["group_id"].ToString();
        string _sqlWhere = "";
        if (role_id > 1)
        {
            _sqlWhere = "state='0' and (group_id like '" + group_id + "%' or username ='" + _username + "' or update_name ='" + _username + "' or deptID ='" + getOADeptID(_username) + "' or deptID ='" + getGroupIDByUserName(_username) + "')";
        }
        else
        {
            _sqlWhere = managerWhere;
        }
        return _sqlWhere;
    }
    /// <summary>
    /// 获取客服系统人员姓名
    /// </summary>
    /// <param name="value">工号</param>
    /// <returns></returns>
    public string getUserName(string value)
    {
        string val = "";
        string sql = "select real_name from dt_manager where user_name='" + value + "'";
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();
        db.DB2Obj.GetRs(sql, out Rs);
        if (Rs.RowCount > 0)
        {
            val = Rs[0, "real_name"].ToString();
        }
        else
        {
            val = value;
        }
        return val;
    }
    public string getGroupIDByUserName(string value)
    {
        string val = "";
        string sql = "select group_id from dt_manager where user_name='" + value + "'";
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();
        db.DB2Obj.GetRs(sql, out Rs);
        if (Rs.RowCount > 0)
        {
            val = Rs[0, "group_id"].ToString();
        }
        else
        {
            val = value;
        }
        return val;
    }
    public string getManagerModel(string value,string column)
    {
        string val = "";
        string sql = "select * from dt_manager where user_name='" + value + "'";
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();
        db.DB2Obj.GetRs(sql, out Rs);
        if (Rs.RowCount > 0)
        {
            val = Rs[0, column].ToString();
        }
        else
        {
            val = value;
        }
        return val;
    }
    public string getOrderModel(string value, string column)
    {
        string val = "";
        string sql = "select * from dt_order where id='" + value + "'";
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();
        db.DB2Obj.GetRs(sql, out Rs);
        if (Rs.RowCount > 0)
        {
            val = Rs[0, column].ToString();
        }
        return val;
    }

    /// <summary>
    /// 获取当前问题类别对应的分组ID
    /// </summary>
    /// <param name="value">问题类别</param>
    /// <returns></returns>
    public string getGroupID(string value)
    {
        string val = "";
        //string sql = "select dt_type_list.typeID from dt_order inner join dt_type_list on dt_order.type=dt_type_list.id where type = '" + value + "'";
        string sql = "select typeID from dt_type_list where id = '" + value + "'";
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();
        db.DB2Obj.GetRs(sql, out Rs);
        if (Rs.RowCount > 0)
        {
            val = Rs[0, "typeID"].ToString();
        }
        else
        {
            val = value;
        }
        return val;
    }
    public string getGroupName(string value)
    {
        string val = "";
        //string sql = "select dt_type_list.typeID from dt_order inner join dt_type_list on dt_order.type=dt_type_list.id where type = '" + value + "'";
        string sql = "select typeName from dt_type_list where id = '" + value + "'";
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();
        db.DB2Obj.GetRs(sql, out Rs);
        if (Rs.RowCount > 0)
        {
            val = Rs[0, "typeName"].ToString();
        }
        else
        {
            val = value;
        }
        return val;
    }
    public string getOADeptID(string value)
    {
        string val = "";
        ResultDataSet Rs2 = new ResultDataSet();
        database_inte db2 = new database_inte();
        string strSQL2 = "select DeptId from Users where UserId='" + value + "' ";
        db2.DBObj.GetRs(strSQL2, out Rs2);
        if (Rs2.RowCount > 0)
        {
            val = Rs2[0, "DeptId"].ToString();
        }
        else
        {
            val = value;
        }
        return val;
    }
    /// <summary>
    /// 获取当前工单提交人和部门ID
    /// </summary>
    /// <param name="value">工单ID</param>
    /// <returns></returns>
    public string[] getOrderUserName(string value)
    {
        string[] Array =new string[2];
        string sql = "select username,deptID from dt_order where id= '" + value + "'";
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();
        db.DB2Obj.GetRs(sql, out Rs);
        if (Rs.RowCount > 0)
        {
            Array[0] = Rs[0, "username"].ToString();
            Array[1] = Rs[0, "deptID"].ToString();
        }
        else
        {
            Array[0] = "";
            Array[1] = "";
        }
        return Array;
    }
    /// <summary>
    /// 获取类型下拉菜单
    /// </summary>
    public void getDropdownlist(DropDownList dd,string sql,string title,string dataValue,string dataText)
    {

        string strSQL = sql;
        ResultDataSet Rs2 = new ResultDataSet();
        database_inte db2 = new database_inte();
        if (db2.DB2Obj.GetRs(strSQL, out Rs2))
        {
            DataTable dt = ((DataSet)Rs2).Tables[0];

            //this.ddlCategoryId.DataSource = dt;
            //this.ddlCategoryId.DataTextField = "typeName";
            //this.ddlCategoryId.DataValueField = "id";
            //this.ddlCategoryId.DataBind();
            //this.ddlCategoryId.Items.Add(new ListItem("全院", "0"));
            dd.Items.Clear();
            dd.Items.Add(new ListItem(title, ""));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr[dataValue].ToString();
                string Title = dr[dataText].ToString().Trim();
                dd.Items.Add(new ListItem(Title, Id));
            }

        }

    }
    /// <summary>
    /// 添加编辑删除提示
    /// </summary>
    /// <param name="msgtitle">提示文字</param>
    /// <param name="url">返回地址</param>
    /// <param name="msgcss">CSS样式</param>
    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
 
    public string getPriority(string value)
    {
        string val = "";
        switch (value)
        {
            case "0":
                val = "普通";
                break;
            case "1":
                val = "<span style=\"color:green\">重要</span>";
                break;
            case "2":
                val = "<span style=\"color:red\">紧急</span>";
                break;
        }
        return val;
    }
    public string getIDColor(string value)
    {
        string val = "";
        string sql = "select child_id from dt_order_child where child_id='" + value + "'";
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();
        db.DB2Obj.GetRs(sql, out Rs);
        if (Rs.RowCount > 0)
        {
            val = "<span style=\"color:#06FD44\">" + value + "</span>";
        }
        else
        {
            val = value;
        }
        return val;
    }
    public string getTitle(string value)
    {
        string val = "";
        string sql = "select * from dt_order_child where child_id='" + value + "'";
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();
        db.DB2Obj.GetRs(sql, out Rs);
        if (Rs.RowCount > 0)
        {
            val = "该工单已经指派给" + getUserName(Rs[0, "child_user_name"].ToString());
        }
        return val;
    }

    public string get_username(int value)
    {
        string val = "";
        string sql = "select username from dt_order where id='" + value + "'";
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();
        db.DB2Obj.GetRs(sql, out Rs);
        if (Rs.RowCount > 0)
        {
            val = Rs[0, "username"].ToString();
        }
        return val;
    }

    public string getAddTime(int value)
    {
        string val = "";
        string sql = "select add_time from dt_order where id='" + value + "'";
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();
        db.DB2Obj.GetRs(sql, out Rs);
        if (Rs.RowCount > 0)
        {
            val = Rs[0, "add_time"].ToString();
        }
        return val;
    }
    public string getState(string value)
    {
        string val = "";
        switch (value)
        {
            case "0":
                val = "待处理";
                break;
            case "1":
                val = "处理中";
                break;
            case "2":
                val = "已驳回";
                break;
            case "3":
                val = "已完成";
                break;
            case "4":
                val = "待确认";
                break;
        }
        return val;
    }
    public void ReportToExcel(System.Web.UI.Control ctl, string name)
    {
        Response.Clear();
        Response.Charset = "GB2312";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(name, System.Text.Encoding.UTF8).ToString());
        Response.ContentType = "application/ms-excel";
        this.EnableViewState = false;
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw); ctl.RenderControl(hw);
        string str = hw.InnerWriter.ToString();
        Response.Write("<html><head><meta http-equiv=Content-Type content=\"text/html; charset=gb2312\">");
        Response.Write(sw.ToString());
        Response.Write("</body></html>");
        Response.End();

    }
    /// <summary>
    /// 取得所有类别列表
    /// </summary>
    /// <param name="parent_id">父ID</param>
    /// <param name="channel_id">频道ID</param>
    /// <returns></returns>
    public DataTable GetList(int parent_id)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select * from dt_type_list where class_layer !=''");
        ResultDataSet Rs2 = new ResultDataSet();
        database_inte db2 = new database_inte();
        db2.DB2Obj.GetRs(strSql.ToString(), out Rs2);
        DataTable oldData = null;
        if (Rs2.RowCount > 0)
        {
            DataSet ds = ((DataSet)Rs2);
            oldData = ds.Tables[0] as DataTable;
            if (oldData == null)
            {
                return null;
            }

        }
        //复制结构
        DataTable newData = oldData.Clone();
        //调用迭代组合成DAGATABLE
        GetChilds(oldData, newData, parent_id);
        return newData;
    }
    public DataTable GetList2(int parent_id)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select * from FileType where class_layer !=''");
        ResultDataSet Rs2 = new ResultDataSet();
        database_inte db2 = new database_inte();
        db2.DB2Obj.GetRs(strSql.ToString(), out Rs2);
        DataTable oldData = null;
        if (Rs2.RowCount > 0)
        {
            DataSet ds = ((DataSet)Rs2);
            oldData = ds.Tables[0] as DataTable;
            if (oldData == null)
            {
                return null;
            }

        }
        //复制结构
        DataTable newData = oldData.Clone();
        //调用迭代组合成DAGATABLE
        GetChilds(oldData, newData, parent_id);
        return newData;
    }
    /// <summary>
    /// 从内存中取得所有下级类别列表（自身迭代）
    /// </summary>
    private void GetChilds(DataTable oldData, DataTable newData, int parent_id)
    {
        DataRow[] dr = oldData.Select("parentID='"+ parent_id.ToString()+ "'" );
        for (int i = 0; i < dr.Length; i++)
        {
            DataRow row = newData.NewRow();//创建新行
            //循环查找列数量赋值
            for (int j = 0; j < dr[i].Table.Columns.Count; j++)
            {
                row[dr[i].Table.Columns[j].ColumnName] = dr[i][dr[i].Table.Columns[j].ColumnName];
            }
            newData.Rows.Add(row);
            //调用自身迭代
            this.GetChilds(oldData, newData, int.Parse(dr[i]["id"].ToString()));
        }
    }
}