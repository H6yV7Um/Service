using Bright.Data;
using Maticsoft.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test_Doctor2 : System.Web.UI.Page
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
            string strSQL2 = "select * from Hrms where UserId='"+hrmID+"'";
            db.DBObj.GetRs(strSQL2, out Rs2);
            if (Rs2.RowCount > 0)
            {
                Label5.Text = Rs2[0, "number"].ToString();
                Label6.Text = Rs2[0, "WorkDate"].ToString();
            }
            ResultDataSet Rs3 = new ResultDataSet();
            string strSQL3 = "select * from Doctor_First where UserId='" + hrmID + "'";
            db.DBObj.GetRs(strSQL3, out Rs3);
            if (Rs3.RowCount > 0)
            {
                string[] _tb1 = Rs3[0, "tb1"].ToString().Split('&');
                TB1.Text = _tb1[0];
                getValue(RB1, _tb1[1]);

                string[] _tb2 = Rs3[0, "tb2"].ToString().Split('&');
                TB21.Text = _tb2[0]; TB22.Text = _tb2[1];
                getValue(RB2, _tb2[2]);

                string[] _tb3 = Rs3[0, "tb3"].ToString().Split('&');
                TB31.Text = _tb3[0]; TB32.Text = _tb3[1]; TB33.Text = _tb3[2];
                getValue(RB3, _tb3[3]);

                string[] _tb4 = Rs3[0, "tb4"].ToString().Split('&');
                TB41.Text = _tb4[0]; TB42.Text = _tb4[1]; 
                getValue(RB4, _tb4[2]);

                string[] _tb5 = Rs3[0, "tb5"].ToString().Split('&');
                TB51.Text = _tb5[0]; TB52.Text = _tb5[1]; TB53.Text = _tb5[2];
                getValue(RB5, _tb5[3]);

                string[] _tb6 = Rs3[0, "tb6"].ToString().Split('&');
                TB61.Text = _tb6[0]; TB62.Text = _tb6[1]; TB63.Text = _tb6[2];
                getValue(RB6, _tb6[3]);

                string[] _tb7 = Rs3[0, "tb7"].ToString().Split('&');
                TB71.Text = _tb7[0]; TB72.Text = _tb7[1]; TB73.Text = _tb7[2];
                getValue(RB7, _tb7[3]);

                string[] _tb8 = Rs3[0, "tb8"].ToString().Split('&');
                TB81.Text = _tb8[0]; TB82.Text = _tb8[1];
                getValue(RB8, _tb8[2]);

                string[] _rb1 = Rs3[0, "rb1"].ToString().Split('&');
                TB10.Text = _rb1[0];
                getValue(RB10, _rb1[1]);

                string[] _rb2 = Rs3[0, "rb2"].ToString().Split('&');
                TB11.Text = _rb2[0];
                getValue(RB11, _rb2[1]);

                string[] _rb3 = Rs3[0, "rb3"].ToString().Split('&');
                TB12.Text = _rb3[0];
                getValue(RB12, _rb3[1]);

                string[] _rb4 = Rs3[0, "rb4"].ToString().Split('&');
                TB13.Text = _rb4[0];
                getValue(RB13, _rb4[1]);

                string[] _rb5 = Rs3[0, "rb5"].ToString().Split('&');
                TB14.Text = _rb5[0];
                getValue(RB14, _rb5[1]);

                string[] _rb6 = Rs3[0, "rb6"].ToString().Split('&');
                TB15.Text = _rb6[0];
                getValue(RB15, _rb6[1]);

                string[] _rb7 = Rs3[0, "rb7"].ToString().Split('&');
                TB16.Text = _rb7[0];
                getValue(RB16, _rb7[1]);

                string[] _rb8= Rs3[0, "rb8"].ToString().Split('&');
                TB17.Text = _rb8[0];
                getValue(RB17, _rb8[1]);

                string[] _rb9 = Rs3[0, "rb9"].ToString().Split('&');
                TB18.Text = _rb9[0];
                getValue(RB18, _rb9[1]);

                string[] _rb10 = Rs3[0, "rb10"].ToString().Split('&');
                TB19.Text = _rb10[0];
                getValue(RB19, _rb10[1]);

                string[] _pass1 = Rs3[0, "pass1"].ToString().Split('&');
                TB20.Text = _pass1[0]; TB30.Text = _pass1[1];
                getValue(RB20, _pass1[2]);

                string[] _pass2 = Rs3[0, "pass2"].ToString().Split('&');
                TBS1.Text = _pass2[0]; TBS2.Text = _pass2[1];
                getValue(RB30, _pass2[2]);

                string[] _pass3 = Rs3[0, "pass3"].ToString().Split('&');
                TBS3.Text = _pass3[0]; TBS4.Text = _pass3[1];
                getValue(RB40, _tb2[2]);

                string _rb11 = Rs3[0, "rb11"].ToString();
                getValue(RB50, _rb11);

                mark.Text = Rs3[0, "mark"].ToString();
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        string _s1 = getRadioButtonValue(RB1,TB1);
        string _s2 = getRadioButtonValue(RB2, TB21,TB22);
        string _s3 = getRadioButtonValue(RB3, TB31,TB32,TB33);
        string _s4 = getRadioButtonValue(RB4, TB41,TB42);
        string _s5 = getRadioButtonValue(RB5, TB51, TB52, TB53);
        string _s6 = getRadioButtonValue(RB6, TB61, TB62, TB63);
        string _s7 = getRadioButtonValue(RB7, TB71, TB72, TB73);

        string _s8 = getRadioButtonValue(RB8, TB81, TB82);

        string _s10 = getRadioButtonValue(RB10, TB10);
        string _s11 = getRadioButtonValue(RB11, TB11);
        string _s12 = getRadioButtonValue(RB12, TB12);
        string _s13 = getRadioButtonValue(RB13, TB13);
        string _s14 = getRadioButtonValue(RB14, TB14);
        string _s15 = getRadioButtonValue(RB15, TB15);
        string _s16 = getRadioButtonValue(RB16, TB16);
        string _s17 = getRadioButtonValue(RB17, TB17);
        string _s18 = getRadioButtonValue(RB18, TB18);
        string _s19 = getRadioButtonValue(RB19, TB19);

        string _s20 = getRadioButtonValue(RB20, TB20, TB30);
        string _s30 = getRadioButtonValue(RB30, TBS1, TBS2);
        string _s40 = getRadioButtonValue(RB40, TBS3, TBS4);
        string _s50 = getRadioButtonValue(RB50);
        string _mark = mark.Text.ToString();

        string _add_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        ResultDataSet Rs3 = new ResultDataSet();
        string strSQL3 = "select * from Doctor_First where UserId='" + hrmID + "'";
        db.DBObj.GetRs(strSQL3, out Rs3);
        if (Rs3.RowCount > 0)
        {
            string sql2 = "UPDATE [dbo].[Doctor_First]"
                    + " SET [UserId] = '" + hrmID + "'"
                    + " ,[add_time] = '" + _add_time + "'"
                    + " ,[tb1] = '" + _s1 + "'"
                    + " ,[tb2] = '" + _s2 + "'"
                    + " ,[tb3] = '" + _s3 + "'"
                    + " ,[tb4] = '" + _s4 + "'"
                    + " ,[tb5] = '" + _s5 + "'"
                    + " ,[tb6] = '" + _s6 + "'"
                    + " ,[tb7] = '" + _s7 + "'"
                    + " ,[tb8] = '" + _s8 + "'"
                    + " ,[rb1] = '" + _s10 + "'"
                    + " ,[rb2] = '" + _s11 + "'"
                    + " ,[rb3] = '" + _s12 + "'"
                    + " ,[rb4] = '" + _s13 + "'"
                    + " ,[rb5] = '" + _s14 + "'"
                    + " ,[rb6] = '" + _s15 + "'"
                    + " ,[rb7] = '" + _s16 + "'"
                    + " ,[rb8] = '" + _s17 + "'"
                    + " ,[rb9] = '" + _s18 + "'"
                    + " ,[rb10] = '" + _s19 + "'"
                    + " ,[pass1] = '" + _s20 + "'"
                    + " ,[pass2] = '" + _s30 + "'"
                    + " ,[pass3] = '" + _s40 + "'"
                    + " ,[rb11] = '" + _s50 + "'"
                    + " ,[mark] = '" + _mark + "'"
                    + " WHERE [UserId]='" + hrmID + "'";
            if (db.DBObj.Exec(sql2))
            {
                Response.Write("<script>javascript:alert( '修改成功');window.location='Doctor2.aspx?hrmID=" + hrmID + "'</script>");
            }
        }
        else
        {
            string sql = "INSERT INTO [dbo].[Doctor_First] ([UserId],[add_time],[tb1],[tb2],[tb3],[tb4],[tb5],[tb6],[tb7],[tb8],[rb1],[rb2],[rb3],[rb4],[rb5],[rb6],[rb7],[rb8],[rb9],[rb10],[pass1],[pass2],[pass3],[rb11],[mark])"
                  + " VALUES ('" + hrmID + "','" + _add_time + "','" + _s1 + "','" + _s2 + "','" + _s3 + "','" + _s4 + "','" + _s5 + "','" + _s6 + "','" + _s7 + "','" + _s8 + "'"
                  + " ,'" + _s10 + "','" + _s11 + "','" + _s12 + "','" + _s13 + "','" + _s14 + "','" + _s15 + "','" + _s16 + "','" + _s17 + "','" + _s18 + "','" + _s19 + "'"
                  + " ,'" + _s20 + "','" + _s30 + "','" + _s40 + "','" + _s50 + "','" + _mark + "')";
            if (db.DBObj.Exec(sql))
            {
                Response.Write("<script>javascript:alert( '保存成功');window.location='Doctor2.aspx?hrmID=" + hrmID + "'</script>");
            }
        }
           
        
        

    }
    private string getRadioButtonValue(RadioButtonList rb)
    {
        string s = "";
        for (int i = 0; i < rb.Items.Count; i++)
        {
            if (rb.Items[i].Selected)
            {
                s = rb.Items[i].Value;
            }
        }
        return s;
    }
    private string getRadioButtonValue(RadioButtonList rb,TextBox tb)
    {
        string s = "";
        string v = tb.Text.ToString();
        for (int i = 0; i < rb.Items.Count; i++)
        {
            if (rb.Items[i].Selected)
            {
                s = rb.Items[i].Value;
            }
        }
        return v+"&"+s;
    }
    private string getRadioButtonValue(RadioButtonList rb, TextBox tb,TextBox tb2)
    {
        string s = "";
        string v = tb.Text.ToString();
        string v2 = tb2.Text.ToString();
        for (int i = 0; i < rb.Items.Count; i++)
        {
            if (rb.Items[i].Selected)
            {
                s = rb.Items[i].Value;
            }
        }
        return v + "&" +v2+ "&" + s;
    }
    private string getRadioButtonValue(RadioButtonList rb, TextBox tb, TextBox tb2,TextBox tb3)
    {
        string s = "";
        string v = tb.Text.ToString();
        string v2 = tb2.Text.ToString();
        string v3 = tb3.Text.ToString();
        for (int i = 0; i < rb.Items.Count; i++)
        {
            if (rb.Items[i].Selected)
            {
                s = rb.Items[i].Value;
            }
        }
        return v + "&" + v2 + "&"+v3+ "&" + s;
    }
}