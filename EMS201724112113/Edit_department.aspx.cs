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
    public partial class Edit_department : System.Web.UI.Page
    {
        String strConn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\\EMSdb.mdf';";
        public string id;
        public DeptEntity deptEntity = new DeptEntity();
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["id"];
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            GetDept();
            if (!IsPostBack)
            {
                txtId.Text = deptEntity.DeptId.ToString();
                txtName.Text = deptEntity.DeptName;
                txtMgr.Text = "原负责人："+deptEntity.DeptMgr;
            }
        }
        void GetDept()
        {
            using (SqlConnection conn = new SqlConnection(strConn))//使用using的方式系统自动关闭连接
            {
                conn.Open();
                string sql = string.Format("select d.deptId,d.deptName,e.name " +
                    "from department d, employee e " +
                    "where d.deptMgrId = d.deptMgrId and d.deptId = {0}", id);
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        deptEntity.DeptId = int.Parse(dr[0].ToString());
                        deptEntity.DeptName = dr[1].ToString();
                        deptEntity.DeptMgr = dr[2].ToString();
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(strConn))//使用using的方式系统自动关闭连接
            {
                conn.Open();
                string sql = string.Format("update department " +
                    "set deptName = N'{0}',deptMgrId = {1} where deptId = {2}",
                    txtName.Text,DropDownList1.SelectedValue,id);
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