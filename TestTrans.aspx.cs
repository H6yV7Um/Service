using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bright.Data;
using Maticsoft.Common;

public partial class TestTrans : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string fileName = "文件名";
        ResultDataSet Rs2 = new ResultDataSet();
        database_inte db2 = new database_inte();

        ClsData dbobj = db2.DB2Obj;

        dbobj.BeginTrans("test");
        string sql1 = "insert into FileInfo (fileName,fileSize) values ('" + fileName + "','50')";
        string sql2 = "insert into FileType (typeName,parentID) values ('标题',0)";
        if (!dbobj.GetRs(sql1, out Rs2))
        {
            dbobj.RollBack("test");
            return;
        }
        if (!dbobj.GetRs(sql2, out Rs2))
        {
            dbobj.RollBack("test");
            Label1.Text = "失败";
            return;
        }
        if (dbobj.CommitTrans("test") == false)
        {
            dbobj.RollBack("test");
            Label1.Text = "失败";
            return;
        }

        Label1.Text = "成功";
    }
}