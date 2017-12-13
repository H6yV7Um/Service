using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bright.Data;
using Maticsoft.Common;
using DTcms.Common;

public partial class order_order_edit_person : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            ResultDataSet Rs = new ResultDataSet();
            database_inte db = new database_inte();
            string strSQL = "select * from dt_order A inner join dt_order_child B on A.id=B.child_id where id='" + id + "'";
            db.DB2Obj.GetRs(strSQL, out Rs);
            if (Rs.RowCount > 0)
            {
                //details.Text = Rs[0, "details"].ToString();
                //mark.Text = Rs[0, "mark"].ToString();
                string str = Rs[0, "child_details"].ToString();
                string[] s = str.Split(new char[] { ',' });
                for (int i = 0; i < s.Length; i++)
                {
                    flow.Text += s[i] + "\n\n";
                }
                    
                //if (Rs[0, "img_url"].ToString() == "")
                //{
                //    Image1.ImageUrl = "../scripts/skin/default/noimg.jpg";
                //    Image1.Width = 200;
                //}
                //else
                //{
                //    Image1.ImageUrl = "../" + Rs[0, "img_url"].ToString();
                //    Image2.ImageUrl = "../" + Rs[0, "img_url"].ToString();
                //}
            }
            else
            {
                //Image1.ImageUrl = "../scripts/skin/default/noimg.jpg";
                //Image1.Width = 200;
            }
        }
    }
    
}