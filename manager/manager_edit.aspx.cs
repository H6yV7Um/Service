using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using Bright.Data;
using Maticsoft.Common;
using System.Data;

public partial class manager_manager_edit : BasePage
{
    string defaultpassword = "0|0|0|0"; //默认显示密码
    private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
    private int id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        string _action = DTRequest.GetQueryString("action");
        if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
        {
            this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
            if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
            {
                return;
            }
        }
        if (!Page.IsPostBack)
        {
            RoleBind();
            getGroup();
            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                ShowInfo(this.id);
            }
        }
    }
    private void ShowInfo(int _id)
    {
        
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();
        string strSQL = "select * from dt_manager where id='" + _id + "'";
        db.DB2Obj.GetRs(strSQL, out Rs);
        
        if (Rs.RowCount > 0)
        {
            ddlRoleId.SelectedValue = Rs[0, "role_id"].ToString();
            ddGroup.SelectedValue = Rs[0, "group_id"].ToString();
            txtUserName.Text = Rs[0, "user_name"].ToString();
            txtTelephone.Text = Rs[0, "telephone"].ToString();
            txtRealName.Text = Rs[0, "real_name"].ToString();
            if (Rs[0, "sms"].ToString() == "0")
            {
                smsIsLock.Checked = true;
            }
            else
            {
                smsIsLock.Checked = false;
            }
            if (Rs[0, "is_lock"].ToString() == "0")
            {
                cbIsLock.Checked = true;
            }
            else
            {
                cbIsLock.Checked = false;
            }

            if (!string.IsNullOrEmpty( Rs[0, "password"].ToString()))
            {
                txtPassword.Attributes["value"] = txtPassword1.Attributes["value"] = defaultpassword;
            }
        }
    }
    private bool DoEdit(int _id)
    {
        int role_id = int.Parse(ddlRoleId.SelectedValue);
        string group_id = ddGroup.SelectedValue;
        int role_type = RoleTypeBind(role_id);
        int is_lock = 0, sms_lock = 0;
        if (cbIsLock.Checked == true)
        {
            is_lock = 0;
        }
        else
        {
            is_lock = 1;
        }
        if (smsIsLock.Checked == true)
        {
            sms_lock = 0;
        }
        else
        {
            sms_lock = 1;
        }
        bool result = false;
        string username = txtUserName.Text.ToString();
        string password = txtPassword1.Text.ToString();
        string real_name = txtRealName.Text.ToString();
        string tel = txtTelephone.Text.ToString();
        //判断密码是否更改
        if (txtPassword.Text.Trim() != defaultpassword)
        {
            string jiamipassword = System.Encryption.MD5.MDString(password);
            ResultDataSet Rs2 = new ResultDataSet();
            database_inte db2 = new database_inte();
            string sql2 = "update dt_manager set role_id='" + role_id + "',role_type='" + role_type + "',real_name='" + real_name + "',password='" + jiamipassword + "',telephone='" + tel + "',sms='" + sms_lock + "',is_lock='" + is_lock + "',group_id='" + group_id + "' where id ='" + _id + "'";
            if (db2.DB2Obj.Exec(sql2))
            {
                result = true;
                return result;
            }
        }
        else
        {
            ResultDataSet Rs2 = new ResultDataSet();
            database_inte db2 = new database_inte();
            string sql2 = "update dt_manager set role_id='" + role_id + "',role_type='" + role_type + "',real_name='" + real_name + "',telephone='" + tel + "',sms='" + sms_lock + "',is_lock='" + is_lock + "',group_id='" + group_id + "' where id ='" + _id + "'";
            if (db2.DB2Obj.Exec(sql2))
            {
                result = true;
                return result;
            }
        }
        
        return result;
    }
    #region 角色类型=================================
    private void RoleBind()
    {
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();
        string strSQL = "select * from dt_manager_role ";
        db.DB2Obj.GetRs(strSQL, out Rs);
        DataTable dt = ((DataSet)Rs).Tables[0];
        if (Rs.RowCount > 0)
        {
            ddlRoleId.Items.Clear();
            ddlRoleId.Items.Add(new ListItem("请选择角色...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                ddlRoleId.Items.Add(new ListItem(dr["role_name"].ToString(), dr["id"].ToString()));
            }
        }
        
    }
    #endregion

    private void getGroup()
    {
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();
        string strSQL = "select * from dt_type_list ";
        db.DB2Obj.GetRs(strSQL, out Rs);
        DataTable dt = ((DataSet)Rs).Tables[0];
        if (Rs.RowCount > 0)
        {
            ddGroup.Items.Clear();
            ddGroup.Items.Add(new ListItem("请选择所属机构...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                //ddGroup.Items.Add(new ListItem(dr["name"].ToString(), dr["id"].ToString()));
                ddGroup.Items.Add(new ListItem(dr["typeName"].ToString(), dr["typeID"].ToString()));
            }
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
        {
            ChkAdminLevel("manager_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
            if (!DoEdit(this.id))
            {
                Response.Write("<script>alert('修改失败！')</script>");
                return;
            }
            Response.Redirect("manager_list.aspx");
        }
        else //添加
        {
            ChkAdminLevel("manager_list", DTEnums.ActionEnum.Add.ToString()); //检查权限
            if (!DoAdd())
            {
                Response.Write("<script>alert('添加失败！')</script>");
                return;
            }
            Response.Redirect("manager_list.aspx");
        }
        
    }
    private bool DoAdd()
    {
        bool result = false;
        int role_id = int.Parse(ddlRoleId.SelectedValue);
        string group_id = ddGroup.SelectedValue;
        int role_type = RoleTypeBind(role_id);
        int is_lock = 0, sms_lock = 0;
        if (cbIsLock.Checked == true)
        {
            is_lock = 0;
        }
        else
        {
            is_lock = 1;
        }
        if (smsIsLock.Checked == true)
        {
            sms_lock = 0;
        }
        else
        {
            sms_lock = 1;
        }
        string username = txtUserName.Text.ToString();
        string password = txtPassword1.Text.ToString();
        string jiamipassword = System.Encryption.MD5.MDString(password);
        string real_name = txtRealName.Text.ToString();
        string tel = txtTelephone.Text.ToString();
        DateTime dt = DateTime.Now;
        ResultDataSet Rs2 = new ResultDataSet();
        database_inte db2 = new database_inte();
        string sql2 = "insert into dt_manager (role_id,role_type,user_name,password,real_name,telephone,sms,is_lock,add_time,group_id) values ('" + role_id + "','" + role_type + "','" + username + "','" + jiamipassword + "','" + real_name + "','" + tel + "','" + sms_lock + "','" + is_lock + "','" + dt + "','" + group_id + "')";
        if (db2.DB2Obj.Exec(sql2))
        {
            result = true;
            return result;
        }
        return result;
    }
    private int RoleTypeBind(int id)
    {
        int roletype = 2;
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();
        string strSQL = "select * from dt_manager_role where id='" + id + "'";
        db.DB2Obj.GetRs(strSQL, out Rs);
        if (Rs.RowCount > 0)
        {
            roletype=Convert.ToInt32(Rs[0, "role_type"]);
        }
        return roletype;
    }
}