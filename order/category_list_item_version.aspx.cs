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
using Dln.Common;
using System.IO;
using DTcms.Web.UI;

public partial class order_category_list_item_version : BasePage
{
    protected string id;
    protected int totalCount;
    protected int page;
    protected int pageSize;
    protected string keywords = string.Empty;
    string _userName = "";
    database_inte db = new database_inte();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.id = DTRequest.GetQueryString("id");
        this.keywords = DTRequest.GetQueryString("keywords");
        //this.pageSize = GetPageSize(8); //每页数量
        this.page = DTRequest.GetQueryInt("page", 1);
        if (!Page.IsPostBack)
        {
            
            this.txtKeywords.Text = this.keywords;
            this.rptList1.DataSource = GetList(this.id, 0, this.pageSize, this.page, CombSqlTxt(this.keywords, ""), "  id desc", out this.totalCount);
            this.rptList1.DataBind();
            //绑定页码
            //txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("order_list.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
            //PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        _userName = Session["user_name"].ToString();
    }
    /// <summary>
    /// 转换方法
    /// </summary>
    /// <param name="size">字节值</param>
    /// <returns></returns>
    public String HumanReadableFilesize(double size)
    {
        String[] units = new String[] { "B", "KB", "MB", "GB", "TB", "PB" };
        double mod = 1024.0;
        int i = 0;
        while (size >= mod)
        {
            size /= mod;
            i++;
        }
        return Math.Round(size) + units[i];
    }
    public string convetBit(string bitvalue)
    {
        string result="";
        int s = Convert.ToInt32(bitvalue);
        if (s > 1024 && s < 1024 * 1024){
            result = s / 1024 + "K";
        }
        else if (s >= 1024 * 1024 && s < 1024 * 1024 * 1024) {
            result = s / 1024*1024 + "M";
        }
        else if (s > 1024 * 1024 * 1024)
        {
            result = s / 1024 * 1024 * 1024 + "G";
        }
        else
        {
            result = s + "B";
        }
        return result;
    }

    #region 组合SQL查询语句==========================
    protected string CombSqlTxt(string _keywords, string _property)
    {
        StringBuilder strTemp = new StringBuilder();
        _keywords = _keywords.Replace("'", "");
        if (!string.IsNullOrEmpty(_keywords))
        {
            strTemp.Append(" (fileName like '%" + _keywords + "%') ");
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
        //JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("Repeater.aspx", "", ""), "Success");
        Response.Redirect(Utils.CombUrlTxt("category_list_item_version.aspx", "id={0}", this.id.ToString()));
    }
    public bool Delete(int id)
    {
        string delName = "";
        string strSQL = "select * from FileInfoChild where id=" + id;
        ResultDataSet Rs = new ResultDataSet();
        db.DB2Obj.GetRs(strSQL, out Rs);
        if (Rs.RowCount > 0)
        {
            string _filepath = Rs[0, "filePath"].ToString();
            delName = MapPath(_filepath);
        }
        if (File.Exists(delName))
        {
            try
            {
                File.Delete(delName);
            }
            catch
            {
            }
        }
        string sql = "delete from FileInfoChild where id = '" + id + "'";
        bool result = db.DB2Obj.Exec(sql);
        if (result)
        {
            return true;
        }
        return false;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("category_list_item_version.aspx", "keywords={0}&id={1}", txtKeywords.Text,this.id.ToString()));
    }
    /// <summary>
    /// 获得查询分页数据
    /// </summary>
    public DataSet GetList(string id, int category_id, int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
    {
        string sql = "select * from FileInfoChild where fileVersion='"+id+"' ";
        if (strWhere.Trim() != "")
        {
            sql += " and" + strWhere;
        }
        sql += "order by add_time desc";
        ResultDataSet Rs = new ResultDataSet();
        db.DB2Obj.GetRs(sql, out Rs);
        recordCount = Rs.RowCount;
        //string _sql = PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, sql.ToString(), filedOrder);
        //ResultDataSet Rs2 = new ResultDataSet();
        //db.DB2Obj.GetRs(_sql, out Rs2);
        DataSet dt = ((DataSet)Rs);
        return dt;
    }

    //protected void txtPageNum_TextChanged(object sender, EventArgs e)
    //{
    //    int _pagesize;
    //    if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
    //    {
    //        if (_pagesize > 0)
    //        {
    //            Utils.WriteCookie("article_page_size", _pagesize.ToString(), 43200);
    //        }
    //    }
    //    Response.Redirect(Utils.CombUrlTxt("order_list.aspx", "", ""));
    //}
    //#region 返回图文每页数量=========================
    //private int GetPageSize(int _default_size)
    //{
    //    int _pagesize;
    //    if (int.TryParse(Utils.GetCookie("article_page_size"), out _pagesize))
    //    {
    //        if (_pagesize > 0)
    //        {
    //            return _pagesize;
    //        }
    //    }
    //    return _default_size;
    //}
    //#endregion




    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        HttpPostedFile _upfile = FileUpload1.PostedFile;
        if (FileUpload1.HasFile == true)
        {
            if (FileUpload1.PostedFile.ContentLength > 1073741824)
            {
                Response.Write("<script>alert('文件过大，请控制在1G以内！');window.location.href ='" + Utils.CombUrlTxt("category_list_item.aspx", "id={0}", this.id.ToString()) + "'</script>");
                Response.End();
            }
            UpLoad upFiles = new UpLoad();
            ArrayList array = upFiles.fileSaveAs2(_upfile,null);
            if (array.Count > 0)
            {
                string fileName = array[2].ToString();
                string fileSize = array[1].ToString();
                string filePath = array[3].ToString();
                string fileExt = array[0].ToString();
                string username = "8108";
                string add_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                ResultDataSet Rs2 = new ResultDataSet();
                database_inte db2 = new database_inte();
                string sql2 = "insert into FileInfo (fileName,fileSize,filePath,username,add_time,fileExt,fileType) values ('" + fileName + "','" + fileSize + "','" + filePath + "','" + username + "','" + add_time + "','" + fileExt + "'," + this.id +")";
                if (db2.DB2Obj.GetRs(sql2, out Rs2))
                {
                    Response.Redirect(Utils.CombUrlTxt("category_list_item.aspx", "id={0}", this.id.ToString()));
                }
            }
        }
        else
        {
            Response.Write("<script>alert('请选择要上传的文件！');</script>");
        }
    }
}