<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using DTcms.Common;
using DTcms.Web.UI;
using DBWebService;
public class Handler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{

    SqlDB db = new SqlDB();
    public void ProcessRequest(HttpContext context)
    {
        //取得处事类型
        string action = DTRequest.GetQueryString("action");

        switch (action)
        {
            case "EditorFile": //编辑器文件
                //EditorFile(context);
                break;
            case "ManagerFile": //管理文件
                //ManagerFile(context);
                break;
            case "checkNumber":
                checkNumber(context);
                break;
            case "checkSession":
                checkSession(context);
                break;
            case "getType":
                getType(context);
                break;
            case "record":
                getrecord(context);
                break;
            default: //普通上传
                UpLoadFile(context);
                break;
        }
    }
    private void getrecord(HttpContext context)
    {

        int movieID = DTRequest.GetFormIntValue("movieID");
        string username = DTRequest.GetFormString("username").Trim();
        int state = DTRequest.GetFormIntValue("state");
        string currenttimestate = DTRequest.GetFormString("currenttimestate").Trim();
        if(db.getRecord(username,movieID,state,currenttimestate)== "0")
        {
            context.Response.Write("0");
        }
        else
        {
            context.Response.Write("1");
        }

    }
    private void checkSession(HttpContext context)
    {
        if (context.Session["user_name"] == null || context.Session["role_id"] == null || context.Session["group_id"] == null)
        {
            context.Response.Write("1");
        }
        else
        {
            context.Response.Write("0");
        }
    }
    private void getType(HttpContext context)
    {

        string _number = DTRequest.GetFormString("number").Trim();
        if (_number.Length > 2)
        {
            _number = _number.Substring(0, 2);
        }
        if (db.getType(_number) == "0")
        {
            context.Response.Write("0");
        }
        else
        {
            context.Response.Write(db.getType(_number));
        }

    }

    private void checkNumber(HttpContext context)
    {

        string _number = DTRequest.GetFormString("number").Trim();
        if (db.checkNumber(_number) != "0")
        {
            context.Response.Write(db.checkNumber(_number));
        }
        else
        {
            context.Response.Write("0");
        }

    }
    #region 上传文件处理===================================
    private void UpLoadFile(HttpContext context)
    {
        string _delfile = DTRequest.GetString("DelFilePath");
        HttpPostedFile _upfile = context.Request.Files["Filedata"];
        bool _iswater = false; //默认不打水印
        bool _isthumbnail = false; //默认不生成缩略图

        if (DTRequest.GetQueryString("IsWater") == "1")
            _iswater = true;
        if (DTRequest.GetQueryString("IsThumbnail") == "1")
            _isthumbnail = true;
        if (_upfile == null)
        {
            context.Response.Write("{\"status\": 0, \"msg\": \"请选择要上传文件！\"}");
            return;
        }
        UpLoad upFiles = new UpLoad();
        string msg = upFiles.fileSaveAs(_upfile, _isthumbnail, _iswater);
        //删除已存在的旧文件
        if (!string.IsNullOrEmpty(_delfile))
        {
            Utils.DeleteUpFile(_delfile);
        }
        //返回成功信息
        context.Response.Write(msg);
        context.Response.End();
    }
    #endregion

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}