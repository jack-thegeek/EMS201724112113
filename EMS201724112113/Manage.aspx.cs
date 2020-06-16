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
        protected void Page_Load(object sender, EventArgs e)
        {  
            if (Session["username"] != null)
            {
                if ((int)Session["isMgr"] == 1)
                {
                    Label2.Text = Session["username"].ToString();
                    Label1.Text = "管理员";
                }
                else
                {
                    Label1.Text = "普通用户";
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}