﻿using System;
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

public partial class order_order_list_person : BasePage
{
    protected int totalCount;
    protected int page;
    protected int pageSize;
    protected string keywords = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.keywords = DTRequest.GetQueryString("keywords");
        this.pageSize = GetPageSize(8); //每页数量
        this.page = DTRequest.GetQueryInt("page", 1);
        if (!Page.IsPostBack)
        {
            this.txtKeywords.Text = this.keywords;
            this.rptList1.DataSource = GetList(0, 0, this.pageSize, this.page, CombSqlTxt(this.keywords, ""), "  id asc", out this.totalCount);
            this.rptList1.DataBind();
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("order_list_person.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
    }

    #region 组合SQL查询语句==========================
    protected string CombSqlTxt(string _keywords, string _property)
    {
        StringBuilder strTemp = new StringBuilder();
        _keywords = _keywords.Replace("'", "");
        if (!string.IsNullOrEmpty(_keywords))
        {
            strTemp.Append(" (title like '%" + _keywords + "%' or username like '%" + _keywords + "%')");
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
        Response.Redirect(Utils.CombUrlTxt("order_list_person.aspx", "", ""));
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
        Response.Redirect(Utils.CombUrlTxt("order_list_person.aspx", "keywords={0}", txtKeywords.Text));
    }
    /// <summary>
    /// 获得查询分页数据
    /// </summary>
    public DataSet GetList(int channel_id, int category_id, int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
    {
        string sql="";
        int role_id = Convert.ToInt32(Session["role_id"]);
        if (role_id > 1)
        {
            sql = ChkGroup("select * from dt_order A inner join dt_order_child B on A.id=B.child_id where B.child_user_name='" + Session["user_name"].ToString() + "'");
        }
        else
        {
            sql = ChkGroup("select * from dt_order A inner join dt_order_child B on A.id=B.child_id where 1=1");
            
        }
        if (strWhere.Trim() != "")
        {
            sql += " and" + strWhere;
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
        Response.Redirect(Utils.CombUrlTxt("order_list_person.aspx", "", ""));
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
            string _add_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string _userName = Session["user_name"].ToString();
            ResultDataSet Rs2 = new ResultDataSet();
            database_inte db2 = new database_inte();
            string strSQL = "select * from dt_order_child where child_id='" + id + "'";
            db2.DB2Obj.GetRs(strSQL, out Rs2);
            if (Rs2.RowCount > 0)
            {
                string workflows = Rs2[0, "child_details"].ToString() + "," + getUserName(_userName) + "→进行处理" + "    " + _add_time;
                string sql = "update dt_order_child set child_details='" + workflows + "' where child_id='" + id + "'";
                db2.DB2Obj.Exec(sql);
            }
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
        //Response.Write("<script>alert('修改成功！');window.location.href ='order_list_person.aspx'</script>");
        Response.Redirect("order_list_person.aspx");
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
   
    
    
    protected void btn_Back_Click(object sender, EventArgs e)
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
                if (Update_back(id))
                {
                    sucCount++;
                }
                else
                {
                    errorCount++;
                }
            }
        }
        //Response.Write("<script>alert('修改成功！');window.location.href ='order_list_person.aspx'</script>");
        Response.Redirect("order_list_person.aspx");
    }
    public bool Update_back(int id)
    {
        string sql = "update dt_order set state=2 where id='" + id + "'";
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