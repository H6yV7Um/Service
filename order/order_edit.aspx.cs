using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bright.Data;
using Maticsoft.Common;
using DTcms.Common;
using System.Data;

public partial class order_order_edit : BasePage
{
    string _code = "";
    public int id { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        _code = Request.QueryString["code"];
        id = Convert.ToInt32(Request.QueryString["id"]);
        
        if (!IsPostBack)
        {
            TreeBind();
            
            //orderID.Text = id.ToString();
            //orderDetails.Text = getDetails(id);
            ResultDataSet Rs = new ResultDataSet();
            database_inte db = new database_inte();
            string strSQL = "select * from dt_order where id='" + id + "'";
            db.DB2Obj.GetRs(strSQL, out Rs);
            if (Rs.RowCount > 0)
            {
                type.SelectedValue = Rs[0, "type"].ToString();
                details.Text = Rs[0, "details"].ToString();
                mark.Text = Rs[0, "mark"].ToString();
                LbStar.Text = getStarName(Rs[0, "starNum"].ToString());
                assets.Text= Rs[0, "fixedAssets"].ToString();
                if (Rs[0, "img_url"].ToString() == "")
                {
                    Image1.ImageUrl = "../scripts/skin/default/noimg.jpg";
                    Image1.Width = 200;
                }
                else
                {
                    Image1.ImageUrl = "../" + Rs[0, "img_url"].ToString();
                    Image2.ImageUrl = "../" + Rs[0, "img_url"].ToString();
                }
            }
            else
            {
                Image1.ImageUrl = "../scripts/skin/default/noimg.jpg";
                Image1.Width = 200;
            }

            if (!String.IsNullOrEmpty(_code))
            {
                assets.Text = _code;
            }
        }
    }
    #region 绑定类别=================================
    private void TreeBind()
    {
        DataTable dt = GetList(0);
        this.type.Items.Clear();
        this.type.Items.Add(new ListItem("请选择问题类别", "0"));
        foreach (DataRow dr in dt.Rows)
        {
            string Id = dr["id"].ToString();
            int ClassLayer = Convert.ToInt32(dr["class_layer"].ToString());
            string Title = dr["typeName"].ToString().Trim();

            if (ClassLayer == 1)
            {
                this.type.Items.Add(new ListItem(Title, Id));
            }
            else
            {
                Title = "├ " + Title;
                Title = Utils.StringOfChar(ClassLayer - 1, "　") + Title;
                this.type.Items.Add(new ListItem(Title, Id));
            }
        }
    }
    #endregion
    public string getDetails(int id)
    {
        string value="";
        ResultDataSet Rs = new ResultDataSet();
        database_inte db = new database_inte();
        string strSQL = "select * from dt_order A inner join dt_order_child B on A.id=B.child_id where id='" + id + "'";
        db.DB2Obj.GetRs(strSQL, out Rs);
        if (Rs.RowCount > 0)
        {
            value= Rs[0, "child_details"].ToString();
        }
        return value;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ChkAdminLevel("order_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
        string url = Request.QueryString["url"]; 
        string _mark=mark.Text.ToString();
        string _type = type.SelectedValue;
        string _groupID = getGroupID(_type);
        int id = Convert.ToInt32(Request.QueryString["id"]);
        ResultDataSet Rs2 = new ResultDataSet();
        database_inte db2 = new database_inte();
        string sql2 = "update dt_order set mark='" + _mark + "',type='" + _type + "',group_id='" + _groupID + "',fixedAssets='"+assets.Text.ToString()+"' where id ='" + id + "'";
        if (db2.DB2Obj.Exec(sql2))
        {
            Response.Redirect(url+".aspx");
        }
        
    }
    public string getStarName(string num)
    {
        string result = "";
        switch (num)
        {
            case "0":
                result = "暂无评分";
                break;
            case "1":
                result = "很不满意，非常差，太令人失望了";
                star1.Visible = true;
                break;
            case "2":
                result = "不满意，不好，不能满足要求";
                star1.Visible = true;
                star2.Visible = true;
                break;
            case "3":
                result = "一般，感觉一般";
                star1.Visible = true;
                star2.Visible = true;
                star3.Visible = true;
                break;
            case "4":
                result = "满意，都比较满意，符合我的预期";
                star1.Visible = true;
                star2.Visible = true;
                star3.Visible = true;
                star4.Visible = true;
                break;
            case "5":
                result = "非常满意，我很喜欢！都很满意，太棒了！";
                star1.Visible = true;
                star2.Visible = true;
                star3.Visible = true;
                star4.Visible = true;
                star5.Visible = true;
                break;
            default:
                result = "暂无评分";
                break;
        }
        return result;
    }
}