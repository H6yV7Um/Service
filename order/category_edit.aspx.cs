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
using System.Data;

public partial class order_category_edit : BasePage
{

    private string action = "Add"; //操作类型
    private int id = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        string _action = DTRequest.GetQueryString("action");
        this.id = DTRequest.GetQueryInt("id");
        if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
        {
            this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
        }
        if (!Page.IsPostBack)
        {
            TreeBind(0); //绑定类别
            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                ShowInfo(this.id);
            }
            else
            {
                if (this.id > 0)
                {
                    this.ddlParentId.SelectedValue = this.id.ToString();
                }
            }
        }
    }

    #region 绑定类别=================================
    private void TreeBind(int _channel_id)
    {
        DataTable dt = GetList2(0);

        this.ddlParentId.Items.Clear();
        this.ddlParentId.Items.Add(new ListItem("无父级分类", "0"));
        foreach (DataRow dr in dt.Rows)
        {
            string Id = dr["id"].ToString();
            int ClassLayer = int.Parse(dr["class_layer"].ToString());
            string Title = dr["typeName"].ToString().Trim();

            if (ClassLayer == 1)
            {
                this.ddlParentId.Items.Add(new ListItem(Title, Id));
            }
            else
            {
                Title = "├ " + Title;
                Title = Utils.StringOfChar(ClassLayer - 1, "　") + Title;
                this.ddlParentId.Items.Add(new ListItem(Title, Id));
            }
        }
    }
    #endregion

    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();
        string strSQL = "select * from FileType where id='" + _id + "'";
        db.DB2Obj.GetRs(strSQL, out Rs);

        if (Rs.RowCount > 0)
        {
            ddlParentId.SelectedValue = Rs[0, "id"].ToString();
            txtTitle.Text = Rs[0, "typeName"].ToString();
        }
    }
    #endregion

    #region 增加操作=================================
    private bool DoAdd()
    {
        ResultDataSet Rs2 = new ResultDataSet();
        database_inte db2 = new database_inte();
        try
        {
            string title = txtTitle.Text.Trim();
            int parent_id = int.Parse(ddlParentId.SelectedValue);
            string class_list = "";
            int class_layer=1;
            
            string sql2 = "insert into FileType (typeName,parentID) values ('" + title + "'," + parent_id + ") SELECT @@IDENTITY as ID";
            if (db2.DB2Obj.GetRs(sql2, out Rs2))
            {
                int id = int.Parse(Rs2[0, "ID"].ToString());
                if (parent_id > 0)
                {
                    ResultDataSet Rs = new ResultDataSet();
                    string strSQL = "select * from FileType where id=" + parent_id + "";
                    db2.DB2Obj.GetRs(strSQL, out Rs);
                    if (Rs.RowCount > 0)
                    {
                        class_list = Rs[0, "class_list"].ToString() + id.ToString() + ",";
                        class_layer = int.Parse(Rs[0, "class_layer"].ToString()) + 1;
                    }
                    else
                    {
                        class_list = "," + id + ",";
                        class_layer = 1;
                    }
                }
                else
                {
                    class_list = "," + id + ",";
                    class_layer = 1;
                }

                string sql3 = "update FileType set class_list='" + class_list + "',class_layer='" + class_layer + "' where id =" + id + "";
                if (db2.DB2Obj.Exec(sql3))
                {
                    return true;
                }

            }
        }
        catch
        {
            return false;
        }
        return false;
    }
    #endregion

    //#region 修改操作=================================
    //private bool DoEdit(int _id)
    //{
    //    try
    //    {
    //        BLL.article_category bll = new BLL.article_category();
    //        Model.article_category model = bll.GetModel(_id);

    //        int parentId = int.Parse(ddlParentId.SelectedValue);
    //        model.channel_id = this.channel_id;
    //        model.call_index = txtCallIndex.Text.Trim();
    //        model.title = txtTitle.Text.Trim();
    //        //如果选择的父ID不是自己,则更改
    //        if (parentId != model.id)
    //        {
    //            model.parent_id = parentId;
    //        }
    //        model.sort_id = int.Parse(txtSortId.Text.Trim());
    //        model.seo_title = txtSeoTitle.Text;
    //        model.seo_keywords = txtSeoKeywords.Text;
    //        model.seo_description = txtSeoDescription.Text;
    //        model.link_url = txtLinkUrl.Text.Trim();
    //        model.img_url = txtImgUrl.Text.Trim();
    //        model.content = txtContent.Value;
    //        if (bll.Update(model))
    //        {
    //            AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改" + this.channel_name + "频道栏目分类:" + model.title); //记录日志
    //            return true;
    //        }
    //    }
    //    catch
    //    {
    //        return false;
    //    }
    //    return false;
    //}
    //#endregion

    //保存类别
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
        {
            //if (!DoEdit(this.id))
            //{

            //    JscriptMsg("保存过程中发生错误！", "", "Error");
            //    return;
            //}
            //JscriptMsg("修改类别成功！", "category_list.aspx?channel_id=" + channel_id, "Success");
        }
        else //添加
        {
            if (!DoAdd())
            {
                JscriptMsg("保存过程中发生错误！", "", "Error");
                return;
            }
            //JscriptMsg("添加类别成功！", "category_list.aspx", "Success");
            Response.Redirect("category_list.aspx");
        }
    }
}