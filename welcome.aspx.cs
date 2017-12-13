using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBWebService;

public partial class welcome : BasePage
{
    SqlDB db = new SqlDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string sql = ChkGroup("select id from dt_order where state=0");

            Label1.Text = db.getOrderCount(sql).ToString();
            string sql2 = ChkGroup("select id from dt_order where state=1");
            Label2.Text = db.getOrderCount(sql2).ToString();
            string sql3 = ChkGroup("select id from dt_order where state=2");
            Label3.Text = db.getOrderCount(sql3).ToString();
            string sql4 = ChkGroup("select id from dt_order where state=3");
            Label4.Text = db.getOrderCount(sql4).ToString();
        }
    }
    public string getlb1()
    {
        return Label1.Text.ToString()+" 新工单";
    }
    public string getlb2()
    {
        return Label2.Text.ToString() + " 新工单";
    }
    public string getlb3()
    {
        return Label3.Text.ToString() + " 新工单";
    }
    public string getlb4()
    {
        return Label4.Text.ToString() + " 完成工单";
    }
}