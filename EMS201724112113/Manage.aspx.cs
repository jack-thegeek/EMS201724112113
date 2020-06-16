using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS201724112113
{
    public partial class Manage : System.Web.UI.Page
    {
        private string username;
        private int isMg;
        protected void Page_Load(object sender, EventArgs e)
        {
            isMg = Convert.ToInt32(Session["isMgr"]);
            username = Session["username"].ToString();
            
            if (username == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if (isMg == 1)
            {
                Label2.Text = username;
                Label1.Text = "管理员";
            }
            else
            {
                Label1.Text = "普通用户";
            }
        }
    }
}