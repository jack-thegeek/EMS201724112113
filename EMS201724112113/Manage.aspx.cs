using EMS201724112113.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS201724112113
{
    public partial class Manage : System.Web.UI.Page
    {
        public List<EqptEntity> eqptlist = new List<EqptEntity>();
        String strConn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\\EMSdb.mdf';";

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
                string sql = string.Format("select eq.eqptId,eq.eqptName,eq.specifications,eq.picture," +
                    "eq.price,eq.PurchaseDate,eq.location,eq.num,em.name " +
                    "from department d, employee em, equipment eq " +
                    "where eq.mgrId = d.deptMgrId and d.deptMgrId = em.empId");
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EqptEntity eqptEntity = new EqptEntity();
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        eqptEntity.EqptId = int.Parse(dr[0].ToString());
                        eqptEntity.EqptName = dr[1].ToString();
                        eqptEntity.Specifications = dr[2].ToString();
                        eqptEntity.Picture = dr[3].ToString();
                        eqptEntity.Price = dr[4].ToString();
                        eqptEntity.PurchaseDate = Convert.ToDateTime(dr[5]).Year.ToString();
                        eqptEntity.Location = dr[6].ToString();
                        eqptEntity.Mgr = dr[8].ToString();
                        eqptEntity.Num = int.Parse(dr[7].ToString());
                    }
                    eqptlist.Add(eqptEntity);
                }
            }
        }
    }
}