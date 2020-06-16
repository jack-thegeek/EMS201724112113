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
            //通过session检查是否登录，未登录直接跳去登录页面
            if (Session["username"] != null)
            {
                if ((int)Session["isMgr"] == 1)//如果是管理员
                {
                    Label1.Text = "管理员";
                }
                else//如果不是管理员
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