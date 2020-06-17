using EMS201724112113.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS201724112113
{
    public partial class Manage_emp : System.Web.UI.Page
    {
        public List<EmpEntity> emplist = new List<EmpEntity>();
        private String strConn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\\EMSdb.mdf';";

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

            GetAll();
        }
        void GetAll()
        {
            using (SqlConnection conn = new SqlConnection(strConn))//使用using的方式系统自动关闭连接
            {
                //打开数据库连接
                conn.Open();
                //设定SQL叙述
                string sql = string.Format("select e.empId,e.password,e.name,e.phone,e.isMgr,d.deptName " +
                    "from department d, employee e " +
                    "where d.deptId = e.deptId");
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EmpEntity empEntity = new EmpEntity();
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        empEntity.EmpId = int.Parse(dr[0].ToString());
                        empEntity.Password = dr[1].ToString();
                        empEntity.Name = dr[2].ToString();
                        empEntity.Phone = dr[3].ToString();
                        empEntity.IsMgr =  dr[4].ToString() == "True" ? "是" : "否";
                        empEntity.Dept = dr[5].ToString();
                    }
                    emplist.Add(empEntity);
                }
            }
        }
    }
}