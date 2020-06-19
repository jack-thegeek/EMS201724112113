using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS201724112113
{
    public partial class Del : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String strConn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\\EMSdb.mdf';";
            if ((int)Session["isMgr"] == 1)
            {
                string id = Request["id"];
                string del = Request["del"];
                switch (del)
                {
                    case "eqpt":
                        using (SqlConnection conn = new SqlConnection(strConn))
                        {
                            conn.Open();
                            string sql = string.Format("delete from equipment where eqptId = '{0}'", id);
                            SqlCommand cmd = new SqlCommand(sql, conn);
                            if (cmd.ExecuteNonQuery() == 0)
                            {
                            }
                            else
                            {
                                Response.Redirect("Manage.aspx");
                            }
                        }
                        break;
                }
            }
            else
            {
                Response.Redirect("Manage.aspx");
            }
        }
    }
}