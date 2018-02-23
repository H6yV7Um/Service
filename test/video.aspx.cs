using Bright.Data;
using Maticsoft.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test_video : System.Web.UI.Page
{
    database_inte db = new database_inte();
    public string url { get; set; }
    public int movieID { get; set; }
    public DateTime add_time { get; set; }
    public string username { get; set; }
    public string id  { get;set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            id = Request.QueryString["id"];
            if (!String.IsNullOrEmpty(id))
            {
               
                ResultDataSet Rs = new ResultDataSet();
                string strSQL = "select * from Movie where id=" + id;
                db.DB2Obj.GetRs(strSQL, out Rs);
                if (Rs.RowCount > 0)
                {
                    url = Rs[0, "address"].ToString();
                    movieID = Convert.ToInt32(id);
                    username = "8108";
                }
                ChangeConfig();
            }
            else
            {
                Response.Redirect("VideoList.aspx");
            }
            
        }
    }
    public void pauseHandler(string username,int movieID, int state)
    {
        string str = "0";
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();
        DateTime add_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
        string sql = "insert into MovieLog (username,movieID,record_time,state) values('" + username + "'," + movieID + ",'" + add_time + "'," + state + ")";
        if (db.DB2Obj.Exec(sql))
        {
            str = "1";
        }
        else
        {
            str = "0";
        }
    }
    public void ChangeConfig()
    {
        ResultDataSet Rs = new ResultDataSet();
        string strSQL = "select * from MovieLog where username='" + this.username + "' and movieID="+this.id+" and state=1";
        db.DB2Obj.GetRs(strSQL, out Rs);
        if (Rs.RowCount > 0)
        {
            btn_normal.Visible = true;
        }
        else
        {
            btn_normal.Visible = true;
        }
    }
}