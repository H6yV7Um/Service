using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data;
using System.Collections;
using Maticsoft.Common;
using Bright.Data;

/// <summary>
///WebService 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {
    database_inte db = new database_inte();
    public WebService () {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }
    
    [WebMethod]
    public string[] GetList(string prefixText, int count)
    {
        string[] returnValue1 = { "阿司匹林", "阿昔洛韦" };
        string[] returnValue2 = { "刘备", "刘禅", "刘璋", "刘表" };
        switch (prefixText.ToLower())
        {
            case "阿":
                return returnValue1;
            case "zhang":
                return returnValue1;
            case "刘":
                return returnValue2;
            case "liu":
                return returnValue2;
            default:
                return new string[0];
        }
    }

    //定义数组保存获取的内容 
    private string[] autoCompleteWordList = null;
    //两个参数“prefixText”表示用户输入的前缀，count表示返回的个数 
    [WebMethod]
    public String[] GetCompleteDepart(string prefixText, int count)
    {
        DrugInfo drugInfo = new DrugInfo();
        ///检测参数是否为空 
        if (string.IsNullOrEmpty(prefixText) == true || count <= 0) return null;
        // 如果数组为空 
        if (autoCompleteWordList == null)
        {

            //string sql = "select top 10.药品名称 from DrugInfo where 药品名称 like'" + prefixText + "%'";
            //ResultDataSet Rs = new ResultDataSet();
            //db.DB4Obj.GetRs(sql, out Rs);
            
            ResultDataSet Rs = drugInfo.GetList(prefixText);
            ResultDataSet Rs2 = drugInfo.GetList_C(prefixText);
            string[] temp = null;
            if (Rs.RowCount > 0||Rs2.RowCount>0)
            {
                DataSet ds = ((DataSet)Rs);
                DataSet ds2 = ((DataSet)Rs2);
                ds.Merge(ds2);
                //读取数据库的内容 
                //OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("Ex18_02.mdb"));
                //conn.Open();
                //OleDbDataAdapter da = new OleDbDataAdapter("select keyName from keyInfo where keyName like'" + prefixText + "%' order by keyName", conn);
                //DataSet ds = new DataSet();
                //da.Fill(ds);
                //读取内容文件的数据到临时数组 
                temp = new string[ds.Tables[0].Rows.Count];
                int i = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    temp[i] = dr["药品名称"].ToString();
                    i++;
                }
                Array.Sort(temp, new CaseInsensitiveComparer());
                //将临时数组的内容赋给返回数组 
                autoCompleteWordList = temp;
                //if (conn.State == ConnectionState.Open)
                //    conn.Close();
            }
            //中药
            //ResultDataSet Rs2 = drugInfo.GetList_C(prefixText);
            //string[] temp2 = null;
            //if (Rs2.RowCount > 0)
            //{
            //    DataSet ds2 = ((DataSet)Rs2);
            //    temp2 = new string[ds2.Tables[0].Rows.Count];
            //    int j = 0;
            //    foreach (DataRow dr in ds2.Tables[0].Rows)
            //    {
            //        temp2[j] = dr["药品名称"].ToString();
            //        j++;
            //    }
            //    Array.Sort(temp2, new CaseInsensitiveComparer());
            //}
            //string[] s3 = new string[temp.Length + temp2.Length];
            //Array.Copy(temp, 0, s3, 0, temp.Length);
            //Array.Copy(temp2, 0, s3, temp.Length, temp2.Length);
            //autoCompleteWordList = s3;


        }
        //定位二叉树搜索的起点 
        int index = Array.BinarySearch(autoCompleteWordList, prefixText, new CaseInsensitiveComparer());
        if (index < 0)
        { //修正起点 
            index = ~index;
        }
        //搜索符合条件的数据 
        int matchCount = 0;
        for (matchCount = 0; matchCount < count && matchCount + index < autoCompleteWordList.Length; matchCount++)
        { ///查看开头字符串相同的项 
            if (autoCompleteWordList[index + matchCount].StartsWith(prefixText, StringComparison.CurrentCultureIgnoreCase) == false)
            {
                break;
            }
        }
        //处理搜索结果 
        string[] matchResultList = new string[matchCount];
        if (matchCount > 0)
        { //复制搜索结果 
            Array.Copy(autoCompleteWordList, index, matchResultList, 0, matchCount);
        }
        return matchResultList;
    } 
    
}
