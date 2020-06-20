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
    public partial class Edit_employee : System.Web.UI.Page
    {
        String strConn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\\EMSdb.mdf';";
        public string id;
        public EmpEntity empEntity = new EmpEntity();
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["id"];
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            GetEmp();
            if (!IsPostBack)
            {
                txtId.Text = empEntity.EmpId.ToString();
                txtPwd.Text = empEntity.Password;
                txtName.Text = empEntity.Name;
                txtPhone.Text = empEntity.Phone;
                txtDept.Text = "原所属："+ empEntity.Dept;
                txtIsMgr.Text = "原权限："+empEntity.IsMgr;
            }
        }

        void GetEmp()
        {
            using (SqlConnection conn = new SqlConnection(strConn))//使用using的方式系统自动关闭连接
            {
                conn.Open();
                string sql = string.Format("select e.empId,e.password,e.name,e.phone,e.isMgr,d.deptName " +
                    "from department d, employee e " +
                    "where d.deptId = e.deptId and e.empId = {0}",id);
                Label2.Text = sql;
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        empEntity.EmpId = int.Parse(dr[0].ToString());
                        empEntity.Password = dr[1].ToString();
                        empEntity.Name = dr[2].ToString();
                        empEntity.Phone = dr[3].ToString();
                        empEntity.IsMgr = dr[4].ToString() == "True" ? "是" : "否";
                        empEntity.Dept = dr[5].ToString();
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(strConn))//使用using的方式系统自动关闭连接
            {
                conn.Open();
                string sql = string.Format("update employee set password = {0},name = N'{1}'," +
                    "phone = {2},isMgr = {3},deptId = {4} where empId = {5};", txtPwd.Text, txtName.Text, txtPhone.Text,
                    DropDownList1.SelectedValue,DropDownList2.SelectedValue, txtId.Text);
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (cmd.ExecuteNonQuery() == 0)
                {
                    Label1.Text = "更新失败！";
                }
                else
                {
                    Label1.Text = "成功！";
                }
            }
        }
    }
}