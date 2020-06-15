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
        private string user;
        private string password;

        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            user = this.usr.Text;
            password = this.pwd.Text;

            if (CheckUser(user,password))
            {
                Label1.Text = "正在登录..."; 

            }
            else
            {
                Label1.Text = "用户名或密码错误";
            }
        }
        //查询用户是否存在，存在返回1，不存在返回0
        bool CheckUser(string user,string password)
        {
            String strConn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\\EMSdb.mdf';";
            SqlConnection conn = new SqlConnection(strConn);
            //打开数据库连接
            conn.Open();
            //设定SQL叙述
            string sql = string.Format("select * from employee where name = '{0}' and password = '{1}'",user,password);
            SqlCommand cmd = new SqlCommand(sql, conn);
            //cmd.ExecuteScalar()，如果执行的SQL语句是一个查询语句（SELECT），则返回结果是查询后的第一行的第一列
            //如果执行的SQL语句不是一个查询语句，则会返回一个未实例化的对象，必须通过类型转换来显示
            if (cmd.ExecuteScalar() == null)
            {
                return false;
            }
            else { return true; }
        }

    }
}