using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using Bright.Data;
using Maticsoft.Common;
using System.Data;

public partial class dialog_dialog_accept : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RoleBind();
        }
    }
    #region 人员列表=================================
    private void RoleBind()
    {
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();
        string strSQL = "select * from dt_manager ";
        db.DB2Obj.GetRs(strSQL, out Rs);
        DataTable dt = ((DataSet)Rs).Tables[0];
        if (Rs.RowCount > 0)
        {
            ddlRoleId.Items.Clear();
            ddlRoleId.Items.Add(new ListItem("请选择人员...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                ddlRoleId.Items.Add(new ListItem(dr["real_name"].ToString(), dr["user_name"].ToString()));
            }
        }

    }
    #endregion
}