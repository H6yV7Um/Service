using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bright.Data;
using Maticsoft.Common;

public partial class task_task_handle : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strhtml = "";
        string dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string _empid = Session["user_name"].ToString();
        string strSQL = "select *,datediff(day,Task_starttime,Task_endtime)as Task_totaldays,datediff(day,Task_starttime,getdate())as Task_currentdays from T_task where (Task_empid='" + _empid + "' or receive_name='" + _empid + "') and Task_handlestate=1 and Task_finishstate=0 order by Task_id desc";
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();
        db.DB3Obj.GetRs(strSQL, out Rs);
        if (Rs.RowCount > 0)
        {
            for (int i = 0; i < Rs.RowCount; i++)
            {
                if (Convert.ToDateTime(Rs[i, 4]) < Convert.ToDateTime(dt))
                {
                    strhtml += "<div class=\"div_content\">" +
                        "<div id='" + Rs[i, "Task_id"].ToString() + "' class=\"easyui-progressbar\" style=\"width:100%;\"></div>" +
    "<script type=\"text/javascript\">$(document).ready(function () { var currentdays=" + Rs[i, "Task_currentdays"].ToString() + "; var totaldays=" + Rs[i, "Task_totaldays"].ToString() + ";var value = $('#" + Rs[i, "Task_id"].ToString() + "').progressbar('getValue');if (value < 100) {value = Math.floor(currentdays * 100 / totaldays);$('#" + Rs[i, "Task_id"].ToString() + "').progressbar('setValue', value);setTimeout(arguments.callee, 200);}}); </script> " +
                        "<p class=\"p1\"><span class=\"sp_name\" style=\"color:red\">" + getUserName(Rs[i, "receive_name"].ToString()) + "（已超时）</span><span class=\"sp_edate\">结束时间：" + Rs[i, "Task_endtime"].ToString() + "</span><span class=\"sp_sdate\">开始时间：" + Rs[i, "Task_starttime"].ToString() + "</span><span class=\"tijiao\"><a href=\"submit.aspx?taskid=" + Rs[i, "Task_id"].ToString() + "\" onclick=\"return confirm('确定提交任务吗?');\">提交</a></span></p>" +
    "<p class=\"p_title\">任务标题:<span>" + Rs[i, "Task_title"].ToString() + "</span></p>" +
    "<p class=\"p_content\">任务内容：<span>" + Rs[i, "Task_content"].ToString() + "</span></p>" +
   "</div>";
                }
                else
                {
                    strhtml += "<div class=\"div_content\">" +
                        "<div id='" + Rs[i, "Task_id"].ToString() + "' class=\"easyui-progressbar\" style=\"width:100%;\"></div>" +
    "<script type=\"text/javascript\">$(document).ready(function () { var currentdays=" + Rs[i, "Task_currentdays"].ToString() + "; var totaldays=" + Rs[i, "Task_totaldays"].ToString() + ";var value = $('#" + Rs[i, "Task_id"].ToString() + "').progressbar('getValue');if (value < 100) {value = Math.floor(currentdays * 100 / totaldays);$('#" + Rs[i, "Task_id"].ToString() + "').progressbar('setValue', value);setTimeout(arguments.callee, 200);}}); </script> " +
                        "<p class=\"p1\"><span class=\"sp_name\">" + getUserName(Rs[i, "receive_name"].ToString()) + "</span><span class=\"sp_edate\">结束时间：" + Rs[i, "Task_endtime"].ToString() + "</span><span class=\"sp_sdate\">开始时间：" + Rs[i, "Task_starttime"].ToString() + "</span><span class=\"tijiao\"><a href=\"submit.aspx?taskid=" + Rs[i, "Task_id"].ToString() + "\" onclick=\"return confirm('确定提交任务吗?');\">提交</a></span></p>" +
    "<p class=\"p_title\">任务标题:<span>" + Rs[i, "Task_title"].ToString() + "</span></p>" +
    "<p class=\"p_content\">任务内容：<span>" + Rs[i, "Task_content"].ToString() + "</span></p>" +
   "</div>";

                }
            }
        }
        else
        {
            strhtml = "<p>暂无处理中任务</p>";
        }
        div_list.InnerHtml = strhtml;
    }
}