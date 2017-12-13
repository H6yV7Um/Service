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
using System.Configuration;

public partial class order_order_list_going : BasePage
{
    database_inte db = new database_inte();
    protected int totalCount;
    protected int page;
    protected int pageSize;
    protected string keywords = string.Empty;
    string _userName = "";
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
            string pageUrl = Utils.CombUrlTxt("order_list_going.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        _userName = Session["user_name"].ToString();
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
        Response.Redirect(Utils.CombUrlTxt("order_list_going.aspx", "", ""));
    }
    public bool Delete(int id)
    {
        string sql = "delete from dt_order where id = '" + id + "'";
        bool result = db.DB2Obj.Exec(sql);
        if (result)
        {
            return true;
        }
        return false;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("order_list_going.aspx", "keywords={0}", txtKeywords.Text));
    }
    /// <summary>
    /// 获得查询分页数据
    /// </summary>
    public DataSet GetList(int channel_id, int category_id, int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
    {
        string sql = ChkGroup("select id,title,address,update_name,update_time, name,telephone,username,add_time,priority,state  from dt_order where state='1'");
        if (strWhere.Trim() != "")
        {
            sql += " and" + strWhere;
        }
        ResultDataSet Rs = new ResultDataSet();
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
        Response.Redirect(Utils.CombUrlTxt("order_list_going.aspx", "", ""));
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
        for (int i = 0; i < rptList1.Items.Count; i++)
        {
            int id = Convert.ToInt32(((HiddenField)rptList1.Items[i].FindControl("hidId")).Value);
            string _add_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            
            string workflow = getUserName(_userName) + "→处理完成" + "    " + _add_time;
            ResultDataSet Rs2 = new ResultDataSet();
            string strSQL = "select child_details from dt_order_child where child_id='" + id + "'";
            db.DB2Obj.GetRs(strSQL, out Rs2);
            CheckBox cb = (CheckBox)rptList1.Items[i].FindControl("chkId");
            if (cb.Checked)
            {
                if (Update(id))
                {
                    if (Rs2.RowCount > 0)
                    {
                        string workflows = Rs2[0, "child_details"].ToString() + "," + getUserName(_userName) + "→处理完成" + "    " + _add_time;
                        string sql = "update dt_order_child set child_details='" + workflows + "' where child_id='" + id + "'";
                        db.DB2Obj.Exec(sql);
                    }
                    else
                    {
                        string sql = "insert into dt_order_child (child_id,child_details,child_user_name) values ('" + id + "','" + workflow + "','" + _userName + "')";
                        db.DB2Obj.Exec(sql);
                    }
                }
                else
                {
                    Response.Write("<script>alert('请确保你是报修人或者和报修人是一个部门');window.location.href ='order_list_going.aspx'</script>");
                    Response.End();
                }
            }
        }
        Response.Redirect("order_list_going.aspx");
    }
    public bool Update(int id)
    {
        string _firstUserName=getOrderUserName(id.ToString())[0];
        string _deptID=getOrderUserName(id.ToString())[1];
        int role_id = Convert.ToInt32(Session["role_id"]);
        if (_userName == _firstUserName || getOADeptID(_userName) == _deptID || role_id < 2 || getGroupIDByUserName(_userName) == getGroupIDByUserName(_firstUserName) || getManagerModel(_userName, "sms") == "1" )
        {
            //&& _userName == getOrderModel(id.ToString(), "update_name"))
            string _date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //string sql = "update dt_order set state=3,update_name='" + _name + "',update_time='"+_date+"' where id='" + id + "'";
            string sql = "update dt_order set state=3 where id='" + id + "'";
            bool result = db.DB2Obj.Exec(sql);
            if (result)
            {
                return true;
            }
            return false;
        }
        else
        {
            
            return false;
        }
        
        
    }
    
    protected void refresh_Click(object sender, EventArgs e)
    {
        Response.Redirect("order_list_going.aspx");
    }
    protected void btnUpdateWC_Click(object sender, EventArgs e)
    {
        ChkAdminLevel("order_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
        for (int i = 0; i < rptList1.Items.Count; i++)
        {

            int id = Convert.ToInt32(((HiddenField)rptList1.Items[i].FindControl("hidId")).Value);
            CheckBox cb = (CheckBox)rptList1.Items[i].FindControl("chkId");
            if (cb.Checked)
            {
                string _NetUrl = ConfigurationManager.AppSettings["NetUrl"].ToString();
                Response.Write("<script>top.location.href='" + string.Format("http://{0}/Page/AutoRun/SendProblem.aspx?Id={1}&cardId={2}", _NetUrl, id.ToString(), Session["user_name"].ToString()) + "'</script>");
                Response.End();
                //Response.Redirect(string.Format("http://{0}/Page/AutoRun/SendProblem.aspx?Id={1}&cardId={2}", _SmsUrl,id.ToString(), Session["user_name"].ToString()));
            }
        }
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
        Response.Redirect("order_list_going.aspx");
    }
    public bool Update_back(int id)
    {
        string sql = "update dt_order set state=2 where id='" + id + "'";
        bool result = db.DB2Obj.Exec(sql);
        if (result)
        {
            return true;
        }
        return false;
    }
}