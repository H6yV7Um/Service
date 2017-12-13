using System;
using System.Collections.Generic;
using System.Text;
using Bright.Data;
using System.Data;
using System.Configuration;

namespace Maticsoft.Common
{
    public class database_inte
    {
        string ServerIP = ConfigurationManager.AppSettings["ServerIP"].ToString();
        string ServerDBName = ConfigurationManager.AppSettings["ServerDBName"].ToString();
        string UserID = ConfigurationManager.AppSettings["UserID"].ToString();
        string PassWord = ConfigurationManager.AppSettings["PassWord"].ToString();

        string ServerIP1 = ConfigurationManager.AppSettings["ServerIP1"].ToString();
        string ServerDBName1 = ConfigurationManager.AppSettings["ServerDBName1"].ToString();
        string UserID1 = ConfigurationManager.AppSettings["UserID1"].ToString();
        string PassWord1 = ConfigurationManager.AppSettings["PassWord1"].ToString();

        string ServerIP2 = ConfigurationManager.AppSettings["ServerIP2"].ToString();
        string ServerDBName2 = ConfigurationManager.AppSettings["ServerDBName2"].ToString();
        string UserID2 = ConfigurationManager.AppSettings["UserID2"].ToString();
        string PassWord2 = ConfigurationManager.AppSettings["PassWord2"].ToString();

        string ServerIP3 = ConfigurationManager.AppSettings["ServerIP3"].ToString();
        string ServerDBName3 = ConfigurationManager.AppSettings["ServerDBName3"].ToString();
        string UserID3 = ConfigurationManager.AppSettings["UserID3"].ToString();
        string PassWord3 = ConfigurationManager.AppSettings["PassWord3"].ToString();
        public ClsData DB2Obj
        {
            get
            {
                return new Connect().DBObj(ServerIP, ServerDBName, EnumDBType.DBSQLServer, UserID, PassWord);
            }
        }
        public ClsData DBObj
        {
            //get
            //{
            //    Connect TranObj = new Connect();
            //    return TranObj.DBObj(ServerIP1, ServerDBName1, EnumDBType.DBIBMDB2, UserID1, PassWord1);
            //}

            get
            {
                return new Connect().DBObj(ServerIP1, ServerDBName1, EnumDBType.DBSQLServer, UserID1, PassWord1);
            }

        }
        public ClsData DB3Obj
        {
            get
            {
                return new Connect().DBObj(ServerIP2, ServerDBName2, EnumDBType.DBSQLServer, UserID2, PassWord2);
            }
        }
        public ClsData DB4Obj
        {
            get
            {
                return new Connect().DBObj(ServerIP3, ServerDBName3, EnumDBType.DBSQLServer, UserID3, PassWord3);
            }
        }
        
    }
   
}
