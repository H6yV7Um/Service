using Bright.Data;
using Maticsoft.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test_Doctor3 : System.Web.UI.Page
{
    database_inte db = new database_inte();
    string hrmID;
    protected void Page_Load(object sender, EventArgs e)
    {
        hrmID = Request.QueryString["hrmID"];
        if (!IsPostBack)
        {
            ResultDataSet Rs = new ResultDataSet();
            string strSQL = "select * from Hrms_Department where hrmID=" + int.Parse(hrmID) + "";
            db.DBObj.GetRs(strSQL, out Rs);
            if (Rs.RowCount > 0)
            {
                Label1.Text = Rs[0, "departname"].ToString();
                Label2.Text = Rs[0, "name"].ToString();
                Label3.Text = Rs[0, "workyear"].ToString();
                Label4.Text = Rs[0, "techlevel"].ToString();
            }
            ResultDataSet Rs2 = new ResultDataSet();
            string strSQL2 = "select *,specialItem1 from Hrms inner join Doctor_Item on Hrms.UserId=Doctor_Item.UserId where Hrms.UserId='"+hrmID+"'";
            db.DBObj.GetRs(strSQL2, out Rs2);
            string name = "";
            if (Rs2.RowCount > 0)
            {
                Label5.Text = Rs2[0, "number"].ToString();
                Label6.Text = Rs2[0, "WorkDate"].ToString();
                name= Rs2[0, "specialItem1"].ToString().Split('&')[0];
            }

            ResultDataSet Rs3 = new ResultDataSet();
            string strSQL3 = "select * from Doctor_Special where UserId='" + hrmID + "'";
            db.DBObj.GetRs(strSQL3, out Rs3);
            if (Rs3.RowCount > 0)
            {
                CheckBox1.Checked = Rs3[0, "cb"].ToString() == "1" ? true : false;
                TB1.Text = String.IsNullOrEmpty(Rs3[0, "name"].ToString())?name: Rs3[0, "name"].ToString();

                string[] _rb1= Rs3[0, "rb1"].ToString().Split('&');
                getValue(RB1,_rb1[0]);
                getValue(RB2, _rb1[1]);

                string[] _rb2 = Rs3[0, "rb2"].ToString().Split('&');
                TB2.Text = _rb2[0];
                getValue(RB3, _rb2[1]);
                string[] _rb3= Rs3[0, "rb3"].ToString().Split('&');
                TB3.Text = _rb3[0];
                getValue(RB4, _rb3[1]);
                getValue(RadioButtonList5, Rs3[0, "rb4"].ToString());

                string[] _rb5 = Rs3[0, "rb5"].ToString().Split('&');
                TB4.Text = _rb5[0];
                TB5.Text = _rb5[1];
                getValue(RB5, _rb5[2]);

                string[] _rb6 = Rs3[0, "rb6"].ToString().Split('&');
                TB6.Text = _rb6[0];
                TB7.Text = _rb6[1];
                getValue(RB6, _rb6[2]);

                string[] _tb18 = Rs3[0, "tb18"].ToString().Split('&');
                TB18.Text = _tb18[0];
                getValue(RB18, _tb18[1]);
                string[] _tb19 = Rs3[0, "tb19"].ToString().Split('&');
                TB19.Text = _tb19[0];
                getValue(RB19, _tb19[1]);
                string[] _tb20 = Rs3[0, "tb20"].ToString().Split('&');
                TB20.Text = _tb20[0];
                getValue(RB20, _tb20[1]);
                string[] _tb21 = Rs3[0, "tb21"].ToString().Split('&');
                TB21.Text = _tb21[0];
                getValue(RB21, _tb21[1]);
                string[] _tb22 = Rs3[0, "tb22"].ToString().Split('&');
                TB22.Text = _tb22[0];
                getValue(RB22, _tb22[1]);
                string[] _tb23 = Rs3[0, "tb23"].ToString().Split('&');
                TB23.Text = _tb23[0];
                getValue(RB23, _tb23[1]);

                getValue(RB24, Rs3[0, "tb24"].ToString());
                mark.Text = Rs3[0, "mark"].ToString();
            }
        }
     }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string _cb = CheckBox1.Checked ? "1" : "0";
        string _name = TB1.Text.ToString();
        string _rb1 = setValue(RB1)+"&"+ setValue(RB2);
        string _rb2 = TB2.Text.ToString()+"&"+setValue(RB3);
        string _rb3 = TB3.Text.ToString() + "&" + setValue(RB4);
        string _rb4 = setValue(RadioButtonList5);
        string _rb5 = TB4.Text.ToString() + "&" + TB5.Text.ToString() + "&" + setValue(RB5);
        string _rb6 = TB6.Text.ToString() + "&" + TB7.Text.ToString() + "&" + setValue(RB6);

        string _tb18 = TB18.Text.ToString() + "&" + setValue(RB18);
        string _tb19 = TB19.Text.ToString() + "&" + setValue(RB19);
        string _tb20 = TB20.Text.ToString() + "&" + setValue(RB20);
        string _tb21 = TB21.Text.ToString() + "&" + setValue(RB21);
        string _tb22 = TB22.Text.ToString() + "&" + setValue(RB22);
        string _tb23 = TB23.Text.ToString() + "&" + setValue(RB23);

        string _tb24 = setValue(RB24);
        string _mark = mark.Text.ToString();
        string _add_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        ResultDataSet Rs3 = new ResultDataSet();
        string strSQL3 = "select * from Doctor_Special where UserId='" + hrmID + "'";
        db.DBObj.GetRs(strSQL3, out Rs3);
        if (Rs3.RowCount > 0)
        {
            string sql2 = "UPDATE [dbo].[Doctor_Special]"
                        + " SET [UserId] ='" + hrmID + "'"
                        + " ,[add_time] = '" + _add_time + "'"
                        + " ,[cb] = '" + _cb + "'"
                        + " ,[name] ='" + _name + "'"
                        + " ,[rb1] = '" + _rb1 + "'"
                        + " ,[rb2] ='" + _rb2 + "'"
                        + " ,[rb3] = '" + _rb3 + "'"
                        + " ,[rb4] = '" + _rb4 + "'"
                        + " ,[rb5] = '" + _rb5 + "'"
                        + " ,[rb6] = '" + _rb6 + "'"
                        + " ,[tb18] = '" + _tb18 + "'"
                        + " ,[tb19] = '" + _tb19 + "'"
                        + " ,[tb20] ='" + _tb20 + "'"
                        + " ,[tb21] = '" + _tb21 + "'"
                        + " ,[tb22] = '" + _tb22 + "'"
                        + " ,[tb23] = '" + _tb23 + "'"
                        + " ,[tb24] = '" + _tb24 + "'"
                        + " ,[mark] = '" + _mark + "'"
                        + " WHERE UserId='" + hrmID + "'";
            if (db.DBObj.Exec(sql2))
            {
                Response.Write("<script>javascript:alert( '修改成功');window.location='Doctor3.aspx?hrmID=" + hrmID + "'</script>");
            }
        }
        else
        {
            string sql = "INSERT INTO [dbo].[Doctor_Special] ([UserId],[add_time],[cb],[name],[rb1],[rb2],[rb3],[rb4],[rb5],[rb6],[tb18],[tb19],[tb20],[tb21],[tb22],[tb23],[tb24],[mark])"
           + " VALUES('" + hrmID + "','" + _add_time + "','" + _cb + "','" + _name + "'"
           + " ,'" + _rb1 + "','" + _rb2 + "','" + _rb3 + "','" + _rb4 + "','" + _rb5 + "','" + _rb6 + "'"
           + " ,'" + _tb18 + "','" + _tb19 + "','" + _tb20 + "','" + _tb21 + "','" + _tb22 + "','" + _tb23 + "','" + _tb24 + "','" + _mark + "')";
            if (db.DBObj.Exec(sql))
            {
                Response.Write("<script>javascript:alert( '保存成功');window.location='Doctor3.aspx?hrmID=" + hrmID + "'</script>");
            }
        }
           

    }
    private void getValue(RadioButtonList rb, string s)
    {
        for (int i = 0; i < rb.Items.Count; i++)
        {
            if (rb.Items[i].Value == s)
            {
                rb.Items[i].Selected = true;
            }

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