using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using DTcms.DBUtility;
using DTcms.Common;
using System.Data.OleDb;
using System.Collections;
using Bright.Data;
using Maticsoft.Common;

public partial class manager_role_list : BasePage
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
            this.rptList1.DataSource = GetList();
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
            strTemp.Append(" role_name like '%" + _keywords + "%' ");
        }
        return strTemp.ToString();
    }
    #endregion

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        ChkAdminLevel("manager_role", DTEnums.ActionEnum.Delete.ToString()); //检查权限
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
        Response.Redirect("role_list.aspx");
    }

    public bool Delete(int id)
    {
        database_inte db3 = new database_inte();
        string sql3 = "delete from dt_manager_role where id='" + id + "'";
        db3.DB2Obj.Exec(sql3);
        string sql2 = "delete from dt_manager_role_value where role_id='" + id + "'";
        bool result = db3.DB2Obj.Exec(sql2);
        if (result)
        {
            return true;
        }
        return false;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //Response.Redirect(Utils.CombUrlTxt("resultList.aspx", "keywords={0}", txtKeywords.Text));
    }
    /// <summary>
    /// 获得查询分页数据
    /// </summary>
    public DataSet GetList()
    {
        string sql = "select * from dt_manager_role ";
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();
        db.DB2Obj.GetRs(sql, out Rs);
        DataSet dt = ((DataSet)Rs);
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
    #region 返回角色类型名称=========================
    protected string GetTypeName(int role_type)
    {
        string str = "";
        switch (role_type)
        {
            case 1:
                str = "超级用户";
                break;
            default:
                str = "系统用户";
                break;
        }
        return str;
    }
    #endregion
}