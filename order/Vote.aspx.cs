using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bright.Data;
using Maticsoft.Common;

public partial class order_Vote : System.Web.UI.Page
{
    database_inte db = new database_inte();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ResultDataSet Rs = new ResultDataSet();
            string sql = "select top 1* from Advise where useID='8108' order by id desc";
            if (db.DBObj.GetRs(sql, out Rs)&&Rs.RowCount>0)
            {
                
                for (int i = 0; i < this.RadioButtonList1.Items.Count; i++)
                {
                    if (this.RadioButtonList1.Items[i].Value == Rs[0, "department"].ToString())
                    {
                        this.RadioButtonList1.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.A1.Items.Count; i++)
                {
                    if (this.A1.Items[i].Value == Rs[0, "A1"].ToString())
                    {
                        this.A1.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.A2.Items.Count; i++)
                {
                    if (this.A2.Items[i].Value == Rs[0, "A2"].ToString())
                    {
                        this.A2.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.A3.Items.Count; i++)
                {
                    if (this.A3.Items[i].Value == Rs[0, "A3"].ToString())
                    {
                        this.A3.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.A4.Items.Count; i++)
                {
                    if (this.A4.Items[i].Value == Rs[0, "A4"].ToString())
                    {
                        this.A4.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.A5.Items.Count; i++)
                {
                    if (this.A5.Items[i].Value == Rs[0, "A5"].ToString())
                    {
                        this.A5.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.A6.Items.Count; i++)
                {
                    if (this.A6.Items[i].Value == Rs[0, "A6"].ToString())
                    {
                        this.A6.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.B1.Items.Count; i++)
                {
                    if (this.B1.Items[i].Value == Rs[0, "B1"].ToString())
                    {
                        this.B1.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.B2.Items.Count; i++)
                {
                    if (this.B2.Items[i].Value == Rs[0, "B2"].ToString())
                    {
                        this.B2.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.B3.Items.Count; i++)
                {
                    if (this.B3.Items[i].Value == Rs[0, "B3"].ToString())
                    {
                        this.B3.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.B4.Items.Count; i++)
                {
                    if (this.B4.Items[i].Value == Rs[0, "B4"].ToString())
                    {
                        this.B4.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.B5.Items.Count; i++)
                {
                    if (this.B5.Items[i].Value == Rs[0, "B5"].ToString())
                    {
                        this.B5.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.B6.Items.Count; i++)
                {
                    if (this.B6.Items[i].Value == Rs[0, "B6"].ToString())
                    {
                        this.B6.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.B7.Items.Count; i++)
                {
                    if (this.B7.Items[i].Value == Rs[0, "B7"].ToString())
                    {
                        this.B7.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.C1.Items.Count; i++)
                {
                    if (this.C1.Items[i].Value == Rs[0, "C1"].ToString())
                    {
                        this.C1.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.C2.Items.Count; i++)
                {
                    if (this.C2.Items[i].Value == Rs[0, "C2"].ToString())
                    {
                        this.C2.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.C3.Items.Count; i++)
                {
                    if (this.C3.Items[i].Value == Rs[0, "C3"].ToString())
                    {
                        this.C3.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.C4.Items.Count; i++)
                {
                    if (this.C4.Items[i].Value == Rs[0, "C4"].ToString())
                    {
                        this.C4.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.C5.Items.Count; i++)
                {
                    if (this.C5.Items[i].Value == Rs[0, "C5"].ToString())
                    {
                        this.C5.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.D1.Items.Count; i++)
                {
                    if (this.D1.Items[i].Value == Rs[0, "D1"].ToString())
                    {
                        this.D1.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.D2.Items.Count; i++)
                {
                    if (this.D2.Items[i].Value == Rs[0, "D2"].ToString())
                    {
                        this.D2.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.D3.Items.Count; i++)
                {
                    if (this.D3.Items[i].Value == Rs[0, "D3"].ToString())
                    {
                        this.D3.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.D4.Items.Count; i++)
                {
                    if (this.D4.Items[i].Value == Rs[0, "D4"].ToString())
                    {
                        this.D4.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.D5.Items.Count; i++)
                {
                    if (this.D5.Items[i].Value == Rs[0, "D5"].ToString())
                    {
                        this.D5.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.D6.Items.Count; i++)
                {
                    if (this.D6.Items[i].Value == Rs[0, "D6"].ToString())
                    {
                        this.D6.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.D7.Items.Count; i++)
                {
                    if (this.D7.Items[i].Value == Rs[0, "D7"].ToString())
                    {
                        this.D7.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.D8.Items.Count; i++)
                {
                    if (this.D8.Items[i].Value == Rs[0, "D8"].ToString())
                    {
                        this.D8.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.D9.Items.Count; i++)
                {
                    if (this.D9.Items[i].Value == Rs[0, "D9"].ToString())
                    {
                        this.D9.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.D10.Items.Count; i++)
                {
                    if (this.D10.Items[i].Value == Rs[0, "D10"].ToString())
                    {
                        this.D10.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.E1.Items.Count; i++)
                {
                    if (this.E1.Items[i].Value == Rs[0, "E1"].ToString())
                    {
                        this.E1.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.E2.Items.Count; i++)
                {
                    if (this.E2.Items[i].Value == Rs[0, "E2"].ToString())
                    {
                        this.E2.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.E3.Items.Count; i++)
                {
                    if (this.E3.Items[i].Value == Rs[0, "E3"].ToString())
                    {
                        this.E3.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.E4.Items.Count; i++)
                {
                    if (this.E4.Items[i].Value == Rs[0, "E4"].ToString())
                    {
                        this.E4.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.F1.Items.Count; i++)
                {
                    if (this.F1.Items[i].Value == Rs[0, "F1"].ToString())
                    {
                        this.F1.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.F2.Items.Count; i++)
                {
                    if (this.F2.Items[i].Value == Rs[0, "F2"].ToString())
                    {
                        this.F2.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.F3.Items.Count; i++)
                {
                    if (this.F3.Items[i].Value == Rs[0, "F3"].ToString())
                    {
                        this.F3.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.F4.Items.Count; i++)
                {
                    if (this.F4.Items[i].Value == Rs[0, "F4"].ToString())
                    {
                        this.F4.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.G1.Items.Count; i++)
                {
                    if (this.G1.Items[i].Value == Rs[0, "G1"].ToString())
                    {
                        this.G1.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.G2.Items.Count; i++)
                {
                    if (this.G2.Items[i].Value == Rs[0, "G2"].ToString())
                    {
                        this.G2.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.G3.Items.Count; i++)
                {
                    if (this.G3.Items[i].Value == Rs[0, "G3"].ToString())
                    {
                        this.G3.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.G4.Items.Count; i++)
                {
                    if (this.G4.Items[i].Value == Rs[0, "G4"].ToString())
                    {
                        this.G4.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.G5.Items.Count; i++)
                {
                    if (this.G5.Items[i].Value == Rs[0, "G5"].ToString())
                    {
                        this.G5.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.G6.Items.Count; i++)
                {
                    if (this.G6.Items[i].Value == Rs[0, "G6"].ToString())
                    {
                        this.G6.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.G7.Items.Count; i++)
                {
                    if (this.G7.Items[i].Value == Rs[0, "G7"].ToString())
                    {
                        this.G7.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.G8.Items.Count; i++)
                {
                    if (this.G8.Items[i].Value == Rs[0, "G8"].ToString())
                    {
                        this.G8.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.G9.Items.Count; i++)
                {
                    if (this.G9.Items[i].Value == Rs[0, "G9"].ToString())
                    {
                        this.G9.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.week.Items.Count; i++)
                {
                    if (this.week.Items[i].Value == Rs[0, "tb_week"].ToString())
                    {
                        this.week.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.mind.Items.Count; i++)
                {
                    if (this.mind.Items[i].Value == Rs[0, "tb_mind"].ToString())
                    {
                        this.mind.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.hour1.Items.Count; i++)
                {
                    if (this.hour1.Items[i].Value == Rs[0, "hour1"].ToString())
                    {
                        this.hour1.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.hour2.Items.Count; i++)
                {
                    if (this.hour2.Items[i].Value == Rs[0, "hour2"].ToString())
                    {
                        this.hour2.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.hour3.Items.Count; i++)
                {
                    if (this.hour3.Items[i].Value == Rs[0, "hour3"].ToString())
                    {
                        this.hour3.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.hour4.Items.Count; i++)
                {
                    if (this.hour4.Items[i].Value == Rs[0, "hour4"].ToString())
                    {
                        this.hour4.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.hour5.Items.Count; i++)
                {
                    if (this.hour5.Items[i].Value == Rs[0, "hour5"].ToString())
                    {
                        this.hour5.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.hour6.Items.Count; i++)
                {
                    if (this.hour6.Items[i].Value == Rs[0, "hour6"].ToString())
                    {
                        this.hour6.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.hour7.Items.Count; i++)
                {
                    if (this.hour7.Items[i].Value == Rs[0, "hour7"].ToString())
                    {
                        this.hour7.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.sex.Items.Count; i++)
                {
                    if (this.sex.Items[i].Value == Rs[0, "sex"].ToString())
                    {
                        this.sex.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.ages.Items.Count; i++)
                {
                    if (this.ages.Items[i].Value == Rs[0, "ages"].ToString())
                    {
                        this.ages.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.leader.Items.Count; i++)
                {
                    if (this.leader.Items[i].Value == Rs[0, "leader"].ToString())
                    {
                        this.leader.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.dan.Items.Count; i++)
                {
                    if (this.dan.Items[i].Value == Rs[0, "dan"].ToString())
                    {
                        this.dan.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.type.Items.Count; i++)
                {
                    if (this.type.Items[i].Value == Rs[0, "type"].ToString())
                    {
                        this.type.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.employee.Items.Count; i++)
                {
                    if (this.employee.Items[i].Value == Rs[0, "employee"].ToString())
                    {
                        this.employee.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.workages.Items.Count; i++)
                {
                    if (this.workages.Items[i].Value == Rs[0, "workages"].ToString())
                    {
                        this.workages.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.workagesSelf.Items.Count; i++)
                {
                    if (this.workagesSelf.Items[i].Value == Rs[0, "workagesSelf"].ToString())
                    {
                        this.workagesSelf.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.education.Items.Count; i++)
                {
                    if (this.education.Items[i].Value == Rs[0, "education"].ToString())
                    {
                        this.education.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.patient.Items.Count; i++)
                {
                    if (this.patient.Items[i].Value == Rs[0, "patient"].ToString())
                    {
                        this.patient.Items[i].Selected = true;
                    }
                }
                for (int i = 0; i < this.hard.Items.Count; i++)
                {
                    if (this.hard.Items[i].Value == Rs[0, "hard"].ToString())
                    {
                        this.hard.Items[i].Selected = true;
                    }
                }
                safe.Text = Rs[0, "safe"].ToString();
                advise.Text = Rs[0, "advise"].ToString();
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string _department = "";
        if (RadioButtonList1.SelectedIndex != -1)
        {
            //Response.Write("<script>alert('请选择科室！');</script>");
            //Response.End();
            //Response.Write("<script>alert('提交成功！" + sBasicTools + "');window.location.href ='Vote.aspx'</script>");
            for (int i = 0; i < this.RadioButtonList1.Items.Count; i++)
            {
                if (this.RadioButtonList1.Items[i].Selected == true)
                {
                    _department = this.RadioButtonList1.Items[i].Value;
                    
                }
            }
        }
        string _A1 = "";
        if (A1.SelectedIndex != -1)
        {
            for (int i = 0; i < this.A1.Items.Count; i++)
            {
                if (this.A1.Items[i].Selected == true)
                {
                    _A1 = this.A1.Items[i].Value;

                }
            }
        }
        string _A2 = "";
        if (A2.SelectedIndex != -1)
        {
            for (int i = 0; i < this.A2.Items.Count; i++)
            {
                if (this.A2.Items[i].Selected == true)
                {
                    _A2 = this.A2.Items[i].Value;

                }
            }
        }
        string _A3 = "";
        if (A3.SelectedIndex != -1)
        {
            for (int i = 0; i < this.A3.Items.Count; i++)
            {
                if (this.A3.Items[i].Selected == true)
                {
                    _A3 = this.A3.Items[i].Value;

                }
            }
        }
        string _A4 = "";
        if (A4.SelectedIndex != -1)
        {
            for (int i = 0; i < this.A4.Items.Count; i++)
            {
                if (this.A4.Items[i].Selected == true)
                {
                    _A4 = this.A4.Items[i].Value;

                }
            }
        }
        string _A5 = "";
        if (A5.SelectedIndex != -1)
        {
            for (int i = 0; i < this.A5.Items.Count; i++)
            {
                if (this.A5.Items[i].Selected == true)
                {
                    _A5 = this.A5.Items[i].Value;

                }
            }
        }
        string _A6 = "";
        if (A6.SelectedIndex != -1)
        {
            for (int i = 0; i < this.A6.Items.Count; i++)
            {
                if (this.A6.Items[i].Selected == true)
                {
                    _A6 = this.A6.Items[i].Value;

                }
            }
        }

        string _B1 = "";
        if (B1.SelectedIndex != -1)
        {
            for (int i = 0; i < this.B1.Items.Count; i++)
            {
                if (this.B1.Items[i].Selected == true)
                {
                    _B1 = this.B1.Items[i].Value;

                }
            }
        }
        string _B2 = "";
        if (B2.SelectedIndex != -1)
        {
            for (int i = 0; i < this.B2.Items.Count; i++)
            {
                if (this.B2.Items[i].Selected == true)
                {
                    _B2 = this.B2.Items[i].Value;

                }
            }
        }
        string _B3 = "";
        if (B3.SelectedIndex != -1)
        {
            for (int i = 0; i < this.B3.Items.Count; i++)
            {
                if (this.B3.Items[i].Selected == true)
                {
                    _B3 = this.B3.Items[i].Value;

                }
            }
        }
        string _B4 = "";
        if (B4.SelectedIndex != -1)
        {
            for (int i = 0; i < this.B4.Items.Count; i++)
            {
                if (this.B4.Items[i].Selected == true)
                {
                    _B4 = this.B4.Items[i].Value;

                }
            }
        }
        string _B5 = "";
        if (B5.SelectedIndex != -1)
        {
            for (int i = 0; i < this.B5.Items.Count; i++)
            {
                if (this.B5.Items[i].Selected == true)
                {
                    _B5 = this.B5.Items[i].Value;

                }
            }
        }
        string _B6 = "";
        if (B6.SelectedIndex != -1)
        {
            for (int i = 0; i < this.B6.Items.Count; i++)
            {
                if (this.B6.Items[i].Selected == true)
                {
                    _B6 = this.B6.Items[i].Value;

                }
            }
        }
        string _B7 = "";
        if (B7.SelectedIndex != -1)
        {
            for (int i = 0; i < this.B7.Items.Count; i++)
            {
                if (this.B7.Items[i].Selected == true)
                {
                    _B7 = this.B7.Items[i].Value;

                }
            }
        }

        string _C1 = "";
        if (C1.SelectedIndex != -1)
        {
            for (int i = 0; i < this.C1.Items.Count; i++)
            {
                if (this.C1.Items[i].Selected == true)
                {
                    _C1 = this.C1.Items[i].Value;

                }
            }
        }
        string _C2 = "";
        if (C2.SelectedIndex != -1)
        {
            for (int i = 0; i < this.C2.Items.Count; i++)
            {
                if (this.C2.Items[i].Selected == true)
                {
                    _C2 = this.C2.Items[i].Value;

                }
            }
        }
        string _C3 = "";
        if (C3.SelectedIndex != -1)
        {
            for (int i = 0; i < this.C3.Items.Count; i++)
            {
                if (this.C3.Items[i].Selected == true)
                {
                    _C3 = this.C3.Items[i].Value;

                }
            }
        }
        string _C4 = "";
        if (C4.SelectedIndex != -1)
        {
            for (int i = 0; i < this.C4.Items.Count; i++)
            {
                if (this.C4.Items[i].Selected == true)
                {
                    _C4 = this.C4.Items[i].Value;

                }
            }
        }
        string _C5 = "";
        if (C5.SelectedIndex != -1)
        {
            for (int i = 0; i < this.C5.Items.Count; i++)
            {
                if (this.C5.Items[i].Selected == true)
                {
                    _C5 = this.C5.Items[i].Value;

                }
            }
        }

        string _D1= "";
        if (D1.SelectedIndex != -1)
        {
            for (int i = 0; i < this.D1.Items.Count; i++)
            {
                if (this.D1.Items[i].Selected == true)
                {
                    _D1 = this.D1.Items[i].Value;

                }
            }
        }
        string _D2 = "";
        if (D2.SelectedIndex != -1)
        {
            for (int i = 0; i < this.D2.Items.Count; i++)
            {
                if (this.D2.Items[i].Selected == true)
                {
                    _D2 = this.D2.Items[i].Value;

                }
            }
        }
        string _D3 = "";
        if (D3.SelectedIndex != -1)
        {
            for (int i = 0; i < this.D3.Items.Count; i++)
            {
                if (this.D3.Items[i].Selected == true)
                {
                    _D3 = this.D3.Items[i].Value;

                }
            }
        }
        string _D4 = "";
        if (D4.SelectedIndex != -1)
        {
            for (int i = 0; i < this.D4.Items.Count; i++)
            {
                if (this.D4.Items[i].Selected == true)
                {
                    _D4 = this.D4.Items[i].Value;

                }
            }
        }
        string _D5 = "";
        if (D5.SelectedIndex != -1)
        {
            for (int i = 0; i < this.D5.Items.Count; i++)
            {
                if (this.D5.Items[i].Selected == true)
                {
                    _D5 = this.D5.Items[i].Value;

                }
            }
        }
        string _D6 = "";
        if (D6.SelectedIndex != -1)
        {
            for (int i = 0; i < this.D6.Items.Count; i++)
            {
                if (this.D6.Items[i].Selected == true)
                {
                    _D6 = this.D6.Items[i].Value;

                }
            }
        }
        string _D7 = "";
        if (C5.SelectedIndex != -1)
        {
            for (int i = 0; i < this.D7.Items.Count; i++)
            {
                if (this.D7.Items[i].Selected == true)
                {
                    _D7 = this.D7.Items[i].Value;

                }
            }
        }
        string _D8 = "";
        if (D8.SelectedIndex != -1)
        {
            for (int i = 0; i < this.D8.Items.Count; i++)
            {
                if (this.D8.Items[i].Selected == true)
                {
                    _D8 = this.D8.Items[i].Value;

                }
            }
        }
        string _D9 = "";
        if (D9.SelectedIndex != -1)
        {
            for (int i = 0; i < this.D9.Items.Count; i++)
            {
                if (this.D9.Items[i].Selected == true)
                {
                    _D9 = this.D9.Items[i].Value;

                }
            }
        }
        string _D10 = "";
        if (D10.SelectedIndex != -1)
        {
            for (int i = 0; i < this.D10.Items.Count; i++)
            {
                if (this.D10.Items[i].Selected == true)
                {
                    _D10 = this.D10.Items[i].Value;

                }
            }
        }

        string _E1 = "";
        if (E1.SelectedIndex != -1)
        {
            for (int i = 0; i < this.E1.Items.Count; i++)
            {
                if (this.E1.Items[i].Selected == true)
                {
                    _E1 = this.E1.Items[i].Value;

                }
            }
        }
        string _E2 = "";
        if (E2.SelectedIndex != -1)
        {
            for (int i = 0; i < this.E2.Items.Count; i++)
            {
                if (this.E2.Items[i].Selected == true)
                {
                    _E2 = this.E2.Items[i].Value;

                }
            }
        }
        string _E3 = "";
        if (E3.SelectedIndex != -1)
        {
            for (int i = 0; i < this.E3.Items.Count; i++)
            {
                if (this.E3.Items[i].Selected == true)
                {
                    _E3 = this.E3.Items[i].Value;

                }
            }
        }
        string _E4 = "";
        if (E4.SelectedIndex != -1)
        {
            for (int i = 0; i < this.E4.Items.Count; i++)
            {
                if (this.E4.Items[i].Selected == true)
                {
                    _E4 = this.E4.Items[i].Value;

                }
            }
        }
        string _F1 = "";
        if (F1.SelectedIndex != -1)
        {
            for (int i = 0; i < this.F1.Items.Count; i++)
            {
                if (this.F1.Items[i].Selected == true)
                {
                    _F1 = this.F1.Items[i].Value;

                }
            }
        }
        string _F2 = "";
        if (F2.SelectedIndex != -1)
        {
            for (int i = 0; i < this.F2.Items.Count; i++)
            {
                if (this.F2.Items[i].Selected == true)
                {
                    _F2 = this.F2.Items[i].Value;

                }
            }
        }
        string _F3 = "";
        if (F3.SelectedIndex != -1)
        {
            for (int i = 0; i < this.F3.Items.Count; i++)
            {
                if (this.F3.Items[i].Selected == true)
                {
                    _F3 = this.F3.Items[i].Value;

                }
            }
        }
        string _F4 = "";
        if (F4.SelectedIndex != -1)
        {
            for (int i = 0; i < this.F4.Items.Count; i++)
            {
                if (this.F4.Items[i].Selected == true)
                {
                    _F4 = this.F4.Items[i].Value;

                }
            }
        }

        string _G1 = "";
        if (G1.SelectedIndex != -1)
        {
            for (int i = 0; i < this.G1.Items.Count; i++)
            {
                if (this.G1.Items[i].Selected == true)
                {
                    _G1 = this.G1.Items[i].Value;

                }
            }
        }
        string _G2 = "";
        if (G2.SelectedIndex != -1)
        {
            for (int i = 0; i < this.G2.Items.Count; i++)
            {
                if (this.G2.Items[i].Selected == true)
                {
                    _G2 = this.G2.Items[i].Value;

                }
            }
        }
        string _G3 = "";
        if (G3.SelectedIndex != -1)
        {
            for (int i = 0; i < this.G3.Items.Count; i++)
            {
                if (this.G3.Items[i].Selected == true)
                {
                    _G3 = this.G3.Items[i].Value;

                }
            }
        }
        string _G4 = "";
        if (G4.SelectedIndex != -1)
        {
            for (int i = 0; i < this.G4.Items.Count; i++)
            {
                if (this.G4.Items[i].Selected == true)
                {
                    _G4 = this.G4.Items[i].Value;

                }
            }
        }
        string _G5 = "";
        if (G5.SelectedIndex != -1)
        {
            for (int i = 0; i < this.G5.Items.Count; i++)
            {
                if (this.G5.Items[i].Selected == true)
                {
                    _G5 = this.G5.Items[i].Value;

                }
            }
        }
        string _G6 = "";
        if (G6.SelectedIndex != -1)
        {
            for (int i = 0; i < this.G6.Items.Count; i++)
            {
                if (this.G6.Items[i].Selected == true)
                {
                    _G6 = this.G6.Items[i].Value;

                }
            }
        }
        string _G7 = "";
        if (G7.SelectedIndex != -1)
        {
            for (int i = 0; i < this.G7.Items.Count; i++)
            {
                if (this.G7.Items[i].Selected == true)
                {
                    _G7 = this.G7.Items[i].Value;

                }
            }
        }
        string _G8 = "";
        if (G8.SelectedIndex != -1)
        {
            for (int i = 0; i < this.G8.Items.Count; i++)
            {
                if (this.G8.Items[i].Selected == true)
                {
                    _G8 = this.G8.Items[i].Value;

                }
            }
        }
        string _G9 = "";
        if (G9.SelectedIndex != -1)
        {
            for (int i = 0; i < this.G9.Items.Count; i++)
            {
                if (this.G9.Items[i].Selected == true)
                {
                    _G9 = this.G9.Items[i].Value;

                }
            }
        }
        string _G10 = "";
        if (G10.SelectedIndex != -1)
        {
            for (int i = 0; i < this.G10.Items.Count; i++)
            {
                if (this.G10.Items[i].Selected == true)
                {
                    _G10 = this.G10.Items[i].Value;

                }
            }
        }

        string _week = "";
        if (week.SelectedIndex != -1)
        {
            for (int i = 0; i < this.week.Items.Count; i++)
            {
                if (this.week.Items[i].Selected == true)
                {
                    _week += this.week.Items[i].Value+",";

                }
            }
        }

        string _mind = "";
        if (mind.SelectedIndex != -1)
        {
            for (int i = 0; i < this.mind.Items.Count; i++)
            {
                if (this.mind.Items[i].Selected == true)
                {
                    _mind = this.mind.Items[i].Value;

                }
            }
        }

        string _hour1 = "";
        if (hour1.SelectedIndex != -1)
        {
            for (int i = 0; i < this.hour1.Items.Count; i++)
            {
                if (this.hour1.Items[i].Selected == true)
                {
                    _hour1 = this.hour1.Items[i].Value;

                }
            }
        }
        string _hour2 = "";
        if (hour2.SelectedIndex != -1)
        {
            for (int i = 0; i < this.hour2.Items.Count; i++)
            {
                if (this.hour2.Items[i].Selected == true)
                {
                    _hour2 = this.hour2.Items[i].Value;

                }
            }
        }
        string _hour3 = "";
        if (hour3.SelectedIndex != -1)
        {
            for (int i = 0; i < this.hour3.Items.Count; i++)
            {
                if (this.hour3.Items[i].Selected == true)
                {
                    _hour3 = this.hour3.Items[i].Value;

                }
            }
        }
        string _hour4 = "";
        if (hour4.SelectedIndex != -1)
        {
            for (int i = 0; i < this.hour4.Items.Count; i++)
            {
                if (this.hour4.Items[i].Selected == true)
                {
                    _hour4 = this.hour4.Items[i].Value;

                }
            }
        }
        string _hour5 = "";
        if (hour5.SelectedIndex != -1)
        {
            for (int i = 0; i < this.hour5.Items.Count; i++)
            {
                if (this.hour5.Items[i].Selected == true)
                {
                    _hour5 = this.hour5.Items[i].Value;

                }
            }
        }
        string _hour6 = "";
        if (hour6.SelectedIndex != -1)
        {
            for (int i = 0; i < this.hour6.Items.Count; i++)
            {
                if (this.hour6.Items[i].Selected == true)
                {
                    _hour6 = this.hour6.Items[i].Value;

                }
            }
        }
        string _hour7 = "";
        if (hour7.SelectedIndex != -1)
        {
            for (int i = 0; i < this.hour7.Items.Count; i++)
            {
                if (this.hour7.Items[i].Selected == true)
                {
                    _hour7 = this.hour7.Items[i].Value;

                }
            }
        }
        string _sex = "";
        if (sex.SelectedIndex != -1)
        {
            for (int i = 0; i < this.sex.Items.Count; i++)
            {
                if (this.sex.Items[i].Selected == true)
                {
                    _sex = this.sex.Items[i].Value;

                }
            }
        }
        string _ages = "";
        if (ages.SelectedIndex != -1)
        {
            for (int i = 0; i < this.ages.Items.Count; i++)
            {
                if (this.ages.Items[i].Selected == true)
                {
                    _ages = this.ages.Items[i].Value;

                }
            }
        }
        string _leader = "";
        if (leader.SelectedIndex != -1)
        {
            for (int i = 0; i < this.leader.Items.Count; i++)
            {
                if (this.leader.Items[i].Selected == true)
                {
                    _leader = this.leader.Items[i].Value;

                }
            }
        }
        string _dan = "";
        if (dan.SelectedIndex != -1)
        {
            for (int i = 0; i < this.dan.Items.Count; i++)
            {
                if (this.dan.Items[i].Selected == true)
                {
                    _dan = this.dan.Items[i].Value;

                }
            }
        }
        string _type = "";
        if (type.SelectedIndex != -1)
        {
            for (int i = 0; i < this.type.Items.Count; i++)
            {
                if (this.type.Items[i].Selected == true)
                {
                    _type = this.type.Items[i].Value;

                }
            }
        }
        string _employee = "";
        if (employee.SelectedIndex != -1)
        {
            for (int i = 0; i < this.employee.Items.Count; i++)
            {
                if (this.employee.Items[i].Selected == true)
                {
                    _employee = this.employee.Items[i].Value;

                }
            }
        }
        string _workages = "";
        if (workages.SelectedIndex != -1)
        {
            for (int i = 0; i < this.workages.Items.Count; i++)
            {
                if (this.workages.Items[i].Selected == true)
                {
                    _workages = this.workages.Items[i].Value;

                }
            }
        }
        string _workagesSelf = "";
        if (workagesSelf.SelectedIndex != -1)
        {
            for (int i = 0; i < this.workagesSelf.Items.Count; i++)
            {
                if (this.workagesSelf.Items[i].Selected == true)
                {
                    _workagesSelf = this.workagesSelf.Items[i].Value;

                }
            }
        }
        string _education = "";
        if (education.SelectedIndex != -1)
        {
            for (int i = 0; i < this.education.Items.Count; i++)
            {
                if (this.education.Items[i].Selected == true)
                {
                    _education = this.education.Items[i].Value;

                }
            }
        }
        string _patient = "";
        if (patient.SelectedIndex != -1)
        {
            for (int i = 0; i < this.patient.Items.Count; i++)
            {
                if (this.patient.Items[i].Selected == true)
                {
                    _patient = this.patient.Items[i].Value;

                }
            }
        }
        string _hard = "";
        if (hard.SelectedIndex != -1)
        {
            for (int i = 0; i < this.hard.Items.Count; i++)
            {
                if (this.hard.Items[i].Selected == true)
                {
                    _hard = this.hard.Items[i].Value;

                }
            }
        }
        string _safe = ""; string _advise = ""; string _useID = "8108"; string _add_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        _safe = safe.Text.ToString();
        _advise = advise.Text.ToString();

        string sql="INSERT INTO [dbo].[Advise]([department],[A1],[A2],[A3],[A4],[A5],[A6],[B1],[B2],[B3],[B4],[B5],[B6],[B7],[C1],[C2],[C3],[C4],[C5],[D1]"+
           ",[D2],[D3],[D4],[D5],[D6],[D7],[D8],[D9],[D10],[E1],[E2],[E3],[E4],[F1],[F2],[F3],[F4],[G1],[G2],[G3],[G4],[G5],[G6],[G7],[G8]"+
           ",[G9],[G10],[tb_week],[tb_mind],[hour1],[hour2],[hour3],[hour4],[hour5],[hour6],[hour7],[safe],[sex],[ages],[leader],[dan],[type]"+
           ",[employee],[workages],[workagesSelf],[education],[patient],[hard],[advise],[useID],[add_time])"+
     "VALUES"+
           "('"+_department+"','"+_A1+"','"+_A2+"','"+_A3+"','"+_A4+"','"+_A5+"','"+_A6+"'"+
           ",'"+_B1+"','"+_B2+"','"+_B3+"','"+_B4+"','"+_B5+"','"+_B6+"','"+_B7+"','"+_C1+"','"+_C2+"','"+_C3+"','"+_C4+"','"+_C5+"'"+
           ",'"+_D1+"','"+_D2+"','"+_D3+"','"+_D4+"','"+_D5+"','"+_D6+"','"+_D7+"','"+_D8+"','"+_D9+"','"+_D10+"','"+_E1+"','"+_E2+"','"+_E3+"','"+_E4+"'"+
           ",'"+_F1+"','"+_F2+"','"+_F3+"','"+_F4+"','"+_G1+"','"+_G2+"','"+_G3+"','"+_G4+"','"+_G5+"','"+_G6+"','"+_G7+"','"+_G8+"','"+_G9+"','"+_G10+"'"+
           ",'"+_week+"','"+_mind+"','"+_hour1+"','"+_hour2+"','"+_hour3+"','"+_hour4+"','"+_hour5+"','"+_hour6+"','"+_hour7+"'"+
           ",'"+_safe+"','"+_sex+"','"+_ages+"','"+_leader+"','"+_dan+"','"+_type+"','"+_employee+"','"+_workages+"','"+_workagesSelf+"','"+_education+"'"+
           ",'"+_patient+"','"+_hard+"','"+_advise+"','"+_useID+"','"+_add_time+"')";
        ResultDataSet Rs2 = new ResultDataSet();

        if (db.DBObj.GetRs(sql, out Rs2))
        {
            Response.Write("<script>alert('提交成功！');window.location.href ='Vote.aspx'</script>");
        }
            

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Vote.aspx");
    }
}