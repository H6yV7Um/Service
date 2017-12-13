using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bright.Data;
using Maticsoft.Common;
using System.Data;

public partial class order_order_type_chart : BasePage
{
    public string returnValue = "";
    public string containerHeight = "400px";
    protected void Page_Load(object sender, EventArgs e)
    {

        string sql = "select type,sum(case when state = 0 then 1 else 0 end) as total1,sum(case when state = 1 then 1 else 0 end) as total2,sum(case when state = 2 then 1 else 0 end) as total3,sum(case when state = 3 then 1 else 0 end) as total4,count(state) as total from dt_order where 1=1 group by type";
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
                    dataY += "['" + getGroupName(dr["type"].ToString()) + "'," + dr["total"].ToString() + "]" + ",";
                }
                returnValue = dataY + "]";
            }
        }

    }
}