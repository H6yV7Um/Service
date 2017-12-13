using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bright.Data;
using Maticsoft.Common;

public partial class task_submit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request["taskid"]);
        string _add_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string strSQL = "update T_task set Task_finishstate=1,submit_time='"+_add_time+"' where Task_id=" + id;
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();
        db.DB3Obj.GetRs(strSQL, out Rs);
        Response.Redirect("task_handle.aspx");
    }
}