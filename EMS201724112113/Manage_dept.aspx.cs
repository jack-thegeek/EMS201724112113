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
    public partial class Manage_dept : System.Web.UI.Page
    {
        public List<DeptEntity> deptlist = new List<DeptEntity>();
        private String strConn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\\EMSdb.mdf';";
        protected void Page_Load(object sender, EventArgs e)
        {
            GetAll();
        }

        void GetAll()
        {
            using (SqlConnection conn = new SqlConnection(strConn))//使用using的方式系统自动关闭连接
            {
                //打开数据库连接
                conn.Open();
                //设定SQL叙述
                string sql = string.Format("select d.deptId,d.deptName,e.name from department d, employee e where d.deptMgrId = e.empId");
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DeptEntity deptEntity = new DeptEntity();
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        deptEntity.DeptId = int.Parse(dr[0].ToString());
                        deptEntity.DeptName = dr[1].ToString();
                        deptEntity.DeptMgr = dr[2].ToString();
                    }
                    deptlist.Add(deptEntity);
                }
            }
        }
    }
}