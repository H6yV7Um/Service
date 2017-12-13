using System;
using System.Collections;
using System.Web;
using System.IO;
using System.Drawing;
using System.Net;
using System.Configuration;
using DTcms.Common;

namespace DTcms.Web.UI
{
    public class UpLoad
    {
        /// <summary>
        /// 文件上传方法
        /// </summary>
        /// <param name="postedFile">文件流</param>
        /// <param name="isThumbnail">是否生成缩略图</param>
        /// <param name="isWater">是否打水印</param>
        /// <returns>上传后文件信息</returns>
        public string fileSaveAs(HttpPostedFile postedFile, bool isThumbnail, bool isWater)
        {
            try
            {
                //string fileExt = Utils.GetFileExt(postedFile.FileName); //文件扩展名，不含“.”
                string fileExt = Path.GetExtension(postedFile.FileName); 
                int fileSize = postedFile.ContentLength; //获得文件大小，以字节为单位
                string fileName = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf(@"\") + 1); //取得原文件名
                string newFileName = Utils.GetRamCode() + fileExt; //随机生成新的文件名
                string newThumbnailFileName = "thumb_" + newFileName; //随机生成缩略图文件名
                string upLoadPath = GetUpLoadPath(); //上传目录相对路径
                string fullUpLoadPath = Utils.GetMapPath(upLoadPath); //上传目录的物理路径
                string newFilePath = upLoadPath + newFileName; //上传后的路径
                string newThumbnailPath = upLoadPath + newThumbnailFileName; //上传后的缩略图路径

                ////检查文件扩展名是否合法
                //if (!CheckFileExt(fileExt))
                //{
                //    return "{\"status\": 0, \"msg\": \"不允许上传" + fileExt + "类型的文件！\"}";
                //}
                ////检查文件大小是否合法
                //if (!CheckFileSize(fileExt, fileSize))
                //{
                //    return "{\"status\": 0, \"msg\": \"文件超过限制的大小啦！\"}";
                //}
                //检查上传的物理路径是否存在，不存在则创建
                if (!Directory.Exists(fullUpLoadPath))
                {
                    Directory.CreateDirectory(fullUpLoadPath);
                }
                string userAgent = HttpContext.Current.Request.UserAgent;
                if (userAgent.ToLower().Contains("micromessenger"))
                {
                    postedFile.SaveAs(fullUpLoadPath + newFileName + ".jpg");
                }
                else
                {
                    //保存文件
                    postedFile.SaveAs(fullUpLoadPath + newFileName);
                }
                
                //处理完毕，返回JOSN格式的文件信息
                //return "{\"status\": 1, \"msg\": \"上传文件成功！\", \"name\": \""
                //    + fileName + "\", \"path\": \"" + newFilePath + "\", \"thumb\": \""
                //    + newThumbnailPath + "\", \"size\": " + fileSize + ", \"ext\": \"" + fileExt + "\"}";
                return newFilePath;
            }
            catch
            {
                return "{\"status\": 0, \"msg\": \"上传过程中发生意外错误！\"}";
            }
        }
        public string GetUpLoadPath()
        {
            string path = "~/upload/"; //站点目录+上传目录
            path += DateTime.Now.ToString("yyyyMM") + "/" + DateTime.Now.ToString("dd");
            return path + "/";
        }
        public ArrayList fileSaveAs2(HttpPostedFile postedFile,string _newFileName)
        {
            ArrayList array = new ArrayList();
            try
            {
                
                string fileExt = Path.GetExtension(postedFile.FileName);
                int fileSize = postedFile.ContentLength; //获得文件大小，以字节为单位
                string fileName = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf(@"\") + 1); //取得原文件名
                string upLoadPath = GetUpLoadPath(); //上传目录相对路径
                string fullUpLoadPath = Utils.GetMapPath(upLoadPath); //上传目录的物理路径
                string newFileName = _newFileName + fileExt; //随机生成新的文件名
                string newFilePath = upLoadPath + newFileName; //上传后的路径

                //检查上传的物理路径是否存在，不存在则创建
                if (!Directory.Exists(fullUpLoadPath))
                {
                    Directory.CreateDirectory(fullUpLoadPath);
                }

                array.Add(fileExt);
                array.Add(fileSize);
                
                if (String.IsNullOrEmpty(_newFileName))
                {
                    postedFile.SaveAs(fullUpLoadPath + fileName);
                    array.Add(fileName);
                    array.Add(upLoadPath + fileName);
                }
                else
                {
                    postedFile.SaveAs(fullUpLoadPath + newFileName);
                    array.Add(newFileName);
                    array.Add(newFilePath);
                }
                
                
                return array;
            }
            catch
            {

                return array;
            }
        }

    }
}
