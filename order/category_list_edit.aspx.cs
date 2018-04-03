using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Web.UI;
using System.Collections;
using Bright.Data;
using Maticsoft.Common;
using DTcms.Common;

public partial class order_category_list_edit : System.Web.UI.Page
{
    protected int id, typeid;
    database_inte db2 = new database_inte();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.id = DTRequest.GetQueryInt("id");
        this.typeid= DTRequest.GetQueryInt("typeid");
        if (!IsPostBack)
        {
            ResultDataSet Rs = new ResultDataSet();
            string strSQL = "select * from FileInfo where id="+this.id+"";
            db2.DB2Obj.GetRs(strSQL, out Rs);
            if (Rs.RowCount > 0)
            {
                string state = Rs[0, "filestate"] + "";
                ddlState.SelectedIndex= !String.IsNullOrEmpty(state)?Convert.ToInt32(state):0;

                string add_time = Rs[0, "add_time"] + "";
                txtname.Text = Rs[0, "name"] + "";
                txttel.Text = Rs[0, "tel"] + "";

                string revise_time= Rs[0, "revise_time"] + "";
                txtrevise_time.Text=!String.IsNullOrEmpty(revise_time)? revise_time: Convert.ToDateTime(add_time).AddMonths(3).ToString("yyyy-MM-dd HH:mm:ss");

                string long_time= Rs[0, "long_time"] + "";
                txtlong_time.Text = !String.IsNullOrEmpty(long_time) ? revise_time : Convert.ToDateTime(add_time).AddYears(2).ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ClsData dbobj = db2.DB2Obj;
        string filestate = ddlState.SelectedValue;
        string name = txtname.Text.ToString();
        string tel = txttel.Text.ToString();
        string revise_time = txtrevise_time.Text.ToString();
        string long_time = txtlong_time.Text.ToString();
        string sql3 = "update FileInfo set filestate='" + filestate + "',name='" + name + "',tel='" + tel + "',revise_time='" + revise_time + "',long_time='" + long_time + "' where id=" + this.id + "";
        if (!dbobj.Exec(sql3))
        {
            dbobj.RollBack("fileInfo");
            Response.Write("<script>alert('更新失败，请稍后再试！');window.location.href ='" + Utils.CombUrlTxt("category_list_item.aspx", "id={0}", this.id.ToString()) + "'</script>");
            Response.End();
        }
        Response.Redirect(Utils.CombUrlTxt("category_list_item.aspx", "id={0}", this.typeid.ToString()));
        //HttpPostedFile _upfile = FileUpload1.PostedFile;
        //if (FileUpload1.HasFile == true)
        //{
        //    if (FileUpload1.PostedFile.ContentLength > 1073741824)
        //    {
        //        Response.Write("<script>alert('文件过大，请控制在1G以内！');window.location.href ='" + Utils.CombUrlTxt("category_list_item.aspx", "id={0}", this.id.ToString()) + "'</script>");
        //        Response.End();
        //    }
        //    string rename = txtRename.Text.ToString();
        //    UpLoad upFiles = new UpLoad();
        //    ArrayList array;
        //    if (!String.IsNullOrEmpty(rename))
        //    {
        //        array = upFiles.fileSaveAs2(_upfile, rename);
        //    }
        //    else
        //    {
        //        array = upFiles.fileSaveAs2(_upfile, null);
        //    }

        //    if (array.Count > 0)
        //    {
        //        string fileName = array[2].ToString();
        //        string fileSize = array[1].ToString();
        //        string filePath = array[3].ToString();
        //        string fileExt = array[0].ToString();
        //        string version = txtVersion.Text.ToString();
        //        string username = "8108";
        //        string add_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //        ClsData dbobj = db2.DB2Obj;
        //        ResultDataSet Rs2 = new ResultDataSet();
        //        string sql = "select fileVersion from FileInfo where fileVersion='" + version + "'";
        //        if (dbobj.GetRs(sql, out Rs2) && Rs2.RowCount > 0 && !String.IsNullOrEmpty(Rs2[0, "fileVersion"].ToString()))
        //        {
        //            dbobj.BeginTrans("fileInfo");
        //            string sql3 = "update FileInfo set fileName='" + fileName + "',fileSize='" + fileSize + "',filePath='" + filePath + "',username='" + username + "',add_time='" + add_time + "',fileExt='" + fileExt + "' where fileVersion='" + Rs2[0, "fileVersion"].ToString() + "'";
        //            if (!dbobj.Exec(sql3))
        //            {
        //                dbobj.RollBack("fileInfo");
        //                Response.Write("<script>alert('更新失败，请稍后再试！');window.location.href ='" + Utils.CombUrlTxt("category_list_item.aspx", "id={0}", this.id.ToString()) + "'</script>");
        //                Response.End();
        //            }

        //            string sql1 = "insert into FileInfoChild (fileName,fileSize,filePath,username,add_time,fileExt,fileType,fileVersion) values ('" + fileName + "','" + fileSize + "','" + filePath + "','" + username + "','" + add_time + "','" + fileExt + "'," + this.id + ",'" + version + "')";
        //            if (!dbobj.Exec(sql1))
        //            {
        //                dbobj.RollBack("fileInfo");
        //                Response.Write("<script>alert('提交失败，请稍后再试！');window.location.href ='" + Utils.CombUrlTxt("category_list_item.aspx", "id={0}", this.id.ToString()) + "'</script>");
        //                Response.End();
        //            }
        //            if (dbobj.CommitTrans("fileInfo") == false)
        //            {
        //                dbobj.RollBack("fileInfo");
        //                Response.Write("<script>alert('提交事务失败，请稍后再试！');window.location.href ='" + Utils.CombUrlTxt("category_list_item.aspx", "id={0}", this.id.ToString()) + "'</script>");
        //                Response.End();
        //            }
        //        }
        //        else
        //        {
        //            dbobj.BeginTrans("fileInfo");
        //            string sql1 = "insert into FileInfoChild (fileName,fileSize,filePath,username,add_time,fileExt,fileType,fileVersion) values ('" + fileName + "','" + fileSize + "','" + filePath + "','" + username + "','" + add_time + "','" + fileExt + "'," + this.id + ",'" + version + "')";
        //            string sql2 = "insert into FileInfo (fileName,fileSize,filePath,username,add_time,fileExt,fileType,fileVersion) values ('" + fileName + "','" + fileSize + "','" + filePath + "','" + username + "','" + add_time + "','" + fileExt + "'," + this.id + ",'" + version + "')";
        //            if (!dbobj.Exec(sql1))
        //            {
        //                dbobj.RollBack("fileInfo");
        //                Response.Write("<script>alert('提交失败，请稍后再试！');window.location.href ='" + Utils.CombUrlTxt("category_list_item.aspx", "id={0}", this.id.ToString()) + "'</script>");
        //                Response.End();

        //            }
        //            if (!dbobj.Exec(sql2))
        //            {
        //                dbobj.RollBack("fileInfo");
        //                Response.Write("<script>alert('提交失败，请稍后再试！');window.location.href ='" + Utils.CombUrlTxt("category_list_item.aspx", "id={0}", this.id.ToString()) + "'</script>");
        //                Response.End();
        //            }
        //            if (dbobj.CommitTrans("fileInfo") == false)
        //            {
        //                dbobj.RollBack("fileInfo");
        //                Response.Write("<script>alert('提交失败，请稍后再试！');window.location.href ='" + Utils.CombUrlTxt("category_list_item.aspx", "id={0}", this.id.ToString()) + "'</script>");
        //                Response.End();
        //            }
        //        }

        //        Response.Redirect(Utils.CombUrlTxt("category_list_item.aspx", "id={0}", this.id.ToString()));
        //    }
        //}
        //else
        //{
        //    Response.Write("<script>alert('请选择要上传的文件！');</script>");
        //}
    }
}