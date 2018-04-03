using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test_TestImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ServiceReference2.Service1SoapClient _client2 = new ServiceReference2.Service1SoapClient();
        DataSet ds= _client2.GetNurOrdersTest("010000000002");
        DataTable dt = ds.Tables[0];
        foreach (DataRow dr in dt.Rows)
        {
            //MemoryStream buf = new MemoryStream((byte[])dr["ITEMPICTURE"]);
            //byte[] byteArray = ();
            //Response.BinaryWrite((byte[])dr["ITEMPICTURE"]);


            WritePhoto(Encoding.Default.GetBytes(dr["ITEMPICTURE"]+""));
            //MemoryStream buf = new MemoryStream(Encoding.Default.GetBytes(dr["ITEMPICTURE"] + ""));
            //System.Drawing.Image.FromStream(buf);
            //GetImageByBytes(Encoding.Default.GetBytes(dr["ITEMPICTURE"] + ""));
        }
            

     
    }
    public void WritePhoto(byte[] streamByte)
    {
        // Response.ContentType 的默认值为默认值为“text/html”  
       Response.ContentType = "image/png";
        //图片输出的类型有: image / GIF     image / JPEG
        Response.BinaryWrite(streamByte);
        //string result = Encoding.UTF8.GetString(streamByte);


        //Response.Write(result);
        //将byte数组转为string
        //string result = Encoding.UTF8.GetString(streamByte);


        //Response.Write(result);
    }

    public static System.Drawing.Image GetImageByBytes(byte[] bytes)
    {
        System.Drawing.Image photo = null;
        using (MemoryStream ms = new MemoryStream(bytes))
        {
            ms.Write(bytes, 0, bytes.Length);
            photo =System.Drawing.Image.FromStream(ms, true);
        }

        return photo;
    }
    //public static Image BytesToImage(byte[] bytes)
    //{
    //    MemoryStream ms = new MemoryStream(bytes);
    //    Image img = Image.FromStream(ms);
    //    return img;
    //}
}