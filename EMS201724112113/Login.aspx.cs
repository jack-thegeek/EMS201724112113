using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS201724112113
{
    public partial class Login : System.Web.UI.Page
    {
        private string id;
        private string password;
        private string username;
        private int isMgr;

        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            id = this.empId.Text;
            password = this.pwd.Text;
            CheckUser(id, password);

            if (username != null)
            {
                Label1.Text = isMgr.ToString();
                //Label2.Text = name;
                //session保存在服务端，后台管理系统使用session更安全
                //把用户名和是否是管理员传递到管理页面
                Session["username"] = username;
                Session["isMgr"] = isMgr;
                Response.Redirect("Manage.aspx");
            }
            else
            {
                Label1.Text = "请检查工号或密码";
            }
        }
        //查询用户是否存在
        void CheckUser(string id,string password)
        {
            String strConn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\\EMSdb.mdf';";
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            string sql = string.Format("select name,isMgr from employee where empId = '{0}' and password = '{1}'",id,password);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dataReader;
            dataReader = cmd.ExecuteReader();
            if (dataReader.Read() == false)
            {
                username = null;
            }
            else {
                username = dataReader[0].ToString();
                isMgr = dataReader[1].ToString() == "True" ? 1 : 0;
            }
        }

    }
}