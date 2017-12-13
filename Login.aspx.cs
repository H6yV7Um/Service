using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bright.Data;
using Maticsoft.Common;
using DTcms.Common;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{
    database_inte db = new database_inte();
    string cookie_password = Utils.GetCookie("password123");
    string _openid = "";
    string _user = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Clear();
        _openid = Request.QueryString["openid"];
        if (!Page.IsPostBack)
        { 
            user.Text = Utils.GetCookie("DTRememberName");
            
            passwrod.Attributes.Add("value", cookie_password);
            if (cookie_password != "")
            {
                remember.Checked = true;
            }
        }
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        _user = user.Text.ToString();
        string _password = passwrod.Text.ToString();
        string jiamipassword = System.Encryption.MD5.MDString(_password);
        if (cookie_password != "" && _password == cookie_password)
        {
            jiamipassword = _password;
        }
        ResultDataSet Rs = new ResultDataSet();
        string strSQL = "select user_name,role_id,group_id from dt_manager where user_name='" + _user + "' and password='" + jiamipassword + "' and is_lock='0'";
        db.DB2Obj.GetRs(strSQL, out Rs);
        if (Rs.RowCount > 0)
        {
            Session["user_name"] = Rs[0, "user_name"].ToString();
            Session["role_id"] = Rs[0, "role_id"].ToString();
            Session["group_id"] = Rs[0, "group_id"].ToString();
            if (Request.Form["remember"] != null)
            {
                Utils.WriteCookie("password123", jiamipassword, 720);
            }
            else
            {
                Utils.WriteCookie("password123", jiamipassword, -1);
            }
            //写入Cookies
            Utils.WriteCookie("DTRememberName", _user, 14400);
            //更新微信数据库
            updateWeChatUsers();

            Response.Redirect("InfoAdd.aspx");
        }
        else
        {
            
            ResultDataSet Rs2 = new ResultDataSet();
            string strSQL2 = "select UserName,UserId from Users where UserId='" + _user + "' and Password ='" + jiamipassword + "'";
            db.DBObj.GetRs(strSQL2, out Rs2);
            if (Rs2.RowCount > 0)
            {
                string _OARole = ConfigurationManager.AppSettings["OARole"].ToString();
                Session["user_name"] = Rs2[0, "UserId"].ToString();
                Session["role_id"] = _OARole;
                Session["group_id"] = Rs2[0,"UserId"].ToString();
                if (Request.Form["remember"] != null)
                {
                    Utils.WriteCookie("password123", jiamipassword, 720);
                }
                else
                {
                    Utils.WriteCookie("password123", jiamipassword, -1);
                }
                //写入Cookies
                Utils.WriteCookie("DTRememberName", _user, 14400);

                updateWeChatUsers();
                Response.Redirect("InfoAdd.aspx");
            }
            else
            {
                Response.Write("<script>alert('用户名或密码错误！')</script>");
            }
        }
        
    }

    public void updateWeChatUsers()
    {
        if (!String.IsNullOrEmpty(_openid))
        {
            ResultDataSet Rs2 = new ResultDataSet();
            string sql = "select CardID from WeChatUsers where Openid='" + _openid + "'";
            try
            {
                db.DB3Obj.GetRs(sql, out Rs2);
                if (Rs2.RowCount > 0 && String.IsNullOrEmpty(Rs2[0, "CardID"].ToString()))
                {
                    string sql2 = "update WeChatUsers set CardID='" + _user + "', RoleType='0' where Openid='" + _openid + "'";
                    db.DB3Obj.Exec(sql2);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
       
    }
}