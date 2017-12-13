using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bright.Data;
using Maticsoft.Common;
using DBWebService;

public partial class contentEdit : BasePage
{
    SqlDB db = new SqlDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string sql = ChkGroup("select id from dt_order where state=4");
            if (db.getOrderCount(sql) == 0)
            {
                Label1.Text = "";
            }
            else
            {
                Label1.Text = "<span style=\"color:red\">(" + db.getOrderCount(sql).ToString() + ")</span>";
            }
            
        }
    }
    
}