using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using System.Data;
using Bright.Data;
using Maticsoft.Common;
using System.Collections;
using System.Text;
using DTcms.DBUtility;
using System.Data.OleDb;

public partial class order_order_list_group : BasePage
{
    protected int totalCount;
    protected int page;
    protected int pageSize;
    protected string keywords = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.keywords = DTRequest.GetQueryString("keywords");
        this.pageSize = GetPageSize(10); //每页数量
        this.page = DTRequest.GetQueryInt("page", 1);
        if (!Page.IsPostBack)
        {
            this.txtKeywords.Text = this.keywords;
            this.rptList1.DataSource = GetList(0, 0, this.pageSize, this.page, CombSqlTxt(this.keywords, ""), "", out this.totalCount);
            this.rptList1.DataBind();
        }
    }

    #region 组合SQL查询语句==========================
    protected string CombSqlTxt(string _keywords, string _property)
    {
        StringBuilder strTemp = new StringBuilder();
        _keywords = _keywords.Replace("'", "");
        if (!string.IsNullOrEmpty(_keywords))
        {
            strTemp.Append(" update_name = '" + _keywords + "'");
        }
        return strTemp.ToString();
    }
    #endregion

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        //ChkAdminLevel("order_list", DTEnums.ActionEnum.Delete.ToString()); //检查权限
        int sucCount = 0; //成功数量
        int errorCount = 0; //失败数量
        for (int i = 0; i < rptList1.Items.Count; i++)
        {
            int id = Convert.ToInt32(((HiddenField)rptList1.Items[i].FindControl("hidId")).Value);
            CheckBox cb = (CheckBox)rptList1.Items[i].FindControl("chkId");
            if (cb.Checked)
            {
                if (Delete(id))
                {
                    sucCount++;
                }
                else
                {
                    errorCount++;
                }
            }
        }
        Response.Redirect(Utils.CombUrlTxt("order_list_group.aspx", "", ""));
    }
    public bool Delete(int id)
    {
        string sql = "delete from dt_order where id = '" + id + "'";
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();

        bool result = db.DB2Obj.Exec(sql);
        if (result)
        {
            return true;
        }
        return false;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("order_list_group.aspx", "keywords={0}", txtKeywords.Text));
        
    }
    /// <summary>
    /// 获得查询分页数据
    /// </summary>
    public DataSet GetList(int channel_id, int category_id, int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
    {
        string sql = "select update_name,sum(case when state = 0 then 1 else 0 end) as total1,sum(case when state = 1 then 1 else 0 end) as total2,sum(case when state = 2 then 1 else 0 end) as total3,sum(case when state = 3 then 1 else 0 end) as total4,count(state) as total from dt_order where 1=1";
        if (strWhere.Trim() != "")
        {
            sql += " and" + strWhere + " group by update_name order by total desc";
        }
        else
        {
            sql += " group by update_name order by total desc";
        }
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();
        db.DB2Obj.GetRs(sql, out Rs);
        recordCount = Rs.RowCount;
        string _sql = PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, sql.ToString(), filedOrder);
        ResultDataSet Rs2 = new ResultDataSet();
        db.DB2Obj.GetRs(sql, out Rs2);
        DataSet dt = ((DataSet)Rs2);
        return dt;
    }

    #region 返回图文每页数量=========================
    private int GetPageSize(int _default_size)
    {
        int _pagesize;
        if (int.TryParse(Utils.GetCookie("article_page_size"), out _pagesize))
        {
            if (_pagesize > 0)
            {
                return _pagesize;
            }
        }
        return _default_size;
    }
    #endregion
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //ChkAdminLevel("order_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
        int sucCount = 0; //成功数量
        int errorCount = 0; //失败数量
        for (int i = 0; i < rptList1.Items.Count; i++)
        {
            int id = Convert.ToInt32(((HiddenField)rptList1.Items[i].FindControl("hidId")).Value);
            CheckBox cb = (CheckBox)rptList1.Items[i].FindControl("chkId");
            if (cb.Checked)
            {
                if (Update(id))
                {
                    sucCount++;
                }
                else
                {
                    errorCount++;
                }
            }
        }
        //Response.Write("<script>alert('修改成功！');window.location.href ='order_list_group.aspx'</script>");
        Response.Redirect("order_list_group.aspx");
    }
    public bool Update(int id)
    {
        string sql = "update dt_order set state=1 where id='" + id + "'";
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();
        bool result = db.DB2Obj.Exec(sql);
        if (result)
        {
            return true;
        }
        return false;
    }
    protected void refresh_Click(object sender, EventArgs e)
    {
        Response.Redirect("order_list_group.aspx");
    }
}