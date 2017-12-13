using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bright.Data;
using Maticsoft.Common;
using System.Data;

public partial class order_order_people_chart : BasePage
{
    public string returnValue = "";
    public string containerHeight = "400px";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            getCBList();
            getChart(getUserNameList(),beginTime.Text.ToString(),endTime.Text.ToString());
        }
        

    }
    public void getChart(string _array,string begin,string end)
    {
        string groupID = Session["group_id"].ToString();
        string array = _array;
        string sql = "";
        if (String.IsNullOrEmpty(begin) && String.IsNullOrEmpty(end))
        {
            sql = "select update_name,sum(case when state = 3 then 1 else 0 end) as total  from dt_order where update_name in(" + array + ")  group by update_name ";
        }
        else
        {
            sql = "select update_name,sum(case when state = 3 then 1 else 0 end) as total  from dt_order where update_time >= '" + begin + "' and update_time <= '" + end + "' and update_name in(" + array + ")  group by update_name ";
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
                    dataY += "['" + getUserName(dr["update_name"].ToString()) + "'," + dr["total"].ToString() + "]" + ",";
                }
                returnValue = dataY + "]";
            }
        }
    }
    public void getChart()
    {
        string groupID = Session["group_id"].ToString();
        string sql = "select update_name,sum(case when state = 3 then 1 else 0 end) as total  from dt_order where group_id like '%" + groupID + "' group by update_name ";
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
                    dataY += "['" + getUserName(dr["update_name"].ToString()) + "'," + dr["total"].ToString() + "]" + ",";
                }
                returnValue = dataY + "]";
            }
        }
    }
    public void getCBList()
    {
        string groupID = Session["group_id"].ToString();
        string strSQL = "select * from dt_manager where group_id like '%"+groupID+"' ";
        ResultDataSet Rs2 = new ResultDataSet();
        database_inte db2 = new database_inte();
        db2.DB2Obj.GetRs(strSQL, out Rs2);
        if (Rs2.RowCount>0)
        {
            DataTable dt = ((DataSet)Rs2).Tables[0];
            CheckBoxList1.DataSource = dt.DefaultView;
            CheckBoxList1.DataTextField = "real_name";
            CheckBoxList1.DataValueField = "user_name";
            CheckBoxList1.DataBind();
        }

    }
    public string getUserNameList()
    {
        string array = "";
        string groupID = Session["group_id"].ToString();
        string strSQL = "select * from dt_manager where group_id like '%" + groupID + "' ";
        ResultDataSet Rs2 = new ResultDataSet();
        database_inte db2 = new database_inte();
        db2.DB2Obj.GetRs(strSQL, out Rs2);
        DataTable dt = ((DataSet)Rs2).Tables[0];
        if (Rs2.RowCount > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (array == "")
                {
                    array = "'" + dr["user_name"].ToString() + "'";
                }
                else
                {
                    array += "," + "'" + dr["user_name"].ToString() + "'";
                }
            }
        }
        return array;
    }
    protected void lbtnSearch_Click(object sender, EventArgs e)
    {
        string array = "";
        for (int i = 0; i < this.CheckBoxList1.Items.Count; i++)
        {
            if (this.CheckBoxList1.Items[i].Selected == true)
            {
                if (array == "")
                {
                    array = "'"+this.CheckBoxList1.Items[i].Value+"'";
                }
                else
                {
                    array += "," + "'" + this.CheckBoxList1.Items[i].Value + "'";
                }
            }
        }
        getChart(array, beginTime.Text.ToString(),endTime.Text.ToString());
    }
}