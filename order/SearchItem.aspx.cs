using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Maticsoft.Common;
using Bright.Data;

public partial class order_SearchItem : System.Web.UI.Page
{
    DrugInfo drugInfo = new DrugInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        string keyword = Request.QueryString["keyword"];
        if (!IsPostBack)
        {
            container.Visible = false;
            if (!String.IsNullOrEmpty(keyword))
            {
                GetList(keyword);
                container.Visible = true;
            }
        }
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        container.Visible = true;
        string keyword = TextBox1.Text.ToString().Trim();
        GetList(keyword);
    }
    private void GetList(string keyword)
    {
        string content = "";
        if (!String.IsNullOrEmpty(keyword))
        {
            ResultDataSet Rs = drugInfo.GetList(keyword);
            ResultDataSet Rs2 = drugInfo.GetList_C(keyword);
            if (Rs.RowCount > 0)
            {
                for (int i = 0; i < Rs.RowCount; i++)
                {
                    content += "<h4><a href=\"SearchDetail.aspx?id=" + Rs[i, "id"] + "\">" + Rs[i, "药品名称"] + "(" + Rs[i, "规格"] + ")-西药</a></h4>" +
                              "<li>适应症：" + Rs[i, "适应症"] + "</li>";
                }
                Label1.Text = Rs.RowCount + "条搜索结果";
            }
            else if (Rs2.RowCount > 0)
            {
                for (int i = 0; i < Rs2.RowCount; i++)
                {
                    content += "<h4><a href=\"SearchDetail.aspx?ids=" + Rs2[i, "ids"] + "\">" + Rs2[i, "药品名称"] + "(" + Rs2[i, "规格"] + ")-中药</a></h4>" +
                              "<li>功效：" + Rs2[i, "功效"] + "</li>"+
                    "<li>应用：" + Rs2[i, "应用"] + "</li>";
                }
                Label1.Text =Rs2.RowCount + "条搜索结果";
            }
            else
            {
                Label1.Text = "暂无相应药品";
            }
            ul.InnerHtml = content;
        }
    }
    
}