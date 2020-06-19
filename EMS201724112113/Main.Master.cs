using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS201724112113
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //通过session检查是否登录，未登录直接跳去登录页面
            if (Session["username"] != null)
            {
                Label1.Text = Session["username"].ToString();
                if ((int)Session["isMgr"] == 1)//如果是管理员
                {
                    Label2.Text = "管理员";
                }
                else//如果不是管理员,隐藏部分菜单
                {
                    mgt_dept.Visible = false;
                    mgt_emp.Visible = false;
                    Label2.Text = "普通用户（只读权限）";
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}