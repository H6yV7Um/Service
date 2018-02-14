using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test_Exam : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ProductRB();
        ProductCB();
    }

    private void ProductRB()
    {
        Label lb = new Label();
        lb.ID = "lb1";
        lb.Text = "1.继续护理学教育是：";
        RadioButtonList rbl = new RadioButtonList();
        rbl.RepeatDirection = RepeatDirection.Horizontal;
        rbl.ID = "rbl1";
        //控件里添加单选项信息,用名称做text，itemID做value
        ListItem item = new ListItem("A、终身性护理学教育", "a");
        ListItem item2 = new ListItem("B、理学历教育", "b");
        ListItem item3 = new ListItem("C、规范化专业培训", "c");
        ListItem item4 = new ListItem("D、护理知识培训", "d");
        //item.Selected = true;
        rbl.Items.Add(item);
        rbl.Items.Add(item2);
        rbl.Items.Add(item3);
        rbl.Items.Add(item4);
        panel.Controls.Add(lb);
        panel.Controls.Add(rbl);
    }
    private void ProductCB()
    {
        Label lb = new Label();
        lb.ID = "lb2";
        lb.Text = "1、最常见的咯血原因不正确的是";
        CheckBoxList cbl = new CheckBoxList();
        cbl.RepeatDirection = RepeatDirection.Horizontal;
        cbl.ID = "cbl1";
        ListItem item = new ListItem("A、支气管扩张", "a");
        ListItem item2 = new ListItem("B、慢性支气管炎", "b");
        ListItem item3 = new ListItem(" C、肺结核 ", "c");
        ListItem item4 = new ListItem("D、支气管肺癌 ", "d");
        ListItem item5 = new ListItem("E、风温性心脏病二尖瓣狭窄 ", "e");
        cbl.Items.Add(item);
        cbl.Items.Add(item2);
        cbl.Items.Add(item3);
        cbl.Items.Add(item4);
        cbl.Items.Add(item5);
        panel2.Controls.Add(lb);
        panel2.Controls.Add(cbl);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        RadioButtonList radiolist = (RadioButtonList)this.panel.FindControl("rbl1");
        if (radiolist != null)
        {//判断是否找到了RadioButtonList
            Response.Write("<script>alert('" + radiolist.SelectedValue + "');</script>");
        }
        else
        {
            Response.Write("<script>alert('xxxx');</script>");
        }
    }
}