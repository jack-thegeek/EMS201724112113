using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS201724112113
{
    public partial class CreatDept : System.Web.UI.Page
    {
        String strConn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\\EMSdb.mdf';";
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                string sql = string.Format("insert into department (deptName,deptMgrId) values(" +
                    "N'{0}',{1});",deptName.Text,DropDownList1.SelectedValue);
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    Label3.Text = "新建成功";
                }
                else
                {
                    Label3.Text = "新建失败";
                }
            }
        }


    }
}