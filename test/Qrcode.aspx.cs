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


public partial class test_Qrcode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //{ "hospital_id":"syzyyadmin","totle_amt":"0.01","visit_id":"","patient_id":"","real_name":"","id_card":"","data_src":"hisSrc","biz_id":"bf31e315-36a3-4809-b148-5a1e5d0e60db","pay_type":"wechatNo","sign":"5CBAD6EC4A50E59B777E547BF1FADA81"}
        //{ "message":"创建订单失败","result":"ERROR"}
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string hospital_id = "syzyyadmin";
        string totle_amt = "0.01";
        string visit_id = "";
        string patient_id = "";
        string real_name = "";
        string id_card = "";
        string data_src = "hisSrc";
        string biz_id = Guid.NewGuid().ToString();
        string pay_type = "alipayQrcode";//alipayQrcode,wechatQrcode
        string sign = "92278c4d91304ca383a9e4c9dfe80b44"; //92278c4d91304ca383a9e4c9dfe80b44
        string JsonStr = createOrder(hospital_id,totle_amt,visit_id,patient_id,real_name,id_card,data_src,biz_id,pay_type,sign);
        //JObject jo = (JObject)JsonConvert.DeserializeObject(JsonStr);
        //string zone = jo["result"].ToString();
        //string zone_en = jo["message"].ToString();
        //if (jo["data"] != null)
        //{
        //    string signs = jo["data"]["sign"].ToString();
        //    Response.Write(signs + "!!!");
        //}
        Response.Write(JsonStr);
    }
    
    private string createOrder(string hospital_id, string totle_amt, string visit_id, string patient_id, string real_name, string id_card, string data_src, string biz_id, string pay_type,string sign)
    {
        try
        {
            if (!String.IsNullOrEmpty(hospital_id) && !String.IsNullOrEmpty(totle_amt) && !String.IsNullOrEmpty(data_src) && !String.IsNullOrEmpty(biz_id) && !String.IsNullOrEmpty(pay_type) && !String.IsNullOrEmpty(sign))
            {
                //ServiceReferenceCreate.TicketPayWebServiceClient _client = new ServiceReferenceCreate.TicketPayWebServiceClient();
                //ServiceReferenceQrTest.TicketPayWebServiceV2Client _client = new ServiceReferenceQrTest.TicketPayWebServiceV2Client();
                ServiceReferenceV2Create.TicketPayWebServiceV2Client _client = new ServiceReferenceV2Create.TicketPayWebServiceV2Client();
                IDictionary<string, string> para = new Dictionary<string, string>();
                para.Add("hospital_id", hospital_id);
                para.Add("totle_amt", totle_amt);
                para.Add("visit_id", visit_id);
                para.Add("patient_id", patient_id);
                para.Add("real_name", real_name);
                para.Add("id_card", id_card);
                para.Add("data_src", data_src);
                para.Add("biz_id", biz_id);
                para.Add("pay_type", pay_type);
                string signs = GetMD5Key(para, sign);//B9EB02AAD7DAB96B58A0D34CC2E12952
                string result = "{\"hospital_id\":\"" + hospital_id + "\",\"totle_amt\":\"" + totle_amt + "\",\"visit_id\":\"" + visit_id + "\",\"patient_id\":\"" + patient_id + "\",\"real_name\":\"" + real_name + "\",\"id_card\":\"" + id_card + "\",\"data_src\":\"" + data_src + "\",\"biz_id\":\"" + biz_id + "\",\"pay_type\":\"" + pay_type + "\",\"sign\":\"" + signs + "\"}";
                return _client.createOrder(result);

            }
            return "";
        }
        catch (Exception)
        {

            return "";
        }

    }
    private string GetMD5Key(IDictionary<string, string> parameters, string key)
    {
        List<string> list = new List<string>();
        foreach (KeyValuePair<string, string> kvp in parameters)
        {
            if (!String.IsNullOrEmpty(kvp.Value))
            {
                list.Add(kvp.Key + "=" + kvp.Value + "&");
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
        result += "key=" + key;
        result = result.Trim();
        result = GetMd5Hash(result);
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
}