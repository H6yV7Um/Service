using Bright.Data;
using Maticsoft.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test_VideoExam : System.Web.UI.Page
{
    database_inte db = new database_inte();
    public static double ZonnFenShu = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            ResultDataSet Rs = new ResultDataSet();
            string strSQL = "select * from Movie_QuestionBank where QuestionsType='单选' and MovieID="+id+" ";
            db.DB2Obj.GetRs(strSQL, out Rs);
            DataSet ds = ((DataSet)Rs);
            this.GridView1.DataSource = ds;
            this.GridView1.DataBind();


            ResultDataSet Rs2 = new ResultDataSet();
            string strSQL2 = "select * from Movie_QuestionBank where QuestionsType='多选' and MovieID=" + id + " ";
            db.DB2Obj.GetRs(strSQL2, out Rs2);
            DataSet ds2 = ((DataSet)Rs2);
            this.GridView2.DataSource = ds2;
            this.GridView2.DataBind();

        }



    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //string stype = Request.QueryString["ID"].ToString();

        double FenShu = 0.0;
        string Error = "";
        //单选
        foreach (GridViewRow dr in GridView1.Rows)//对单选题每题进行判断用户选择答案
        {
            string title = ((Label)dr.FindControl("Label2")).Text;
            string Answer = ((Label)dr.FindControl("Label3")).Text;
            string ID = ((Label)dr.FindControl("Label1")).Text;
            string str = "";
            if (((RadioButton)dr.FindControl("RadioButton1")).Checked)
            {
                str = "A";
            }
            else if (((RadioButton)dr.FindControl("RadioButton2")).Checked)
            {
                str = "B";
            }
            else if (((RadioButton)dr.FindControl("RadioButton3")).Checked)
            {
                str = "C";
            }
            else if (((RadioButton)dr.FindControl("RadioButton4")).Checked)
            {
                str = "D";
            }
            if (((Label)dr.FindControl("Label3")).Text.Trim() == str)//将用户选择结果和答案进行比较
            {
                FenShu = FenShu + 1;


            }
            else
            {
                Response.Write("<script>javascript:alert( '" + title + " 错误');</script>");
                //string SQL1 = "insert into TB_CuoTi(TID,UserName,MyDanAN ) values('" + ID + "','" + Session["username"].ToString() + "','" + str + "')";
                //DBHelper.ExecSql(SQL1);  
                DateTime add_time1 = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                string sql1 = "insert into Movie_CuoTi (QBID,username,MovieID,answer) values(" + ID + ",'8108'," + 1000 + ",'" + str + "','" + add_time1 + "')";
                db.DB2Obj.Exec(sql1);
            }
        }

        //对多选题每题进行判断用户选择答案

        foreach (GridViewRow dr2 in GridView2.Rows)
        {
            string title = ((Label)dr2.FindControl("Label6")).Text;
            string Answer2 = ((Label)dr2.FindControl("Label7")).Text.Trim();
            string ID = ((Label)dr2.FindControl("Label1")).Text;
            string strs = "";

            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";

            if (((CheckBox)dr2.FindControl("CheckBox1")).Checked)
            {
                str1 = "A";
            }
            if (((CheckBox)dr2.FindControl("CheckBox2")).Checked)
            {
                str2 = "B";
            }
            if (((CheckBox)dr2.FindControl("CheckBox3")).Checked)
            {
                str3 = "C";
            }
            if (((CheckBox)dr2.FindControl("CheckBox4")).Checked)
            {
                str4 = "D";
            }
            if (((CheckBox)dr2.FindControl("CheckBox5")).Checked)
            {
                str5 = "E";
            }
            strs = str1 + str2 + str3 + str4 + str5;
            if (((Label)dr2.FindControl("Label7")).Text.Trim() == strs)//将用户选择结果和答案进行比较
            {

                FenShu = FenShu + 1;
            }
            else
            {
                Response.Write("<script>javascript:alert( '" + title + " 错误');</script>");
                //string SQL1 = "insert into TB_CuoTi(TID,UserName,MyDanAN ) values('" + ID + "','" + Session["username"].ToString() + "','" + strs + "')";
                //DBHelper.ExecSql(SQL1);
                DateTime add_time1 = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                string sql1 = "insert into Movie_CuoTi (QBID,username,MovieID,answer) values(" + ID + ",'8108'," + 1000 + ",'" + strs + "','" + add_time1 + "')";
                db.DB2Obj.Exec(sql1);
            }




        }

        //string sql = "insert into TB_ChengJi(Xuehao ,KeMu,ChengJi) values('" + Session["username"].ToString() + "','" + stype + "','" + FenShu + "')";
        //DBHelper.ExecSql(sql);
        DateTime add_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
        string sql = "insert into Movie_Score (username,movieID,score,add_time) values('8108'," + 1000+",'" + FenShu + "','" + add_time + "')";
        db.DB2Obj.Exec(sql);
        //Response.Write("<script>window.showModalDialog('VideoList.aspx')</script>");
        Response.Write("<script>javascript:alert( '您的得分为：" + FenShu + "');window.location='VideoList.aspx'</script>");
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        

    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}