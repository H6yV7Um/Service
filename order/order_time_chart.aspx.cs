using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bright.Data;
using Maticsoft.Common;
using System.Data;

public partial class order_order_time_chart : System.Web.UI.Page
{
    public string returnValue = "";
    public string containerHeight = "400px";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            setValue("8");
        }

    }
    public void setValue(string days)
    {
        int role_id = Convert.ToInt32(Session["role_id"]);
        int group_id = Convert.ToInt32(Session["group_id"]);
        string _username = Session["user_name"].ToString();
        string sql;
        if (role_id > 1)
        {
            sql = "select convert(varchar(10),add_time,3 ) tdate,sum(case when state = 0 then 1 else 0 end) as total2,count(state) as total  from dt_order where DateDiff(day,add_time,getdate())<'" + days + "'  and (username='" + _username + "' or update_name='" + _username + "') group by convert(varchar(10),add_time,3 ) order by tdate asc";
        }
        else
        {
            sql = "select convert(varchar(10),add_time,3 ) tdate,sum(case when state = 0 then 1 else 0 end) as total2,count(state) as total  from dt_order where DateDiff(day,add_time,getdate())<'" + days + "' group by convert(varchar(10),add_time,3 ) order by tdate asc";
        }
        
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();
        if (db.DB2Obj.GetRs(sql, out Rs))
        {
            DataTable dt = ((DataSet)Rs).Tables[0];
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 4)
                {
                    containerHeight = (dt.Rows.Count * 50).ToString() + "px";
                }
                else
                {
                    containerHeight = "200px";
                }
                string dataY = "[{name: '工单总数量',data: [";
                foreach (DataRow dr in dt.Rows)
                {
                    dataY += "['" + dr["tdate"].ToString() + "'," + dr["total"].ToString() + "]" + ",";
                }
                returnValue = dataY + "]";
            }
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string s=DropDownList1.SelectedValue;
        if (s == "0")
        {
            setValue("8");
        }
        else
        {
            setValue("31");
        }
    }
}