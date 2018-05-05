using Bright.Data;
using Maticsoft.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test_Doctor1 : System.Web.UI.Page
{
    database_inte db = new database_inte();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ResultDataSet Rs = new ResultDataSet();
            string strSQL = "select * from Hrms_Department where hrmID=1007";
            db.DBObj.GetRs(strSQL, out Rs);
            if (Rs.RowCount > 0)
            {
                Label1.Text = Rs[0, "departname"].ToString();
                Label2.Text= Rs[0, "name"].ToString();
                Label3.Text = Rs[0, "workyear"].ToString();
                Label4.Text = Rs[0, "techlevel"].ToString();
            }
            ResultDataSet Rs2 = new ResultDataSet();
            string strSQL2 = "select * from Hrms where UserId='1007'";
            db.DBObj.GetRs(strSQL2, out Rs2);
            if (Rs2.RowCount > 0)
            {
                Label5.Text = Rs2[0, "number"].ToString();
                Label6.Text = Rs2[0, "WorkDate"].ToString();
            }

            ResultDataSet Rs3 = new ResultDataSet();
            string strSQL3 = "select * from Doctor_Item where UserId='1007'";
            db.DBObj.GetRs(strSQL3, out Rs3);
            if (Rs3.RowCount > 0)
            {
                string[] normalItem1Array = Rs3[0, "normalItem1"].ToString().Split('&');
                if (normalItem1Array.Length == 3)
                {
                    SQ1.Text = normalItem1Array[0];
                    CBS1.Checked = normalItem1Array[1] == "1" ? true:false ;
                    CBQ1.Checked = normalItem1Array[2] == "1" ? true : false;
                }
                string[] normalItem2Array = Rs3[0, "normalItem2"].ToString().Split('&');
                if (normalItem1Array.Length == 3)
                {
                    SQ2.Text = normalItem2Array[0];
                    CBS2.Checked = normalItem2Array[1] == "1" ? true : false;
                    CBQ2.Checked = normalItem2Array[2] == "1" ? true : false;
                }
                string[] normalItem3Array = Rs3[0, "normalItem3"].ToString().Split('&');
                if (normalItem3Array.Length == 3)
                {
                    SQ3.Text = normalItem3Array[0];
                    CBS3.Checked = normalItem3Array[1] == "1" ? true : false;
                    CBQ3.Checked = normalItem3Array[2] == "1" ? true : false;
                }
                string[] normalItem4Array = Rs3[0, "normalItem4"].ToString().Split('&');
                if (normalItem4Array.Length == 3)
                {
                    SQ4.Text = normalItem4Array[0];
                    CBS4.Checked = normalItem4Array[1] == "1" ? true : false;
                    CBQ4.Checked = normalItem4Array[2] == "1" ? true : false;
                }
                string[] normalItem5Array = Rs3[0, "normalItem5"].ToString().Split('&');
                if (normalItem5Array.Length == 3)
                {
                    SQ5.Text = normalItem5Array[0];
                    CBS5.Checked = normalItem5Array[1] == "1" ? true : false;
                    CBQ5.Checked = normalItem5Array[2] == "1" ? true : false;
                }
                string[] normalItem6Array = Rs3[0, "normalItem6"].ToString().Split('&');
                if (normalItem6Array.Length == 3)
                {
                    SQ6.Text = normalItem6Array[0];
                    CBS6.Checked = normalItem6Array[1] == "1" ? true : false;
                    CBQ6.Checked = normalItem6Array[2] == "1" ? true : false;
                }
                string[] normalItem7Array = Rs3[0, "normalItem7"].ToString().Split('&');
                if (normalItem7Array.Length == 3)
                {
                    SQ7.Text = normalItem7Array[0];
                    CBS7.Checked = normalItem7Array[1] == "1" ? true : false;
                    CBQ7.Checked = normalItem7Array[2] == "1" ? true : false;
                }
                string[] normalItem8Array = Rs3[0, "normalItem8"].ToString().Split('&');
                if (normalItem8Array.Length == 3)
                {
                    SQ8.Text = normalItem8Array[0];
                    CBS8.Checked = normalItem8Array[1] == "1" ? true : false;
                    CBQ8.Checked = normalItem8Array[2] == "1" ? true : false;
                }
                string[] normalItem9Array = Rs3[0, "normalItem9"].ToString().Split('&');
                if (normalItem9Array.Length == 3)
                {
                    SQ9.Text = normalItem9Array[0];
                    CBS9.Checked = normalItem9Array[1] == "1" ? true : false;
                    CBQ9.Checked = normalItem9Array[2] == "1" ? true : false;
                }
                string[] normalItem10Array = Rs3[0, "normalItem10"].ToString().Split('&');
                if (normalItem10Array.Length == 3)
                {
                    SQ10.Text = normalItem10Array[0];
                    CBS10.Checked = normalItem10Array[1] == "1" ? true : false;
                    CBQ10.Checked = normalItem10Array[2] == "1" ? true : false;
                }
                //特殊授权
                string[] specialItem1Array = Rs3[0, "specialItem1"].ToString().Split('&');
                if (specialItem1Array.Length == 3)
                {
                    TB1.Text = specialItem1Array[0];
                    CB1.Checked = specialItem1Array[1] == "1" ? true : false;
                    CB11.Checked = specialItem1Array[2] == "1" ? true : false;
                }
                string[] specialItem2Array = Rs3[0, "specialItem2"].ToString().Split('&');
                if (specialItem2Array.Length == 3)
                {
                    TB2.Text = specialItem2Array[0];
                    CB2.Checked = specialItem2Array[1] == "1" ? true : false;
                    CB12.Checked = specialItem2Array[2] == "1" ? true : false;
                }
                string[] specialItem3Array = Rs3[0, "specialItem3"].ToString().Split('&');
                if (specialItem3Array.Length == 3)
                {
                    TB3.Text = specialItem3Array[0];
                    CB3.Checked = specialItem3Array[1] == "1" ? true : false;
                    CB13.Checked = specialItem3Array[2] == "1" ? true : false;
                }
                string[] specialItem4Array = Rs3[0, "specialItem4"].ToString().Split('&');
                if (specialItem4Array.Length == 3)
                {
                    TB4.Text = specialItem4Array[0];
                    CB4.Checked = specialItem4Array[1] == "1" ? true : false;
                    CB14.Checked = specialItem4Array[2] == "1" ? true : false;
                }
                string[] specialItem5Array = Rs3[0, "specialItem5"].ToString().Split('&');
                if (specialItem1Array.Length == 3)
                {
                    TB5.Text = specialItem5Array[0];
                    CB5.Checked = specialItem5Array[1] == "1" ? true : false;
                    CB15.Checked = specialItem5Array[2] == "1" ? true : false;
                }
                string[] specialItem6Array = Rs3[0, "specialItem6"].ToString().Split('&');
                if (specialItem6Array.Length == 3)
                {
                    TB6.Text = specialItem6Array[0];
                    CB6.Checked = specialItem6Array[1] == "1" ? true : false;
                    CB16.Checked = specialItem6Array[2] == "1" ? true : false;
                }
                string[] specialItem7Array = Rs3[0, "specialItem7"].ToString().Split('&');
                if (specialItem7Array.Length == 3)
                {
                    TB7.Text = specialItem7Array[0];
                    CB7.Checked = specialItem7Array[1] == "1" ? true : false;
                    CB17.Checked = specialItem7Array[2] == "1" ? true : false;
                }
                string[] specialItem8Array = Rs3[0, "specialItem8"].ToString().Split('&');
                if (specialItem8Array.Length == 3)
                {
                    TB8.Text = specialItem8Array[0];
                    CB8.Checked = specialItem8Array[1] == "1" ? true : false;
                    CB18.Checked = specialItem8Array[2] == "1" ? true : false;
                }
                string[] specialItem9Array = Rs3[0, "specialItem9"].ToString().Split('&');
                if (specialItem9Array.Length == 3)
                {
                    TB9.Text = specialItem9Array[0];
                    CB9.Checked = specialItem9Array[1] == "1" ? true : false;
                    CB19.Checked = specialItem9Array[2] == "1" ? true : false;
                }
                string[] specialItem10Array = Rs3[0, "specialItem10"].ToString().Split('&');
                if (specialItem10Array.Length == 3)
                {
                    TB10.Text = specialItem10Array[0];
                    CB10.Checked = specialItem10Array[1] == "1" ? true : false;
                    CB20.Checked = specialItem10Array[2] == "1" ? true : false;
                }
                string[] str= Rs3[0, "otherItem"].ToString().Split('&');
                for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                {
                    for (int j = 0; j < str.Length; j++)
                    {
                        if (CheckBoxList1.Items[i].Value == str[j])
                        {
                            CheckBoxList1.Items[i].Selected = true;
                        }
                    }
                    
                }
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string _sq1 = SQ1.Text.ToString();
        string _cbs1 = CBS1.Checked ? "1" : "0";
        string _cbq1=CBQ1.Checked ? "1" : "0";
        string _sq1cb = _sq1 + "&" + _cbs1 + "&" + _cbq1;

        string _sq2 = SQ2.Text.ToString();
        string _cbs2 = CBS2.Checked ? "1" : "0";
        string _cbq2 = CBQ2.Checked ? "1" : "0";
        string _sq2cb = _sq2 + "&" + _cbs2 + "&" + _cbq2;

        string _sq3 = SQ3.Text.ToString();
        string _cbs3 = CBS3.Checked ? "1" : "0";
        string _cbq3 = CBQ3.Checked ? "1" : "0";
        string _sq3cb = _sq3 + "&" + _cbs3 + "&" + _cbq3;

        string _sq4 = SQ4.Text.ToString();
        string _cbs4 = CBS4.Checked ? "1" : "0";
        string _cbq4 = CBQ4.Checked ? "1" : "0";
        string _sq4cb = _sq4 + "&" + _cbs4 + "&" + _cbq4;

        string _sq5 = SQ5.Text.ToString();
        string _cbs5 = CBS5.Checked ? "1" : "0";
        string _cbq5 = CBQ5.Checked ? "1" : "0";
        string _sq5cb = _sq5 + "&" + _cbs5 + "&" + _cbq5;

        string _sq6 = SQ6.Text.ToString();
        string _cbs6 = CBS6.Checked ? "1" : "0";
        string _cbq6 = CBQ6.Checked ? "1" : "0";
        string _sq6cb = _sq6 + "&" + _cbs6 + "&" + _cbq6;

        string _sq7 = SQ7.Text.ToString();
        string _cbs7 = CBS7.Checked ? "1" : "0";
        string _cbq7 = CBQ7.Checked ? "1" : "0";
        string _sq7cb = _sq7 + "&" + _cbs7 + "&" + _cbq7;

        string _sq8 = SQ8.Text.ToString();
        string _cbs8 = CBS8.Checked ? "1" : "0";
        string _cbq8 = CBQ8.Checked ? "1" : "0";
        string _sq8cb = _sq8 + "&" + _cbs8 + "&" + _cbq8;

        string _sq9 = SQ9.Text.ToString();
        string _cbs9 = CBS9.Checked ? "1" : "0";
        string _cbq9 = CBQ9.Checked ? "1" : "0";
        string _sq9cb = _sq9 + "&" + _cbs9 + "&" + _cbq9;

        string _sq10 = SQ10.Text.ToString();
        string _cbs10 = CBS10.Checked ? "1" : "0";
        string _cbq10 = CBQ10.Checked ? "1" : "0";
        string _sq10cb = _sq10 + "&" + _cbs10 + "&" + _cbq10;

        string _tp1 = TB1.Text.ToString();
        string _cb1 = CB1.Checked ? "1" : "0";
        string _cb11 = CB11.Checked ? "1" : "0";
        string _tssq1 = _tp1 + "&" + _cb1 + "&" + _cb11;

        string _tp2 = TB2.Text.ToString();
        string _cb2 = CB2.Checked ? "1" : "0";
        string _cb12 = CB12.Checked ? "1" : "0";
        string _tssq2 = _tp2 + "&" + _cb2 + "&" + _cb12;

        string _tp3 = TB3.Text.ToString();
        string _cb3 = CB3.Checked ? "1" : "0";
        string _cb13 = CB13.Checked ? "1" : "0";
        string _tssq3 = _tp3 + "&" + _cb3 + "&" + _cb13;

        string _tp4 = TB4.Text.ToString();
        string _cb4 = CB4.Checked ? "1" : "0";
        string _cb14= CB14.Checked ? "1" : "0";
        string _tssq4 = _tp4 + "&" + _cb4 + "&" + _cb14;

        string _tp5 = TB5.Text.ToString();
        string _cb5 = CB5.Checked ? "1" : "0";
        string _cb15 = CB15.Checked ? "1" : "0";
        string _tssq5 = _tp5 + "&" + _cb5 + "&" + _cb15;

        string _tp6 = TB6.Text.ToString();
        string _cb6 = CB6.Checked ? "1" : "0";
        string _cb16 = CB16.Checked ? "1" : "0";
        string _tssq6 = _tp6 + "&" + _cb6 + "&" + _cb16;

        string _tp7 = TB7.Text.ToString();
        string _cb7 = CB7.Checked ? "1" : "0";
        string _cb17 = CB17.Checked ? "1" : "0";
        string _tssq7 = _tp7 + "&" + _cb7 + "&" + _cb17;

        string _tp8 = TB8.Text.ToString();
        string _cb8 = CB8.Checked ? "1" : "0";
        string _cb18 = CB18.Checked ? "1" : "0";
        string _tssq8 = _tp8 + "&" + _cb8 + "&" + _cb18;

        string _tp9 = TB9.Text.ToString();
        string _cb9 = CB9.Checked ? "1" : "0";
        string _cb19 = CB19.Checked ? "1" : "0";
        string _tssq9 = _tp9 + "&" + _cb9 + "&" + _cb19;

        string _tp10 = TB10.Text.ToString();
        string _cb10 = CB10.Checked ? "1" : "0";
        string _cb20 = CB20.Checked ? "1" : "0";
        string _tssq10 = _tp10 + "&" + _cb10 + "&" + _cb20;

        string str = "";
        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        {
            if (CheckBoxList1.Items[i].Selected)
            {
                str += CheckBoxList1.Items[i].Value + "&";
            }
        }
        string UserId = "1007";
        string _add_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        ResultDataSet Rs3 = new ResultDataSet();
        string strSQL3 = "select * from Doctor_Item where UserId='1007'";
        db.DBObj.GetRs(strSQL3, out Rs3);
        if (Rs3.RowCount > 0)
        {
            string sql2 = "UPDATE [dbo].[Doctor_Item]"
                        + " SET[normalItem1] = '" + _sq1cb + "'"
                        + " ,[normalItem2] = '" + _sq2cb + "'"
                        + " ,[normalItem3] = '" + _sq3cb + "'"
                        + " ,[normalItem4] = '" + _sq4cb + "'"
                        + "  ,[normalItem5] = '" + _sq5cb + "'"
                        + "  ,[normalItem6] = '" + _sq6cb + "'"
                        + " ,[normalItem7] = '" + _sq7cb + "'"
                        + " ,[normalItem8] = '" + _sq8cb + "'"
                        + " ,[normalItem9] = '" + _sq9cb + "'"
                        + " ,[normalItem10] = '" + _sq10cb + "'"
                        + "  ,[specialItem1] = '" + _tssq1 + "'"
                        + "  ,[specialItem2] = '" + _tssq2 + "'"
                        + "  ,[specialItem3] = '" + _tssq3 + "'"
                        + "  ,[specialItem4] = '" + _tssq4 + "'"
                        + " ,[specialItem5] = '" + _tssq5 + "'"
                        + " ,[specialItem6] = '" + _tssq6 + "'"
                        + "  ,[specialItem7] = '" + _tssq7 + "'"
                        + "  ,[specialItem8] = '" + _tssq8 + "'"
                        + "  ,[specialItem9] = '" + _tssq9 + "'"
                        + "  ,[specialItem10] = '" + _tssq10 + "'"
                        + "  ,[UserId] = '" + UserId + "'"
                        + "  ,[otherItem] = '" + str + "'"
                        + "  ,[add_time] = '" + _add_time + "'"
                        + " WHERE UserId='" + UserId + "'";
            if (db.DBObj.Exec(sql2))
            {
                Response.Write("<script>javascript:alert( '修改成功');window.location='Doctor1.aspx'</script>");
            }
        }
        else
        {
            string sql = "INSERT [Doctor_Item] ([normalItem1],[normalItem2],[normalItem3],[normalItem4],[normalItem5],[normalItem6],[normalItem7],[normalItem8],[normalItem9],[normalItem10],[specialItem1],[specialItem2],[specialItem3],[specialItem4],[specialItem5],[specialItem6],[specialItem7],[specialItem8],[specialItem9],[specialItem10],[UserId],[otherItem],[add_time]) VALUES"
            + " ( '" + _sq1cb + "','" + _sq2cb + "','" + _sq3cb + "','" + _sq4cb + "','" + _sq5cb + "','" + _sq6cb + "','" + _sq7cb + "','" + _sq8cb + "','" + _sq9cb + "','" + _sq10cb + "',"
            + " '" + _tssq1 + "','" + _tssq2 + "','" + _tssq3 + "','" + _tssq4 + "','" + _tssq5 + "','" + _tssq6 + "','" + _tssq7 + "','" + _tssq8 + "','" + _tssq9 + "','" + _tssq10 + "',"
            + " '" + UserId + "','" + str + "','" + _add_time + "')";
            if (db.DBObj.Exec(sql))
            {
                Response.Write("<script>javascript:alert( '保存成功！');window.location='Doctor1.aspx'</script>");
            }
        }
        
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("DoctorItemDetails.aspx");
    }
}