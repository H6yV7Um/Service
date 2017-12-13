using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class appfiles_AppDownload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action=Request.QueryString["action"];
        if (!String.IsNullOrEmpty(action))
        {
            switch (action)
            {
                case "app": DownloadFile("~/appfiles/BarCodeTest.apk", "BarCodeTest.apk");
                    break;
                case "version": DownloadFile("~/appfiles/HisVersions.xml", "HisVersions.xml");
                    break;
                default:
                    break;
            }
        }
        
        
    }
    private void DownloadFile(string _filepath, string _filename)
    {
        if (System.IO.File.Exists(MapPath(_filepath)))
        {
            Response.Clear();
            Response.Buffer = true;

            Response.AddHeader("Content-Disposition", "attachment;filename=" + _filename);
            Response.ContentType = "application/unknow";
            Response.TransmitFile(_filepath);
            Response.End();

        }
    }
}