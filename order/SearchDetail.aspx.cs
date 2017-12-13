using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bright.Data;
using Maticsoft.Common;

public partial class order_SearchDetail : System.Web.UI.Page
{
    database_inte db = new database_inte();
    protected void Page_Load(object sender, EventArgs e)
    {
        string content = "";
        string keyword = Request.QueryString["id"];
        if (!String.IsNullOrEmpty(keyword))
        {
            string sql = "select top 1.* from DrugInfo where id=" + keyword + "";
            ResultDataSet Rs = new ResultDataSet();
            db.DB4Obj.GetRs(sql, out Rs);
            if (Rs.RowCount > 0)
            {
                content = "<h2>" + Rs[0, "药品名称"] + "(" + Rs[0, "规格"] + ")</h2>" +
                            "<h4>适应症:</h4>" +
                            "<p>" + Rs[0, "适应症"] + "</p>" +
                "<h4>用法用量</h4>" +
                "<p>" + Rs[0, "用法用量"] + "</p>" +
                "<h4>不良反应</h4>" +
                "<p>" + Rs[0, "不良反应"] + "</p>" +
                "<h4>禁忌</h4>" +
                "<p>" + Rs[0, "禁忌"] + "</p>" +
                "<h4>注意事项</h4>" +
                "<p>" + Rs[0, "注意事项"] + "</p>" +
                "<h4>妊娠期妇女用药</h4>" +
                "<p>" + Rs[0, "妊娠期妇女用药"] + "</p>" +
                "<h4>哺乳期妇女用药</h4>" +
                "<p>" + Rs[0, "哺乳期妇女用药"] + "</p>" +
                "<h4>儿童用药</h4>" +
                "<p>" + Rs[0, "儿童用药"] + "</p>" +
                "<h4>老年用药</h4>" +
                "<p>" + Rs[0, "老年用药"] + "</p>" +
                "<h4>药物相互作用中西</h4>" +
                "<p>" + Rs[0, "药物相互作用中西"] + "</p>" +
                "<h4>贮藏</h4>" +
                "<p>" + Rs[0, "贮藏"] + "</p>" +
                "<h4>食物药物交互作用</h4>" +
                "<p>" + Rs[0, "食物药物交互作用"] + "</p>" +
                "<h4>溶媒</h4>" +
                "<p>" + Rs[0, "溶媒"] + "</p>" +
                "<h4>滴速</h4>" +
                "<p>" + Rs[0, "滴速"] + "</p>" +
                "<h4>备注参考依据非说明书上内容请注明</h4>" +
                "<p>" + Rs[0, "备注参考依据非说明书上内容请注明"] + "</p>";
            }
            ul.InnerHtml = content;
            Label1.Text = "西药";
            Label1.ForeColor = System.Drawing.Color.Green;
            
        }
        string ids = Request.QueryString["ids"];
        if (!String.IsNullOrEmpty(ids))
        {
            string sql = "select top 1.* from DrugInfo_C where ids=" + ids + "";
            ResultDataSet Rs = new ResultDataSet();
            db.DB4Obj.GetRs(sql, out Rs);
            if (Rs.RowCount > 0)
            {
                content = "<h2>" + Rs[0, "药品名称"] + "(" + Rs[0, "规格"] + ")</h2>" +
                            "<h4>功效分类:</h4>" +
                            "<p>" + Rs[0, "功效分类"] + "</p>" +
                "<h4>来源</h4>" +
                "<p>" + Rs[0, "来源"] + "</p>" +
                "<h4>药性</h4>" +
                "<p>" + Rs[0, "药性"] + "</p>" +
                "<h4>功效</h4>" +
                "<p>" + Rs[0, "功效"] + "</p>" +
                "<h4>应用</h4>" +
                "<p>" + Rs[0, "应用"] + "</p>" +
                "<h4>用法用量</h4>" +
                "<p>" + Rs[0, "用法用量"] + "</p>" +
                "<h4>使用注意</h4>" +
                "<p>" + Rs[0, "使用注意"] + "</p>" +
                "<h4>贮藏</h4>" +
                "<p>" + Rs[0, "贮藏"] + "</p>" +
                "<h4>现代研究</h4>" +
                "<p>" + Rs[0, "现代研究"] + "</p>" +
                "<h4>不良反应</h4>" +
                "<p>" + Rs[0, "不良反应"] + "</p>" +
                "<h4>禁忌</h4>" +
                "<p>" + Rs[0, "禁忌"] + "</p>" +
                "<h4>妊娠期妇女用药</h4>" +
                "<p>" + Rs[0, "妊娠期妇女用药"] + "</p>" +
                "<h4>哺乳期妇女用药</h4>" +
                "<p>" + Rs[0, "哺乳期妇女用药"] + "</p>" +
                "<h4>儿童用药</h4>" +
                "<p>" + Rs[0, "儿童用药"] + "</p>" +
                "<h4>老年用药</h4>" +
                "<p>" + Rs[0, "老年用药"] + "</p>" +
                "<h4>药物相互作用中西</h4>" +
                "<p>" + Rs[0, "药物相互作用中西"] + "</p>" +
                "<h4>食物药物交互作用</h4>" +
                "<p>" + Rs[0, "食物药物交互作用"] + "</p>";
                
            }
            ul.InnerHtml = content;
            Label1.Text = "中药";
            Label1.ForeColor = System.Drawing.Color.Green;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        Response.Redirect("SearchItem.aspx?keyword=" + TextBox1.Text.ToString());
    }
}