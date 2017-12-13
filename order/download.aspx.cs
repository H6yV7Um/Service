using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bright.Data;
using Maticsoft.Common;
using System.IO;
using DTcms.Common;

public partial class order_download : System.Web.UI.Page
{
    public int id;
    public string id_version = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string _filename = "", _filepath = "";
        id_version = Request.QueryString["id_version"];
        id = Convert.ToInt32(Request["id"]);
        if (String.IsNullOrEmpty(id_version))
        {
            string strSQL = "select * from FileInfo where id=" + id;
            ResultDataSet Rs = new ResultDataSet();
            database_inte db = new database_inte();
            db.DB2Obj.GetRs(strSQL, out Rs);
            if (Rs.RowCount > 0)
            {
                _filename = Rs[0, "fileName"].ToString();
                _filepath = Rs[0, "filePath"].ToString();

            }
            if (System.IO.File.Exists(MapPath(_filepath)))
            {
                Response.Clear();
                Response.Buffer = true;

                Response.AddHeader("Content-Disposition", "attachment;filename=" + _filename);
                Response.ContentType = "application/unknow";
                Response.TransmitFile(_filepath);
                Response.End();

            }
            else
            {
                Response.Write("<script>alert('原文件已被删除！');window.location.href ='category_list.aspx'</script>");
                Response.End();
            }
        }
        else
        {
            string strSQL = "select * from FileInfoChild where id='" + id_version + "'";
            ResultDataSet Rs = new ResultDataSet();
            database_inte db = new database_inte();
            db.DB2Obj.GetRs(strSQL, out Rs);
            if (Rs.RowCount > 0)
            {
                _filename = Rs[0, "fileName"].ToString();
                _filepath = Rs[0, "filePath"].ToString();

            }
            if (System.IO.File.Exists(MapPath(_filepath)))
            {
                Response.Clear();
                Response.Buffer = true;

                Response.AddHeader("Content-Disposition", "attachment;filename=" + _filename);
                Response.ContentType = "application/unknow";
                Response.TransmitFile(_filepath);
                Response.End();

            }
            else
            {
                Response.Write("<script>alert('原文件已被删除！');window.location.href ='category_list.aspx'</script>");
                Response.End();
            }
 
        }
    }
}