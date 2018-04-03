using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Net;
using System.IO;
using Maticsoft.DBUtility;

public partial class sms : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //
        //Label1.Text = guid.ToString(); 
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Guid guid = Guid.NewGuid();
        string id = guid.ToString();
        string _add_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string phone = TextBox1.Text.ToString();
        string strSql = "insert into sms_outbox (sismsid, extcode, destaddr, messagecontent, reqdeliveryreport,msgfmt, sendmethod, requesttime, applicationid)VALUES('" + id + "', '01','" + phone + "', '5272718510007|2号楼|心内科|冰箱|12.60|64.00',1,15,2, '" + _add_time + "', 'APP128')";
        //string strSql = "insert into sms_outbox values('3','','15995851784','5272718510086|123456|30',1,15,2,'2017-05-2 09:59:00','APP128')";
        int i=DbHelperMySQL.ExecuteSql(strSql);
        if (i > 0)
        {
            Label1.Text = "成功！";
        }
        else
        {
            Label1.Text = "失败！";
        }
        
        
        //send();
        //Label1.Text = GetInfo(string.Format("http://192.168.11.5/Handler/TestHandler.ashx?action=ProblemInfo&OrderId={0}", 116));
    }

    public string GetInfo(string url)
    {
        string strBuff = "";
        Uri httpURL = new Uri(url);
        ///HttpWebRequest类继承于WebRequest，并没有自己的构造函数，需通过WebRequest的Creat方法 建立，并进行强制的类型转换   
        HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(httpURL);
        ///通过HttpWebRequest的GetResponse()方法建立HttpWebResponse,强制类型转换   
        HttpWebResponse httpResp = (HttpWebResponse)httpReq.GetResponse();
        ///GetResponseStream()方法获取HTTP响应的数据流,并尝试取得URL中所指定的网页内容   
        ///若成功取得网页的内容，则以System.IO.Stream形式返回，若失败则产生ProtoclViolationException错 误。在此正确的做法应将以下的代码放到一个try块中处理。这里简单处理   
        Stream respStream = httpResp.GetResponseStream();
        ///返回的内容是Stream形式的，所以可以利用StreamReader类获取GetResponseStream的内容，并以   
        //StreamReader类的Read方法依次读取网页源程序代码每一行的内容，直至行尾（读取的编码格式：UTF8）   
        StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
        strBuff = respStreamReader.ReadToEnd();
        return strBuff;
    } 




    /********************************************************************************************************/
    //数据发送
    /********************************************************************************************************/

    protected void send()
    {
        string sendurl = "http://api.sms.cn/sms/";
        string mobile = "18066077791"; //发送号码
        string name1="二十二区";
        string content1="电脑开不了机";
        string strContent = "{\"name\":\"" + name1 + "\",\"content\":\"" + content1 + "\"}";
        StringBuilder sbTemp = new StringBuilder();
        string uid = "yuan272958293";
        string pwd = "hyy3351284";
        string Pass = FormsAuthentication.HashPasswordForStoringInConfigFile(pwd + uid, "MD5"); //密码进行MD5加密
        //POST 传值
        sbTemp.Append("ac=send&uid=" + uid + "&pwd=" + Pass +"&template=382762&mobile=" + mobile + "&content=" + strContent);
        byte[] bTemp = System.Text.Encoding.GetEncoding("GBK").GetBytes(sbTemp.ToString());
        String postReturn = doPostRequest(sendurl, bTemp);
        Response.Write("Post response is: " + postReturn); //测试返回结果
    }
    //POST方式发送得结果
    private static String doPostRequest(string url, byte[] bData)
    {
        System.Net.HttpWebRequest hwRequest;
        System.Net.HttpWebResponse hwResponse;

        string strResult = string.Empty;
        try
        {
            hwRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            hwRequest.Timeout = 5000;
            hwRequest.Method = "POST";
            hwRequest.ContentType = "application/x-www-form-urlencoded";
            hwRequest.ContentLength = bData.Length;

            System.IO.Stream smWrite = hwRequest.GetRequestStream();
            smWrite.Write(bData, 0, bData.Length);
            smWrite.Close();
        }
        catch (System.Exception err)
        {
            WriteErrLog(err.ToString());
            return strResult;
        }

        //get response
        try
        {
            hwResponse = (HttpWebResponse)hwRequest.GetResponse();
            StreamReader srReader = new StreamReader(hwResponse.GetResponseStream(), Encoding.ASCII);
            strResult = srReader.ReadToEnd();
            srReader.Close();
            hwResponse.Close();
        }
        catch (System.Exception err)
        {
            WriteErrLog(err.ToString());
        }
        return strResult;
    }
    private static void WriteErrLog(string strErr)
    {
        Console.WriteLine(strErr);
        System.Diagnostics.Trace.WriteLine(strErr);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }
}