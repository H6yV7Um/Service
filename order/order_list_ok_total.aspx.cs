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

public partial class order_order_list_ok_total : BasePage
{
    protected int totalCount;
    protected int page;
    protected int pageSize;
    protected string keywords = string.Empty;
    protected string category_id;
    protected string begin = string.Empty;
    protected string end = string.Empty;
    protected string state = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.keywords = DTRequest.GetQueryString("keywords");
        this.begin = DTRequest.GetQueryString("begin");
        this.end = DTRequest.GetQueryString("end");
        this.category_id = DTRequest.GetQueryString("category_id");
        this.pageSize = GetPageSize(10); //每页数量
        this.page = DTRequest.GetQueryInt("page", 1);
        this.state = DTRequest.GetQueryString("state");
        if (!Page.IsPostBack)
        {
            TreeBind();
            //getDropdownlist(this.ddlCategoryId, "select * from dt_type_list","全院","typeID","typeName");
            ddlState.Items.Add(new ListItem("全部状态", ""));
            ddlState.Items.Add(new ListItem("待处理", "10"));
            ddlState.Items.Add(new ListItem("处理中", "1"));
            ddlState.Items.Add(new ListItem("驳回", "2"));
            ddlState.Items.Add(new ListItem("待确认", "4"));
            ddlState.Items.Add(new ListItem("已完成", "3"));
            if (this.category_id !="")
            {
                this.ddlCategoryId.SelectedValue = this.category_id.ToString();
            }
            if (this.state != "")
            {
                this.ddlState.SelectedValue = this.state.ToString();
            }
            this.txtKeywords.Text = this.keywords;
            this.beginTime.Text = this.begin;
            this.endTime.Text = this.end;
            this.rptList1.DataSource = GetList(0, this.category_id, this.pageSize, this.page, CombSqlTxt(this.keywords, ""), "  id desc", out this.totalCount);
            this.rptList1.DataBind();
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("order_list_ok_total.aspx", "keywords={0}&category_id={1}&page={2}&begin={3}&end={4}&state={5}", this.keywords, this.category_id.ToString(), "__id__", this.begin, this.end,this.state.ToString());
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
    }
    #region 绑定类别=================================
    private void TreeBind()
    {
        DataTable dt = GetList(0);
        this.ddlCategoryId.Items.Clear();
        this.ddlCategoryId.Items.Add(new ListItem("全院", ""));
        foreach (DataRow dr in dt.Rows)
        {
            string Id = dr["id"].ToString();
            string TypeID = dr["typeID"].ToString();
            int ClassLayer = Convert.ToInt32(dr["class_layer"].ToString());
            string Title = dr["typeName"].ToString().Trim();

            if (ClassLayer == 1)
            {
                this.ddlCategoryId.Items.Add(new ListItem(Title, TypeID));
            }
            else
            {
                Title = "├ " + Title;
                Title = Utils.StringOfChar(ClassLayer - 1, "　") + Title;
                this.ddlCategoryId.Items.Add(new ListItem(Title, TypeID));
            }
        }
    }
    #endregion
    #region 组合SQL查询语句==========================
    protected string CombSqlTxt(string _keywords, string _property)
    {
        StringBuilder strTemp = new StringBuilder();
        _keywords = _keywords.Replace("'", "");
        if (!string.IsNullOrEmpty(_keywords))
        {
            strTemp.Append(" (title like '%" + _keywords + "%' or update_name like '%" + _keywords + "%')");
        }
        return strTemp.ToString();
    }
    #endregion
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        ChkAdminLevel("order_list", DTEnums.ActionEnum.Delete.ToString()); //检查权限
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
        JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("Repeater.aspx", "", ""), "Success");
        Response.Redirect(Utils.CombUrlTxt("order_list_ok_total.aspx", "", ""));
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
        Response.Redirect(Utils.CombUrlTxt("order_list_ok_total.aspx", "keywords={0}&begin={1}&end={2}&category_id={3}&state={4}", txtKeywords.Text, beginTime.Text, endTime.Text, this.ddlCategoryId.SelectedValue,this.ddlState.SelectedValue));
    }
    /// <summary>
    /// 获得查询分页数据
    /// </summary>
    public DataSet GetList(int channel_id, string category_id, int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
    {
        string sql = "select * from dt_order where 1=1 ";
        if (strWhere.Trim() != "")
        {
            sql += " and" + strWhere;
        }
        if (this.begin != "" && this.end != "")
        {
            sql += " and add_time >= '"+this.begin+" 00:00:00' and add_time <='"+this.end+" 23:59:59'";
        }
        if (category_id !="")
        {
            sql += " and group_id like '" + category_id + "%'";
        }
        if (state != "")
        {
            if (state == "10")
            {
                sql += " and state = '0'";
            }
            else
            {
                sql += " and state = '" + state + "'";
            }
            
        }
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();
        db.DB2Obj.GetRs(sql, out Rs);
        recordCount = Rs.RowCount;
        string _sql = PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, sql.ToString(), filedOrder);
        ResultDataSet Rs2 = new ResultDataSet();
        db.DB2Obj.GetRs(_sql, out Rs2);
        DataSet dt = ((DataSet)Rs2);
        return dt;
    }
    public DataTable GetListNoPage(int channel_id, string category_id, int pageSize, int pageIndex, string strWhere, string filedOrder)
    {
        string sql = "select * from dt_order where 1=1 ";
        if (strWhere.Trim() != "")
        {
            sql += " and" + strWhere;
        }
        if (this.begin != "" && this.end != "")
        {
            sql += " and add_time >= '" + this.begin + " 00:00:00' and add_time <='" + this.end + " 23:59:59'";
        }
        if (category_id != "")
        {
            sql += " and group_id like '" + category_id + "%'";
        }
        if (state != "")
        {
            if (state == "10")
            {
                sql += " and state = '0'";
            }
            else
            {
                sql += " and state = '" + state + "'";
            }

        }
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();
        db.DB2Obj.GetRs(sql, out Rs);
        DataTable dt = ((DataSet)Rs).Tables[0];
        return dt;
    }
    protected void txtPageNum_TextChanged(object sender, EventArgs e)
    {
        int _pagesize;
        if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
        {
            if (_pagesize > 0)
            {
                Utils.WriteCookie("article_page_size", _pagesize.ToString(), 43200);
            }
        }
        Response.Redirect(Utils.CombUrlTxt("order_list_ok_total.aspx", "", ""));
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
        ChkAdminLevel("order_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
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
        //Response.Write("<script>alert('修改成功！');window.location.href ='order_list_going.aspx'</script>");
        Response.Redirect("order_list_ok_total.aspx");
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
        Response.Redirect("order_list_ok_total.aspx");
    }
    protected void btnComment_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rptList1.Items.Count; i++)
        {
            int id = Convert.ToInt32(((HiddenField)rptList1.Items[i].FindControl("hidId")).Value);
            CheckBox cb = (CheckBox)rptList1.Items[i].FindControl("chkId");
            if (cb.Checked)
            {
                Response.Write("<script>alert('成功!'+'" + id + "')</script>");
            }
        }
    }
    protected void ddlCategoryId_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("order_list_ok_total.aspx", "keywords={0}&begin={1}&end={2}&category_id={3}&state={4}", txtKeywords.Text, beginTime.Text, endTime.Text, this.ddlCategoryId.SelectedValue, this.ddlState.SelectedValue));
    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("order_list_ok_total.aspx", "keywords={0}&begin={1}&end={2}&category_id={3}&state={4}", txtKeywords.Text, beginTime.Text, endTime.Text, this.ddlCategoryId.SelectedValue,this.ddlState.SelectedValue));
    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        DataTable dt = GetListNoPage(0, this.category_id, this.pageSize, this.page, CombSqlTxt(this.keywords, ""), "  id desc");
        rptList1.DataSource = dt;
        rptList1.DataBind();
        ReportToExcel(rptList1,"工单统计.xls");
    }
    
}