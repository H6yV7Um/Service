using System.Net;
using System.IO;
using System.Web.Services.Description;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Reflection;
using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;
using System.Encryption;
using System.Security.Cryptography;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json.Linq;

public partial class test_Wechart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //string url = "http://web.witontek.com/eHospital2/services/windowPayService?wsdl";
        
        string hospital_id = "syzyyadmin";
        string hospital_area_id = "";
        string auth_code = "134805578981882905";
        string order_amount = "0.01";
        string biz_id = Guid.NewGuid().ToString();
        //string pay_type = "wechatScan";
        string data_src = "hisSrc";
        string cashier_id = "1000001（张三）";
        string sign = "92278c4d91304ca383a9e4c9dfe80b44"; //92278c4d91304ca383a9e4c9dfe80b44
        //string JsonStr = MicroPay(hospital_id, hospital_area_id, auth_code, order_amount, biz_id, pay_type, data_src, cashier_id, sign);
        string JsonStr = MicroPay(hospital_id, hospital_area_id, auth_code, order_amount, biz_id, data_src, cashier_id, sign);
        JObject jo = (JObject)JsonConvert.DeserializeObject(JsonStr);
        string zone = jo["result"].ToString();
        string zone_en = jo["message"].ToString();
        if (jo["data"] != null)
        {
            string signs = jo["data"]["sign"].ToString();
            Response.Write(signs + "!!!");
        }
        Response.Write(zone);
        Label1.Text = JsonStr;
        TextBox1.Text = biz_id;

        //{"message":"操作成功","result":"SUCCESS","data":{"sign":"DEF0DD808AE9D9D3FF454A13E73C473A","code_message":"用户支付中，需要输入密码","code":"USERPAYING"}}
        //{"message":"操作成功","result":"SUCCESS","data":{"sign":"E48189F215455D306774C726BF63BDA9","code_message":"授权码过期或无效","code":"AUTH_CODE_ERROR"}}
        //Label1.Text = JsonStr;
        //JavaScriptSerializer serializer = new JavaScriptSerializer();
        //Project p2 = serializer.Deserialize<Project>(JsonStr); //反序列化：JSON字符串=>对象
        //Response.Write(p2.message+"---"+p2.result+"----"+p2.data);
        //JavaScriptObject jObject = JavaScriptConvert.DeserializeObject(JsonStr) as JavaScriptObject;
        //Response.Write(jObject["result"].ToString());
        //Response.Write(jObject["message"].ToString());
        //Response.Write(jObject["sign"].ToString());
        //如果josn里还包含josn，那么就需要这么写。
        //JavaScriptArray JsonData = (JavaScriptArray)jObject["data"];
        //if (JsonData.Count > 0)
        //{

        //    for (int m = 0; m < JsonData.Count; m++)
        //    {
        //        JavaScriptObject orderObj = (JavaScriptObject)JsonData[m];
        //        Response.Write(orderObj["sign"].ToString());
        //    }

        //}
    }

    public class Project
    {
        public string result { get; set; }
        public string message { get; set; }
        public string data { get; set; }
        public string sign { get; set; }
        public string code { get; set; }
        public string trade_no { get; set; }
        public string time_end { get; set; }
        public string wt_trade_no { get; set; }

    }
    private string GetMD5Key(IDictionary<string, string> parameters,string key)
    {
        List<string> list = new List<string>();
        foreach (KeyValuePair<string, string> kvp in parameters)
        {
            if (!String.IsNullOrEmpty(kvp.Value))
            {
                list.Add(kvp.Key+"="+kvp.Value+"&");
            }
        }
        string[] arrayToSort = list.ToArray();
        Array.Sort(arrayToSort, string.CompareOrdinal); //ASCII排序
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < list.Count; i++)
        {
            sb.Append(arrayToSort[i]);
        }
        string result = sb.ToString();
        result += "key="+key;
        result = result.Trim();
        result= GetMd5Hash(result);
        return result.ToUpper();
    }

    private string GetMd5Hash(string input)
    {
        System.Security.Cryptography.MD5 md5 = new MD5CryptoServiceProvider();
        byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
        StringBuilder sBuilder = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }
        return sBuilder.ToString();
    }


    private string MicroPay(string hospital_id, string hospital_area_id, string auth_code, string order_amount, string biz_id, string data_src, string cashier_id, string sign)
    {
        try
        {
            if (!String.IsNullOrEmpty(hospital_id) && !String.IsNullOrEmpty(auth_code) && !String.IsNullOrEmpty(order_amount) && !String.IsNullOrEmpty(biz_id) && !String.IsNullOrEmpty(data_src) && !String.IsNullOrEmpty(sign))
            {
                //ServiceReference2.Service1SoapClient _client2 = new ServiceReference2.Service1SoapClient();
                //return _client2.MicroPay(hospital_id, hospital_area_id, auth_code, order_amount, biz_id, pay_type, data_src, cashier_id, sign);
                //ServiceReference3.WindowPayWebServiceClient _client = new ServiceReference3.WindowPayWebServiceClient();

                //ServiceReference1.WindowPayWebServiceClient _client = new ServiceReference1.WindowPayWebServiceClient();
                TestAddressPay.WindowPayWebServiceV2Client _client = new TestAddressPay.WindowPayWebServiceV2Client();
                IDictionary<string, string> para = new Dictionary<string, string>();
                para.Add("hospital_id", hospital_id);
                para.Add("hospital_area_id", hospital_area_id);
                para.Add("auth_code", auth_code);
                para.Add("order_amount", order_amount);
                para.Add("biz_id", biz_id);
                para.Add("data_src", data_src);
                para.Add("cashier_id", cashier_id);
                string signs = GetMD5Key(para, sign);//B9EB02AAD7DAB96B58A0D34CC2E12952
                string result = "{\"hospital_id\":\"" + hospital_id + "\",\"hospital_area_id\":\"" + hospital_area_id + "\",\"auth_code\":\"" + auth_code + "\",\"order_amount\":\"" + order_amount + "\",\"biz_id\":\"" + biz_id + "\",\"data_src\":\"" + data_src + "\",\"cashier_id\":\"" + cashier_id + "\",\"sign\":\"" + signs + "\"}";
                return _client.microPay(result);

            }
            return "";
        }
        catch (Exception)
        {

            return "";
        }

    }

    /// <summary>
    /// 反扫下单并支付
    /// </summary>
    /// <param name="hospital_id">医院 id </param>
    /// <param name="hospital_area_id">院区 ID</param>
    /// <param name="auth_code">支付授权码 </param>
    /// <param name="order_amount">支付金额 </param>
    /// <param name="biz_id">业务 id </param>
    /// <param name="pay_type">wechatScan</param>
    /// <param name="data_src">支付类型来源</param>
    /// <param name="cashier_id">收银员代码</param>
    /// <param name="sign">签名</param>
    /// <returns></returns>
    private string MicroPay(string hospital_id,string hospital_area_id, string auth_code, string order_amount, string biz_id, string pay_type, string data_src, string cashier_id,string sign)
    {
        try
        {
            if (!String.IsNullOrEmpty(hospital_id) && !String.IsNullOrEmpty(auth_code) && !String.IsNullOrEmpty(order_amount) && !String.IsNullOrEmpty(biz_id) && !String.IsNullOrEmpty(pay_type) && !String.IsNullOrEmpty(data_src) && !String.IsNullOrEmpty(sign))
            {
                //ServiceReference2.Service1SoapClient _client2 = new ServiceReference2.Service1SoapClient();
                //return _client2.MicroPay(hospital_id, hospital_area_id, auth_code, order_amount, biz_id, pay_type, data_src, cashier_id, sign);
                //ServiceReference3.WindowPayWebServiceClient _client = new ServiceReference3.WindowPayWebServiceClient();

                //ServiceReference1.WindowPayWebServiceClient _client = new ServiceReference1.WindowPayWebServiceClient();
                ServiceReferenceV2.WindowPayWebServiceV2Client _client = new ServiceReferenceV2.WindowPayWebServiceV2Client();
                IDictionary<string, string> para = new Dictionary<string, string>();
                para.Add("hospital_id", hospital_id);
                para.Add("hospital_area_id", hospital_area_id);
                para.Add("auth_code", auth_code);
                para.Add("order_amount", order_amount);
                para.Add("biz_id", biz_id);
                //para.Add("pay_type", pay_type);
                para.Add("data_src", data_src);
                para.Add("cashier_id", cashier_id);
                string signs = GetMD5Key(para, sign);//B9EB02AAD7DAB96B58A0D34CC2E12952
                string result = "{\"hospital_id\":\"" + hospital_id + "\",\"hospital_area_id\":\"" + hospital_area_id + "\",\"auth_code\":\"" + auth_code + "\",\"order_amount\":\"" + order_amount + "\",\"biz_id\":\"" + biz_id + "\",\"pay_type\":\"" + pay_type + "\",\"data_src\":\"" + data_src + "\",\"cashier_id\":\"" + cashier_id + "\",\"sign\":\"" + signs + "\"}";
                return _client.microPay(result);

            }
            return "";
        }
        catch (Exception)
        {

            return "";
        }
        
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        string biz_id= TextBox1.Text.ToString(); //1a995119c725431285c04d647109d05f1
        string sign = "92278c4d91304ca383a9e4c9dfe80b44";
        IDictionary<string, string> para = new Dictionary<string, string>();
        para.Add("hospital_id", "syzyyadmin");
        para.Add("biz_id", biz_id);
        string signs = GetMD5Key(para, sign);
        //ServiceReference1.WindowPayWebServiceClient _client = new ServiceReference1.WindowPayWebServiceClient();
        ServiceReferenceV2.WindowPayWebServiceV2Client _client = new ServiceReferenceV2.WindowPayWebServiceV2Client();
        string json = "{\"hospital_id\":\"syzyyadmin\",\"biz_id\":\""+ biz_id + "\",\"sign\":\"" + signs+"\"}";
        string s = _client.qryPayStatus(json);
        Label2.Text = s;
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        string biz_id = TextBox1.Text.ToString(); //1a995119c725431285c04d647109d05f1
        string sign = "92278c4d91304ca383a9e4c9dfe80b44";
        IDictionary<string, string> para = new Dictionary<string, string>();
        para.Add("hospital_id", "syzyyadmin");
        para.Add("biz_id", biz_id);
        string signs = GetMD5Key(para, sign);
        ServiceReferenceV2.WindowPayWebServiceV2Client _client = new ServiceReferenceV2.WindowPayWebServiceV2Client();
        string json = "{\"hospital_id\":\"syzyyadmin\",\"biz_id\":\"" + biz_id + "\",\"sign\":\"" + signs + "\"}";
        string s = _client.reverseOrder(json);
        Label2.Text = s;
    }
}