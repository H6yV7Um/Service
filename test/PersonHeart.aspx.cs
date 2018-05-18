using Maticsoft.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test_PersonHeart : System.Web.UI.Page
{
    database_inte db = new database_inte();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string rb1 = setValue(RadioButtonList1);
        string rb2 = setValue(RadioButtonList2);
        string rb3 = setValue(RadioButtonList3);
        string rb4 = setValue(RadioButtonList4);
        string rb5 = setValue(RadioButtonList5);
        string rb6 = setValue(RadioButtonList6);
        string rb7 = setValue(RadioButtonList7);

        string rb8 = setValue(RadioButtonList8);
        string rb9 = setValue(RadioButtonList9);
        string rb10 = setValue(RadioButtonList10);
        string rb11 = setValue(RadioButtonList11);
        string rb12 = setValue(RadioButtonList12);
        string rb13 = setValue(RadioButtonList13);
        string rb14 = setValue(RadioButtonList14);
        string rb15 = setValue(RadioButtonList15);
        string rb16 = setValue(RadioButtonList16);
        if (rb1 == "" || rb2 == "" || rb3 == "" || rb4 == "" || rb5 == "" || rb6 == "" || rb7 == "" || rb8 == ""
            || rb9 == "" || rb10 == "" || rb11 == "" || rb12 == "" || rb13 == "" || rb14 == "" || rb15 == "" || rb16 == "")
        {
            Response.Write("<script>javascript:alert( '对不起，有选项没有勾选，不能保存');window.location='PersonHeart.aspx'</script>");
            Response.End();
        }
        else
        {
            int _rb1 = Convert.ToInt32(rb1);
            int _rb2 = Convert.ToInt32(rb2);
            int _rb3 = Convert.ToInt32(rb3);
            int _rb4 = Convert.ToInt32(rb4);
            int _rb5 = Convert.ToInt32(rb5);
            int _rb6 = Convert.ToInt32(rb6);
            int _rb7 = Convert.ToInt32(rb7);
            string _add_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string userID = "1820";
            int total1 = _rb1 + _rb2 + _rb3 + _rb4 + _rb5 + _rb6 + _rb7;
            string sql = "INSERT INTO [dbo].[HeartTest] ([UserId],[add_time],[type],[score])VALUES('"+ userID + "','"+ _add_time + "','"+7+"',"+ total1 + ")";
            db.DBObj.Exec(sql);
            int _rb8 = Convert.ToInt32(rb8);
            int _rb9 = Convert.ToInt32(rb9);
            int _rb10 = Convert.ToInt32(rb10);
            int _rb11 = Convert.ToInt32(rb11);
            int _rb12 = Convert.ToInt32(rb12);
            int _rb13 = Convert.ToInt32(rb13);
            int _rb14 = Convert.ToInt32(rb14);
            int _rb15 = Convert.ToInt32(rb15);
            int _rb16 = Convert.ToInt32(rb16);

            int total2 = _rb8 + _rb9 + _rb10 + _rb11 + _rb12 + _rb13 + _rb14 + _rb15 + _rb16;
            string sql2 = "INSERT INTO [dbo].[HeartTest] ([UserId],[add_time],[type],[score])VALUES('" + userID + "','" + _add_time + "','" + 9 + "'," + total2 + ")";
            db.DBObj.Exec(sql2);
            Response.Write("<script>javascript:alert( '保存成功');window.location='PersonHeart.aspx'</script>");
        }
    }
    private string setValue(RadioButtonList rb)
    {
        string str = "";
        for (int i = 0; i < rb.Items.Count; i++)
        {
            if (rb.Items[i].Selected)
            {
                str = rb.Items[i].Value;
            }
        }
        return str;
    }
}