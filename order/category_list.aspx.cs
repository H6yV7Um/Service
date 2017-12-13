using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;
using Bright.Data;
using Maticsoft.Common;

public partial class order_category_list : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TreeBind();
        }
        
    }
    #region 绑定类别=================================
    private void TreeBind()
    {
        DataTable dt = GetList2(0);
        this.rptList.DataSource = dt;
        this.rptList.DataBind();
    }
    #endregion
    //美化列表
    protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Literal LitFirst = (Literal)e.Item.FindControl("LitFirst");
            HiddenField hidLayer = (HiddenField)e.Item.FindControl("hidLayer");
            string LitStyle = "<span style=\"display:inline-block;width:{0}px;\"></span>{1}{2}";
            string LitImg1 = "<span class=\"folder-open\"></span>";
            string LitImg2 = "<span class=\"folder-line\"></span>";

            int classLayer = Convert.ToInt32(hidLayer.Value);
            if (classLayer == 1)
            {
                LitFirst.Text = LitImg1;
            }
            else
            {
                LitFirst.Text = string.Format(LitStyle, (classLayer - 2) * 24, LitImg2, LitImg1);
            }
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rptList.Items.Count; i++)
        {
            int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
            CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
            if (cb.Checked)
            {
                Delete(id);
            }
        }
        Response.Redirect("category_list.aspx");
    }
    public bool Delete(int id)
    {
        string sql = "delete from FileType where class_list like '%," + id + ",%'";
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();

        bool result = db.DB2Obj.Exec(sql);
        if (result)
        {
            return true;
        }
        return false;
    }
}