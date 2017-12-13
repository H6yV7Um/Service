using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bright.Data;
using Maticsoft.Common;
using System.Data;

public partial class task_task_add :BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getDropdownlist(); 
        }
    }

    /// <summary>
    /// 获取类型下拉菜单
    /// </summary>
    public void getDropdownlist()
    {
        //string group_id = Session["group_id"].ToString();
        string strSQL = "select user_name,real_name from dt_manager where group_id like '00%' ";
        ResultDataSet Rs2 = new ResultDataSet();
        database_inte db2 = new database_inte();
        if (db2.DB2Obj.GetRs(strSQL, out Rs2))
        {
            DataTable dt = ((DataSet)Rs2).Tables[0];
            dp_pp.DataSource = dt.DefaultView;
            dp_pp.DataTextField = "real_name";
            dp_pp.DataValueField = "user_name";
            dp_pp.DataBind();
            dp_pp.Items.Insert(0, new ListItem("请选择人员", "0"));
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string strSQL, _title, _content, _start, _end, _empid,_receiveName;
        _empid = Session["user_name"].ToString();
        _title = task_title.Text;
        _content = task_content.Text;
        _start = task_start.Text;
        _end = tast_end.Text;
        string _add_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        _receiveName = dp_pp.SelectedValue;
        strSQL = "insert into T_task (Task_title,Task_content,Task_starttime,Task_endtime,Task_empid,Task_handlestate,Task_receivestate,Task_finishstate,Task_state,add_time,receive_name)values" + "('" + _title + "','" + _content + "','" + _start + "','" + _end + "','" + _empid + "',0,0,0,0,'" + _add_time + "','" + _receiveName + "');SELECT  @@IDENTITY as ID";
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();
        if (db.DB3Obj.GetRs(strSQL, out Rs) == true)
        {
            if (Rs.RowCount > 0)
            {
                Response.Write("<script>alert('提交成功!');window.location.href ='task_add.aspx'</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('提交失败!');window.location.href ='task_add.aspx'</script>");
            return;
        }
    }
    
}