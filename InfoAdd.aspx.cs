using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bright.Data;
using Maticsoft.Common;

public partial class InfoAdd : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = getUserName(Session["user_name"].ToString());
    }
    
}