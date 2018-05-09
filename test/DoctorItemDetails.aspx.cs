using Bright.Data;
using Maticsoft.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test_DoctorItemDetails : System.Web.UI.Page
{
    database_inte db = new database_inte();
    string hrmID;
    protected void Page_Load(object sender, EventArgs e)
    {
        hrmID = Request.QueryString["hrmID"];
        if (!IsPostBack)
        {
            ResultDataSet Rs3 = new ResultDataSet();
            string strSQL3 = "select * from Doctor_Item where UserId='"+hrmID+"'";
            db.DBObj.GetRs(strSQL3, out Rs3);
            if (Rs3.RowCount > 0)
            {
                string[] normalItem1Array = Rs3[0, "normalItem1"].ToString().Split('&');
                if (String.IsNullOrEmpty(normalItem1Array[0]))
                {
                    Label1.Visible = false;
                    TextBox1.Visible = false;
                }
                else
                {
                    Label1.Text = normalItem1Array[0];
                    TextBox1.Text = getTextBoxContent(normalItem1Array[0]);
                }
                string[] normalItem2Array = Rs3[0, "normalItem2"].ToString().Split('&');
                if (String.IsNullOrEmpty(normalItem2Array[0]))
                {
                    Label2.Visible = false;
                    TextBox2.Visible = false;
                }
                else
                {
                    Label2.Text = normalItem2Array[0];
                    TextBox2.Text = getTextBoxContent(normalItem2Array[0]);
                }
                string[] normalItem3Array = Rs3[0, "normalItem3"].ToString().Split('&');
                if (String.IsNullOrEmpty(normalItem3Array[0]))
                {
                    Label3.Visible = false;
                    TextBox3.Visible = false;
                }
                else
                {
                    Label3.Text = normalItem3Array[0];
                    TextBox3.Text = getTextBoxContent(normalItem3Array[0]);
                }
                string[] normalItem4Array = Rs3[0, "normalItem4"].ToString().Split('&');
                if (String.IsNullOrEmpty(normalItem4Array[0]))
                {
                    Label4.Visible = false;
                    TextBox4.Visible = false;
                }
                else
                {
                    Label4.Text = normalItem4Array[0];
                    TextBox4.Text = getTextBoxContent(normalItem4Array[0]);
                }
                string[] normalItem5Array = Rs3[0, "normalItem5"].ToString().Split('&');
                if (String.IsNullOrEmpty(normalItem5Array[0]))
                {
                    Label5.Visible = false;
                    TextBox5.Visible = false;
                }
                else
                {
                    Label5.Text = normalItem5Array[0];
                    TextBox5.Text = getTextBoxContent(normalItem5Array[0]);
                }
                string[] normalItem6Array = Rs3[0, "normalItem6"].ToString().Split('&');
                if (String.IsNullOrEmpty(normalItem6Array[0]))
                {
                    Label6.Visible = false;
                    TextBox6.Visible = false;
                }
                else
                {
                    Label6.Text = normalItem6Array[0];
                    TextBox6.Text = getTextBoxContent(normalItem6Array[0]);
                }
                string[] normalItem7Array = Rs3[0, "normalItem7"].ToString().Split('&');
                if (String.IsNullOrEmpty(normalItem7Array[0]))
                {
                    Label7.Visible = false;
                    TextBox7.Visible = false;
                }
                else
                {
                    Label7.Text = normalItem7Array[0];
                    TextBox7.Text = getTextBoxContent(normalItem7Array[0]);
                }
                string[] normalItem8Array = Rs3[0, "normalItem8"].ToString().Split('&');
                if (String.IsNullOrEmpty(normalItem8Array[0]))
                {
                    Label8.Visible = false;
                    TextBox8.Visible = false;
                }
                else
                {
                    Label8.Text = normalItem8Array[0];
                    TextBox8.Text = getTextBoxContent(normalItem8Array[0]);
                }
                string[] normalItem9Array = Rs3[0, "normalItem9"].ToString().Split('&');
                if (String.IsNullOrEmpty(normalItem9Array[0]))
                {
                    Label9.Visible = false;
                    TextBox9.Visible = false;
                }
                else
                {
                    Label9.Text = normalItem9Array[0];
                    TextBox9.Text = getTextBoxContent(normalItem9Array[0]);
                }
                string[] normalItem10Array = Rs3[0, "normalItem10"].ToString().Split('&');
                if (String.IsNullOrEmpty(normalItem10Array[0]))
                {
                    Label10.Visible = false;
                    TextBox10.Visible = false;
                }
                else
                {
                    Label10.Text = normalItem10Array[0];
                    TextBox10.Text = getTextBoxContent(normalItem10Array[0]);
                }
            }
        }
    }

    private string getTextBoxContent(string s)
    {
        ResultDataSet Rs3 = new ResultDataSet();
        string strSQL3 = "select * from Doctor_Details where UserId='"+ hrmID + "' and normalItem='"+s+"'";
        db.DBObj.GetRs(strSQL3, out Rs3);
        if (Rs3.RowCount > 0)
        {
            return Rs3[0, "details"] + "";
        }
        return "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        fillTextBox(Label1,TextBox1);
        fillTextBox(Label2, TextBox2);
        fillTextBox(Label3, TextBox3);
        fillTextBox(Label4, TextBox4);
        fillTextBox(Label5, TextBox5);
        fillTextBox(Label6, TextBox6);
        fillTextBox(Label7, TextBox7);
        fillTextBox(Label8, TextBox8);
        fillTextBox(Label9, TextBox9);
        fillTextBox(Label10, TextBox10);
        Response.Write("<script>javascript:alert( '保存成功！');window.location='Doctor1.aspx?hrmID=" + hrmID + "'</script>");
    }
    private void fillTextBox(Label lb,TextBox tb)
    {
        string lb1 = lb.Text.ToString();
        string tb1 = tb.Text.ToString();
        string sql1 = "INSERT INTO [dbo].[Doctor_Details] ([UserID],[normalItem],[details])VALUES('" + hrmID + "','" + lb1 + "','" + tb1 + "')";
        ResultDataSet Rs1 = new ResultDataSet();
        string strSQL1 = "select * from Doctor_Details where UserId='"+ hrmID + "' and normalItem='" + lb1 + "'";
        db.DBObj.GetRs(strSQL1, out Rs1);
        if (Rs1.RowCount > 0)
        {
            sql1 = "UPDATE [dbo].[Doctor_Details] SET [UserID] = '" + hrmID + "' ,[normalItem] = '" + lb1 + "',[details] = '" + tb1 + "'";
        }
        if (!String.IsNullOrEmpty(tb1))
            db.DBObj.Exec(sql1);
    }
}