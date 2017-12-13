using System;
using System.Collections.Generic;
using System.Web;
using Bright.Data;
using Maticsoft.Common;
using System.Data;
using System.Text;

namespace DBWebService
{
    public class SqlDB
    {
        public string getRealName(string user_name)
        {
            string real_name = "";
            ResultDataSet Rs = new ResultDataSet();
            database_inte db = new database_inte();
            string strSQL = "select real_name from dt_manager where user_name='" + user_name + "'";
            db.DB2Obj.GetRs(strSQL, out Rs);
            if (Rs.RowCount > 0)
            {
                real_name = Rs[0, "real_name"].ToString();
            }
            return real_name;
        }
        public int getOrderCount(string sql)
        {
            int totalCount = 0;
            ResultDataSet Rs = new ResultDataSet();
            database_inte db = new database_inte();
            db.DB2Obj.GetRs(sql, out Rs);
            if (Rs.RowCount > 0)
            {
                totalCount = Rs.RowCount;
            }
            return totalCount;
        }

        public string getType(string _user)
        {
            string str = "0";
            if (!String.IsNullOrEmpty(_user))
            {
                try
                {
                    ResultDataSet Rs = new ResultDataSet();
                    database_inte db = new database_inte();
                    string strSQL = "select typeName from dt_type_list where typeName like '%" + _user + "%'";
                    db.DB2Obj.GetRs(strSQL, out Rs);
                    if (Rs.RowCount > 0)
                    {
                        str = Rs[0, "typeName"].ToString();
                    }
                    else
                    {
                        str = "0";
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return str;
        }
        public string checkNumber(string _user)
        {
            string str = "0";
            try
            {
                ResultDataSet Rs = new ResultDataSet();
                database_inte db = new database_inte();
                string strSQL = "select UserId,UserName from Users where UserId='" + _user + "' or UserName='"+_user+"'";
                db.DBObj.GetRs(strSQL, out Rs);
                if (Rs.RowCount > 0)
                {
                    str = Rs[0,"UserName"].ToString();
                }
                else
                {
                    ResultDataSet Rs2 = new ResultDataSet();
                    string strSQL2 = "select real_name from dt_manager where user_name='" + _user + "' or real_name='" + _user + "'";
                    db.DB2Obj.GetRs(strSQL2, out Rs2);
                    if (Rs2.RowCount > 0)
                    {
                        str = Rs2[0, "real_name"].ToString();
                    }
                    else
                    {
                        str = "0";
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return str;
        }
        /// <summary>      
        /// dataTable转换成Json格式      
        /// </summary>      
        /// <param name="dt"></param>      
        /// <returns></returns>      
        public static string ToJson(DataTable dt)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            //jsonBuilder.Append("{\"");
            //jsonBuilder.Append(dt.TableName.ToString());
            jsonBuilder.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Columns[j].ColumnName);
                    jsonBuilder.Append("\":\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString());
                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]");
            //jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }
        public static string CreateJsonParameters(DataTable dt, bool displayCount, int totalcount)
        {
            StringBuilder JsonString = new StringBuilder();
            //Exception Handling        
            if (dt != null)
            {
                JsonString.Append("{ ");
                if (displayCount)
                {
                    JsonString.Append("\"total\":");
                    JsonString.Append(totalcount);
                    JsonString.Append(",");
                }
                JsonString.Append("\"rows\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    JsonString.Append("{ ");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j < dt.Columns.Count - 1)
                        {
                            //if (dt.Rows[i][j] == DBNull.Value) continue;
                            if (dt.Columns[j].DataType == typeof(bool))
                            {
                                JsonString.Append("\"" + dt.Columns[j].ColumnName + "\":" +
                                                  dt.Rows[i][j].ToString().ToLower() + ",");
                            }
                            else if (dt.Columns[j].DataType == typeof(string))
                            {
                                JsonString.Append("\"" + dt.Columns[j].ColumnName + "\":" + "\"" +
                                                  dt.Rows[i][j].ToString().Replace("\"", "\\\"") + "\",");
                            }
                            else
                            {
                                JsonString.Append("\"" + dt.Columns[j].ColumnName + "\":" + "\"" + dt.Rows[i][j] + "\",");
                            }
                        }
                        else if (j == dt.Columns.Count - 1)
                        {
                            //if (dt.Rows[i][j] == DBNull.Value) continue;
                            if (dt.Columns[j].DataType == typeof(bool))
                            {
                                JsonString.Append("\"" + dt.Columns[j].ColumnName + "\":" +
                                                  dt.Rows[i][j].ToString());
                            }
                            else if (dt.Columns[j].DataType == typeof(string))
                            {
                                JsonString.Append("\"" + dt.Columns[j].ColumnName + "\":" + "\"" +
                                                  dt.Rows[i][j].ToString().Replace("\"", "\\\"") + "\"");
                            }
                            else
                            {
                                JsonString.Append("\"" + dt.Columns[j].ColumnName+ "\":" + "\"" + dt.Rows[i][j] + "\"");
                            }
                        }
                    }
                    /*end Of String*/
                    if (i == dt.Rows.Count - 1)
                    {
                        JsonString.Append("} ");
                    }
                    else
                    {
                        JsonString.Append("}, ");
                    }
                }
                JsonString.Append("]");
                JsonString.Append("}");
                return JsonString.ToString().Replace("\n", "");
            }
            else
            {
                return null;
            }
        }
        public string getMenu(string id,string _roleid)
        {
            string sql = "select id,text,state,iconCls,url from Menu where nid='" + id + "' and roleid='" + _roleid + "'";
            ResultDataSet Rs = new ResultDataSet();
            database_inte db = new database_inte();
            db.DB2Obj.GetRs(sql, out Rs);
            DataTable dt = ((DataSet)Rs).Tables[0];
            string menu = ToJson(dt);
            return menu;
        }
        public string getweek(string bingqu)
        {
            string sql = "select * from PatientRecord where (SELECT   dateadd(ms,-3,DATEADD(mm,   DATEDIFF(mm,0,getdate()),   0)))< pr_todate and pr_todate <(SELECT   dateadd(ms,-3,DATEADD(mm,   DATEDIFF(m,0,getdate())+1,   0))) and (pr_body ='' or pr_body is null) and pr_bingqu='"+bingqu+"' order by pr_todate asc";
            ResultDataSet Rs = new ResultDataSet();
            database_inte db = new database_inte();
            db.DB2Obj.GetRs(sql, out Rs);
            DataTable dt = ((DataSet)Rs).Tables[0];
            string menu = ToJson(dt);
            return menu;
        }
        public int getTestCount()
        {
            int totalCount = 0;
            string sql = "select * from TestData";
            ResultDataSet Rs = new ResultDataSet();
            database_inte db = new database_inte();
            db.DB2Obj.GetRs(sql, out Rs);
            if (Rs.RowCount > 0)
            {
                totalCount = Rs.RowCount;
            }
            return totalCount;
        }
        public string getTest(string rows, string page)
        {
            int _rows = Convert.ToInt32(rows);
            int _page = Convert.ToInt32(page);
            string sql = "select top " + rows + " * from TestData where testID not in(select top " + (_rows * (_page - 1)) + " testID from TestData order by testID desc) order by testID desc";
            ResultDataSet Rs = new ResultDataSet();
            database_inte db = new database_inte();
            db.DB2Obj.GetRs(sql, out Rs);
            DataTable dt = ((DataSet)Rs).Tables[0];
            string menu = CreateJsonParameters(dt, true, getTestCount());
            return menu;
        }
        public string getTestSearch(string rows, string page,string title)
        {
            int _rows = Convert.ToInt32(rows);
            int _page = Convert.ToInt32(page);
            string sql = "select top " + rows + " * from TestData where testID not in(select top " + (_rows * (_page - 1)) + " testID from TestData order by testID) and testTitle like '%"+title+"%' order by testID";
            ResultDataSet Rs = new ResultDataSet();
            database_inte db = new database_inte();
            db.DB2Obj.GetRs(sql, out Rs);
            DataTable dt = ((DataSet)Rs).Tables[0];
            string menu = CreateJsonParameters(dt, true, getTestCount());
            return menu;
        }
        public int deletetest(string ids)
        {
            int str = 0;
            try
            {
                ResultDataSet Rs = new ResultDataSet();
                database_inte db = new database_inte();
                string sql = "delete from TestData where testID in ("+ids+")";
                if (db.DB2Obj.Exec(sql))
                {
                    str = 1;
                }
                else
                {
                    str = 0;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return str;
        }
        public int addtest(string title,string content)
        {
            int str = 0;
            string creatime = DateTime.Now.ToString();
            try
            {
                ResultDataSet Rs = new ResultDataSet();
                database_inte db = new database_inte();
                string sql = "insert into TestData (testTitle,testContent,testDate) values ('" + title + "','" + content + "','" + creatime + "')";
                if (db.DB2Obj.Exec(sql))
                {
                    str = 1;
                }
                else
                {
                    str = 0;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return str;
        }
        public string getTest2(string id)
        {

            string sql = "select * from TestData where testID='"+id+"'";
            ResultDataSet Rs = new ResultDataSet();
            database_inte db = new database_inte();
            db.DB2Obj.GetRs(sql, out Rs);
            DataTable dt = ((DataSet)Rs).Tables[0];
            string menu = ToJson(dt);
            return menu;
        }
        public int edittest(string id,string title,string content)
        {
            int str = 0;
            string creatime = DateTime.Now.ToString();
            try
            {
                ResultDataSet Rs = new ResultDataSet();
                database_inte db = new database_inte();
                string sql = "update TestData set testTitle='" + title + "' ,testContent='" + content + "' where testID='" + id + "'";
                if (db.DB2Obj.Exec(sql))
                {
                    str = 1;
                }
                else
                {
                    str = 0;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return str;
        }
        //添加用户
        public String addUser(string Name,string Number,string Password,string Tel,string Identity,string CrateTime)
        {
            string str = "";
            try
            {
                string jiami = System.Encryption.MD5.MDString(Password);
                ResultDataSet Rs = new ResultDataSet();
                database_inte db = new database_inte();
                string sql = "insert into PatientInfo (Pi_Name,Pi_Number,Pi_Password,Pi_Tel,Pi_Identity,Pi_CrateTime) values ('" + Name + "','" + Number + "','" + jiami + "','" + Tel + "','" + Identity + "','" + CrateTime + "')";
                if (db.DB2Obj.Exec(sql))
                {
                    str = "ok";
                }
                else
                {
                    str = "no";
                }
            }
            catch (Exception)
            {
                
                throw;
            }

            return str;
        }
        //验证登录
        public String login(String password, String username)
        {
            string jiami = System.Encryption.MD5.MDString(password);
            string str = "";
            try
            {
                ResultDataSet Rs = new ResultDataSet();
                database_inte db = new database_inte();
                string strSQL = "select * from PatientInfo where Pi_Password = '" + jiami + "' and Pi_Number = '" + username + "'";
                db.DB2Obj.GetRs(strSQL, out Rs);
                if (Rs.RowCount > 0)
                {
                    str = "1";
                }
                else
                {
                    str = "0";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return str;
        }
        //查询用户
        public List<string> selectStuAll()
        {
            List<string> list = new List<string>();

            try
            {
                ResultDataSet Rs = new ResultDataSet();
                database_inte db = new database_inte();
                string strSQL="select * from Appuser";
                db.DB2Obj.GetRs(strSQL, out Rs);

                for (int i = 0; i < Rs.RowCount;i++ )
                {
                    //将结果集信息添加到返回向量中
                    list.Add(Rs[i,0].ToString());
                    list.Add(Rs[i,1].ToString());
                    list.Add(Rs[i,2].ToString());
                    
                }

            }
            catch (Exception)
            {

            }
            return list;
        }
        //验证用户名和密码
        public string checkUername(string _user,string _password)
        {
            string str = "";
            try
            {
                //1c395a8dce135849bd73c6dba3b54809
                string jiami = System.Encryption.MD5.MDString(_password);
                ResultDataSet Rs = new ResultDataSet();
                database_inte db = new database_inte();
                string strSQL = "select LOGINNAME,EMPID, EMPPASSWORD, EMPNAME from BHD03030 where LOGINNAME='" + _user + "'and EMPPASSWORD='" + jiami + "'";
                db.DBObj.GetRs(strSQL, out Rs);
                if (Rs.RowCount > 0)
                {
                    str = "1";
                }
                else
                {
                    str = "0";
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            return str;
        }

        //获取医生姓名
        public string getName(string _user)
        {
            string _username = "";
            try
            {
                ResultDataSet Rs = new ResultDataSet();
                database_inte db = new database_inte();
                string strSQL = "select LOGINNAME,EMPID, EMPPASSWORD, EMPNAME from BHD03030 where LOGINNAME='" + _user + "'";
                db.DBObj.GetRs(strSQL, out Rs);
                if (Rs.RowCount > 0)
                {
                    _username = Rs[0, "EMPNAME"].ToString();
                }
                else
                {
                    _username = "admin";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return _username;
        }
        //获取医生所在病区
        public string getBingQu(string _user)
        {
            string _username = "";
            try
            {
                ResultDataSet Rs = new ResultDataSet();
                database_inte db = new database_inte();
                string strSQL = "select BHD03010.OrgName from BHD03030 inner join BHD03010 on BHD03010.OrgID=BHD03030.OrgID where LoginName='" + _user + "'";
                db.DBObj.GetRs(strSQL, out Rs);
                if (Rs.RowCount > 0)
                {
                    _username = Rs[0, "OrgName"].ToString();
                }
                else
                {
                    _username = "";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return _username;
        }
        //获取病人姓名
        public string getPatientName(string _user)
        {
            string _username = "";
            try
            {
                ResultDataSet Rs = new ResultDataSet();
                database_inte db = new database_inte();
                string strSQL = "select BPI01010.PatiName from BIW01020 inner join BPI01010 on BIW01020.PatiID=BPI01010.PatiID where InPatiID='" + _user + "'";
                db.DBObj.GetRs(strSQL, out Rs);
                if (Rs.RowCount > 0)
                {
                    _username = Rs[0, "PatiName"].ToString();
                }
                else
                {
                    _username = "admin";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return _username;
        }
        public string checkZYH(string zyh)
        {
            string _username = "0";
            try
            {
                ResultDataSet Rs = new ResultDataSet();
                database_inte db = new database_inte();
                string strSQL = "select * from BIW01020 where InPatiID='"+zyh+"'";
                db.DBObj.GetRs(strSQL, out Rs);
                if (Rs.RowCount > 0)
                {
                    _username = Rs[0, "InPatiID"].ToString();
                }
                else
                {
                    _username = "0";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return _username;
        }
        //添加用户信息
        public String addUserInfo(String name, String ID, String tel, String hospitalID, String appuserName)
        {
            try
            {
                ResultDataSet Rs = new ResultDataSet();
                database_inte db = new database_inte();
                string sql = "insert into UserInfo (name,ID,tel,hospitalID,appuserName) values ('"+name+"','"+ID+"','"+tel+"','"+hospitalID+"','"+appuserName+"')";
                db.DB2Obj.Exec(sql);
            }
            catch (Exception)
            {

                throw;
            }

            return "1";
        }
        //判断是否存在用户信息
        public String checkUserInfo(String appuserName)
        {
            String _appuserName = "";
            try
            {
                ResultDataSet Rs = new ResultDataSet();
                database_inte db = new database_inte();
                string strSQL = "select * from UserInfo where appuserName='"+appuserName+"'";
                db.DB2Obj.GetRs(strSQL, out Rs);
                if (Rs.RowCount > 0)
                {
                    _appuserName = Rs[0, 4].ToString();
                }
                else
                {
                    _appuserName = "qwer";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return _appuserName;
        }
        //查询用户信息
        public List<string> selectUserInfo(String appuserName)
        {
            List<string> list = new List<string>();

            try
            {
                ResultDataSet Rs = new ResultDataSet();
                database_inte db = new database_inte();
                string strSQL = "select * from UserInfo where appuserName='" + appuserName + "'";
                db.DB2Obj.GetRs(strSQL, out Rs);
                if (Rs.RowCount > 0)
                {
                    for (int i = 0; i < Rs.RowCount; i++)
                    {
                        //将结果集信息添加到返回向量中
                        list.Add(Rs[i, 0].ToString());
                        list.Add(Rs[i, 1].ToString());
                        list.Add(Rs[i, 2].ToString());
                        list.Add(Rs[i, 3].ToString());
                    }
                }
                else
                {
                    list.Add("qwer");
                    list.Add("qwer");
                    list.Add("qwer");
                    list.Add("qwer");
                }

            }
            catch (Exception)
            {

            }
            return list;
        }
        //删除用户信息
        public String deleteUserInfo(String appuserName)
        {
            try
            {
                ResultDataSet Rs = new ResultDataSet();
                database_inte db = new database_inte();
                string sql = "delete from UserInfo where appuserName='"+appuserName+"'";
                db.DB2Obj.Exec(sql);
            }
            catch (Exception)
            {

                throw;
            }

            return "1";
        }
        //获取护士姓名
        public String[] getNuseInfo(String username)
        {
            string[] _username = new string[2];
            try
            {
                ResultDataSet Rs = new ResultDataSet();
                database_inte db = new database_inte();
                string strSQL = "select * from Appuser inner join Department on Appuser.departmentID=Department.departmentID where appuserName = '" + username + "'";
                db.DB2Obj.GetRs(strSQL, out Rs);
                if (Rs.RowCount > 0)
                {
                    _username[0] = Rs[0,"nuseName"].ToString();
                    _username[1] = Rs[0, "departmentName"].ToString();
                }
                else
                {
                    _username[0] = "qwer";
                    _username[1] = "qwer";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return _username;
        }
        //获取病人信息
        public List<string> selectPatientInfo(String appuserName)
        {
            List<string> list = new List<string>();

            try
            {
                ResultDataSet Rs = new ResultDataSet();
                database_inte db = new database_inte();
                string strSQL = "select * from Appuser inner join Patient on Appuser.departmentID=Patient.departmentID where appuserName='" + appuserName + "'";
                db.DB2Obj.GetRs(strSQL, out Rs);
                if (Rs.RowCount > 0)
                {
                    for (int i = 0; i < Rs.RowCount; i++)
                    {
                        //将结果集信息添加到返回向量中
                        list.Add(Rs[i, "patientID"].ToString());
                        list.Add(Rs[i, "patientBedNumber"].ToString());
                        list.Add(Rs[i, "patientName"].ToString());
                    }
                }
                else
                {
                    list.Add("qwer");
                    list.Add("qwer");
                    list.Add("qwer");
                }

            }
            catch (Exception)
            {

            }
            return list;
        }
        //获取病人详细信息
        public List<string> wholePatientInfo(int patientID)
        {
            List<string> list = new List<string>();

            try
            {
                ResultDataSet Rs = new ResultDataSet();
                database_inte db = new database_inte();
                string strSQL = "select * from Patient inner join Department on Patient.departmentID=Department.departmentID where patientID='" + patientID + "'";
                db.DB2Obj.GetRs(strSQL, out Rs);
                if (Rs.RowCount > 0)
                {
                    for (int i = 0; i < Rs.RowCount; i++)
                    {
                        //将结果集信息添加到返回向量中
                        list.Add(Rs[i, "departmentName"].ToString());
                        list.Add(Rs[i, "patientContent"].ToString());
                        list.Add(Rs[i, "patientName"].ToString());
                    }
                }
                else
                {
                    list.Add("qwer");
                    list.Add("qwer");
                    list.Add("qwer");
                }

            }
            catch (Exception)
            {

            }
            return list;
        }
    }
}