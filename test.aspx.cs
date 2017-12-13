using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Web.UI;
using System.Threading;
using System.Text;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Button1.Attributes.Add("onclick", "this.disabled=true;" + this.ClientScript.GetPostBackEventReference(Button1, ""));
        //btnSumbit.Attributes.Add("onclick", "this.disabled=true;" + this.ClientScript.GetPostBackEventReference(btnSumbit, ""));
        //if (!IsPostBack)
        //{
        //    Label1.Text = "lable1"+DateTime.Now.ToString();
        //}
        //Label2.Text = "Label2" + DateTime.Now.ToString();
        //sb保存的是JavaScript脚本代码,点击提交按钮时执行该脚本
        //StringBuilder sb = new StringBuilder();
        ////保证验证函数的执行 
        //sb.Append("if (typeof(Page_ClientValidate) == 'function') { if (Page_ClientValidate() == false) { return false; }};");
        ////点击提交按钮后设置Button的disable属性防止用户再次点击,注意这里的this是JavaScript代码
        //sb.Append("this.disabled  = true;");
        ////用__doPostBack来提交，保证按钮的服务器端click事件执行 
        //sb.Append(this.ClientScript.GetPostBackEventReference(this.Button1, ""));
        //sb.Append(";");
        ////SetUIStyle()是JavaScript函数,点击提交按钮后执行,如可以显示动画效果提示后台处理进度
        ////注意SetUIStyle()定义在aspx页面中
        //sb.Append("SetUIStyle();");
        ////给提交按钮增加OnClick属性
        //this.Button1.Attributes.Add("onclick", sb.ToString());
        //Button1.Attributes.Add("onclick", "this.value='正在提交中,請稍等……';this.disabled=true;" + this.GetPostBackEventReference(Button1) + ";");
        Button1.Attributes.Add("onclick", "SetUIStyle();");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //Button1.Attributes.Add("onclick", "this.value='正在提交中,請稍等……';this.disabled=true;" + this.GetPostBackEventReference(Button1) + ";");
        //Label1.Text = DateTime.Now.ToString();
        //Thread.Sleep(3000);
        //JscriptMsg("haha", "teddst.aspx", "Success");
        
        ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>SetUIStyle();</script>"); 
    }

    public void JscriptMsg(string msgtitle, string url, string msgcss)
    {
        string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    protected void btnSumbit_Click(object sender, EventArgs e)
    {
        //btnSumbit.Attributes.Add("onclick", "btnClick()"); 
        //Thread.Sleep(3000);
        //Label1.Text = DateTime.Now.ToString();
        
    }
   
}