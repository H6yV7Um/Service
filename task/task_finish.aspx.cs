using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bright.Data;
using Maticsoft.Common;

public partial class task_task_finish : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strhtml = "";
        string dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string _empid = Session["user_name"].ToString();
        string strSQL = "select *,datediff(day,Task_starttime,Task_endtime)as Task_totaldays,datediff(day,Task_starttime,getdate())as Task_currentdays from T_task where (Task_empid='" + _empid + "' or receive_name='" + _empid + "') and Task_finishstate=1 order by Task_id desc";
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();
        db.DB3Obj.GetRs(strSQL, out Rs);
        if (Rs.RowCount > 0)
        {
            for (int i = 0; i < Rs.RowCount; i++)
            {
                    strhtml += "<div class=\"div_content\">" +
                        "<p class=\"p1\"><span class=\"sp_name\">" + getUserName(Rs[i, "receive_name"].ToString()) + "</span><span class=\"sp_edate\">结束时间：" + Rs[i, "Task_endtime"].ToString() + "</span><span class=\"sp_sdate\">开始时间：" + Rs[i, "Task_starttime"].ToString() + "</span></p>" +
    "<p class=\"p_title\">任务标题:<span>" + Rs[i, "Task_title"].ToString() + "</span></p>" +
    "<p class=\"p_content\">任务内容：<span>" + Rs[i, "Task_content"].ToString() + "</span></p>" +
   "</div>";

            }
        }
        else
        {
            strhtml = "<p>暂无任务</p>";
        }
        div_list.InnerHtml = strhtml;
    }
}