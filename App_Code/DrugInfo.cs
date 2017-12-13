using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Maticsoft.Common;
using Bright.Data;

/// <summary>
///DrugInfo 的摘要说明
/// </summary>
public class DrugInfo
{
    database_inte db = new database_inte();
	public DrugInfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public ResultDataSet GetList(string keyword)
    {
        string sql = "select top 10.药品名称,适应症,规格,id from DrugInfo where 药品名称 like '%" + keyword + "%'";
        ResultDataSet Rs=new ResultDataSet();
        db.DB4Obj.GetRs(sql, out Rs);
        return Rs;
    }
    public ResultDataSet GetList_C(string keyword)
    {
        string sql = "select top 10.药品名称,规格,功效,应用,ids from DrugInfo_C where 药品名称 like '%" + keyword + "%'";
        ResultDataSet Rs = new ResultDataSet();
        db.DB4Obj.GetRs(sql, out Rs);
        return Rs;
    }
   
}