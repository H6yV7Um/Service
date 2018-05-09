using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bright.Data;
using Maticsoft.Common;
using System.Data;
using Dln.Common;
using System.Configuration;
using DTcms.Web.UI;
using DTcms.Common;

public partial class manager_content : BasePage
{
    string _code = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        _code = Request.QueryString["code"];
        if (!String.IsNullOrEmpty(_code))
        {
            assets.Text = _code;
        }
        if (!IsPostBack)
        {
            number.Text = Session["user_name"].ToString();
            getDropdownlist();
            ddp_item.Items.Insert(0, new ListItem("请选择问题类别", "0"));
            ddp_item_child.Items.Insert(0, new ListItem("请选择问题类别", "0"));
            TreeBind();
        } 
        Button1.Attributes.Add("onclick", "this.value='正在提交中,請稍等……';this.disabled=true;" + this.GetPostBackEventReference(Button1) + ";");
    }

    /// <summary>
    /// 获取类型下拉菜单
    /// </summary>
    public void getDropdownlist()
    {
        string strSQL = "select * from dt_type_list where parentID='0' ";
        ResultDataSet Rs2 = new ResultDataSet();
        database_inte db2 = new database_inte();
        if (db2.DB2Obj.GetRs(strSQL, out Rs2))
        {
            DataTable dt = ((DataSet)Rs2).Tables[0];
            type.DataSource = dt.DefaultView;
            type.DataTextField = "typeName";
            type.DataValueField = "id";
            type.DataBind();
            type.Items.Insert(0, new ListItem("请选择问题类别", "0"));
        }

    }
    private void TreeBind()
    {
        DataTable dt = GetAddressList(0);
        this.dp_dress.Items.Clear();
        this.dp_dress.Items.Add(new ListItem("请选择相应楼层", ""));
        foreach (DataRow dr in dt.Rows)
        {
            string Id = dr["id"].ToString();
            //string TypeID = dr["typeID"].ToString();
            int ClassLayer = Convert.ToInt32(dr["class_layer"].ToString());
            string Title = dr["typeName"].ToString().Trim();

            if (ClassLayer == 1)
            {
                this.dp_dress.Items.Add(new ListItem(Title, Id));
            }
            else
            {
                Title = "├ " + Title;
                Title = Utils.StringOfChar(ClassLayer - 1, "　") + Title;
                this.dp_dress.Items.Add(new ListItem(Title, Id));
            }
        }
    }
    public void getChecklist()
    {
        //string val = type.SelectedValue;
        //string strSQL = "select * from dt_manager where sms=0 and type_id like '%,"+val+",%' ";
        //ResultDataSet Rs2 = new ResultDataSet();
        //database_inte db2 = new database_inte();
        //if (db2.DB2Obj.GetRs(strSQL, out Rs2))
        //{
        //    DataTable dt = ((DataSet)Rs2).Tables[0];
        //    CheckBoxList1.DataSource = dt.DefaultView;
        //    CheckBoxList1.DataTextField = "real_name";
        //    CheckBoxList1.DataValueField = "telephone";
        //    CheckBoxList1.DataBind();
        //}

    }
    public void getDdpItem()
    {
        string val = type.SelectedValue;
        if (val != "0")
        {
            string strSQL = "select * from dt_type_list where parentID='" + val + "' ";
            ResultDataSet Rs2 = new ResultDataSet();
            database_inte db2 = new database_inte();
            if (db2.DB2Obj.GetRs(strSQL, out Rs2))
            {
                DataTable dt = ((DataSet)Rs2).Tables[0];
                ddp_item.DataSource = dt.DefaultView;
                ddp_item.DataTextField = "typeName";
                ddp_item.DataValueField = "id";
                ddp_item.DataBind();
                ddp_item.Items.Insert(0, new ListItem("请选择问题类别", "0"));
            }
            else
            {
                ddp_item.Items.Insert(0, new ListItem("请选择问题类别", "0"));
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Button1.Attributes.Add("onclick", "this.value='正在提交中,请稍等……';this.disabled=true;" + this.GetPostBackEventReference(Button1) + ";");
        string _title = title.Text.ToString();
        string _number = number.Text.ToString();
        int _dp_priority = Convert.ToInt32(dp_priority.SelectedValue);
        string _txtImgUrl="", _img_url = "";
        HttpPostedFile _upfile = FileUpload1.PostedFile;
        if (FileUpload1.HasFile == true)
        {
            UpLoad upFiles = new UpLoad();
            _txtImgUrl = upFiles.fileSaveAs(_upfile, false, false);
            _img_url = _txtImgUrl.Substring(2);
            string userAgent = Request.UserAgent;
            if (userAgent.ToLower().Contains("micromessenger"))
            {
                _img_url += ".jpg";
            }
        }
        
        string _name = name.Text.ToString();
        string _tel = tel.Text.ToString();
        string _address = address.Text.ToString();
        string _details = details.Text.ToString();
        string _username = Session["user_name"].ToString();
        string group_id = Session["group_id"].ToString();
        int _state = 0;
        string _add_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string _type = type.SelectedItem.Value;
        string _OADeptID = null;
        string tbAssinger = null;
        string _assets = null;
        string _ddpAddress = dp_dress.SelectedValue;
        string _floor = getDDPAddress();
        if (String.IsNullOrEmpty(_title) || String.IsNullOrEmpty(_name) || String.IsNullOrEmpty(_tel) || String.IsNullOrEmpty(_address) || String.IsNullOrEmpty(_details) || _type == "0" || String.IsNullOrEmpty(_ddpAddress))
        {
            //JscriptMsg("haha", "content.aspx", "Success");$.dialog.alert('标题不能为空！');
            //Response.Write("<script>$.dialog.alert('提交失败，请填写完整！');</script>");
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>SetUIStyle();</script>"); 
        }
        else
        {
            //判断选哪个类别
            string ddpItem = ddp_item.Items.Count.ToString();
            string ddpItemChild = ddp_item_child.Items.Count.ToString();
            if (ddpItem != "1" && ddp_item.SelectedValue != "0")
            {
                _type = ddp_item.SelectedItem.Value;
                if (ddpItemChild != "1" && ddp_item_child.SelectedValue != "0")
                {
                    _type = ddp_item_child.SelectedItem.Value;
                }
            }


            //OA用户登录的情况
            if (_username == group_id)
            {
                _OADeptID = getOADeptID(_username);
            }
            else
            {
                _OADeptID = group_id;
            }
            group_id = getGroupID(_type);

            //判断是否有指定人
            if (!String.IsNullOrEmpty(TbAssinger.Text.ToString().Trim()))
            {
                tbAssinger = TbAssinger.Text.ToString().Trim();
            }
            //判断固定资产号是否为空
            if (!String.IsNullOrEmpty(assets.Text.ToString().Trim()))
            {
                _assets = assets.Text.ToString().Trim();
            }
            ResultDataSet Rs2 = new ResultDataSet();
            database_inte db2 = new database_inte();
            string sql2 = "insert into dt_order (title,number,img_url,name,telephone,address,details,username,priority,state,add_time,type,group_id,AppointUser,deptID,fixedAssets,floor,flevel) values ('" + _title + "','" + _number + "','" + _img_url + "','" + _name + "','" + _tel + "','" + _address + "','" + _details + "','" + _username + "','" + _dp_priority + "','" + _state + "','" + _add_time + "','" + _type + "','" + group_id + "','" + tbAssinger + "','" + _OADeptID + "','" + _assets + "','" + _floor + "','" + _ddpAddress + "') SELECT @@IDENTITY as ID";
            if (db2.DB2Obj.GetRs(sql2, out Rs2))
            {
                title.Text = "";
                string _OrderId = "";

                if (Rs2.RowCount > 0)
                {
                    _OrderId = Rs2[0, "ID"].ToString();
                }
                string _SmsUrl = ConfigurationManager.AppSettings["SmsUrl"].ToString();
                RequestHelper.SendGet(string.Format("http://{0}/Handler/TestHandler.ashx?action=ProblemInfo&OrderId={1}", _SmsUrl, _OrderId));
                Response.Write("<script>alert('恭喜您，提交成功啦！维保人员正在路上，请耐心等待！');window.location.href ='content.aspx'</script>");
                //ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>SetUIStyle2();</script>"); 
            }
            else
            {
                //Response.Write("<script>alert('提交失败，请稍后重试！');window.location.href ='content.aspx'</script>");
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>SetUIStyle3();</script>"); 
            }
        }
        
        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

        string sBasicTools = "";

        //for (int i = 0; i < this.CheckBoxList1.Items.Count; i++)
        //{
        //    if (this.CheckBoxList1.Items[i].Selected == true)
        //    {
        //        sBasicTools += this.CheckBoxList1.Items[i].Value + ",";
        //    }
        //}

        sBasicTools = sBasicTools.TrimEnd(',');
        Response.Write("<script>alert('提交成功！" + sBasicTools + "');window.location.href ='content.aspx'</script>");
    }
    protected void type_SelectedIndexChanged(object sender, EventArgs e)
    {
        getDdpItem();
        string ddpItem = ddp_item.Items.Count.ToString();
        if (ddpItem == "1")
        {
            ddp_item.Visible = false;
            ddp_item_child.Visible = false;

        }
        else
        {
            ddp_item.Visible = true;
        }

        //getChecklist();
        //for (int i = 0; i < this.CheckBoxList1.Items.Count; i++)
        //{
        //    if (this.CheckBoxList1.Items[i].Value == "15358310177")
        //    {
        //        this.CheckBoxList1.Items[i].Selected = true;
        //    }
        //}
    }
    protected void ddp_item_SelectedIndexChanged(object sender, EventArgs e)
    {
        getDdpItemChild();
        string ddpItemChild = ddp_item_child.Items.Count.ToString();
        if (ddpItemChild == "1")
        {
            ddp_item_child.Visible = false;
        }
        else
        {
            ddp_item_child.Visible = true;
        }
    }
    public void getDdpItemChild()
    {
        string val = ddp_item.SelectedValue;
        if (val != "0")
        {
            string strSQL = "select * from dt_type_list where parentID='" + val + "' ";
            ResultDataSet Rs2 = new ResultDataSet();
            database_inte db2 = new database_inte();
            if (db2.DB2Obj.GetRs(strSQL, out Rs2))
            {
                DataTable dt = ((DataSet)Rs2).Tables[0];
                ddp_item_child.DataSource = dt.DefaultView;
                ddp_item_child.DataTextField = "typeName";
                ddp_item_child.DataValueField = "id";
                ddp_item_child.DataBind();
                ddp_item_child.Items.Insert(0, new ListItem("请选择问题类别", "0"));
            }
            else
            {
                ddp_item_child.Items.Insert(0, new ListItem("请选择问题类别", "0"));
            }
        }
    }
    public string getDDPAddress()
    {
        string val = dp_dress.SelectedValue;
        if (val != "")
        {
            string strSQL = "select * from FileType where id="+int.Parse(dp_dress.SelectedValue) +"";
            ResultDataSet Rs2 = new ResultDataSet();
            database_inte db2 = new database_inte();
            if (db2.DB2Obj.GetRs(strSQL, out Rs2))
            {
                string parentID = Rs2[0, "parentID"].ToString();
                string strSQL3 = "select * from FileType where id=" + int.Parse(parentID) + "";
                ResultDataSet Rs3 = new ResultDataSet();
                if (db2.DB2Obj.GetRs(strSQL3, out Rs3))
                {
                    return Rs3[0, "typeName"].ToString();
                }
            }
        }
        return "";
    }

}