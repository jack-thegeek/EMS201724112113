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
    public partial class SearchResult : System.Web.UI.Page
    {
        public List<EqptEntity> eqptlist = new List<EqptEntity>();
        String strConn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\\EMSdb.mdf';";
        protected void Page_Load(object sender, EventArgs e)
        {
            string accord = Request["accord"];
            string key = Request["key"];
            Label1.Text = "搜索" + key + "的结果：";
            GetAll(accord,key);
        }

        void GetAll(string accord,string key)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                string sql = string.Format("select distinct eq.eqptId,eq.eqptName,eq.specifications,eq.picture," +
                    "eq.price,eq.PurchaseDate,eq.location,eq.num,em.name " +
                    "from department d, employee em, equipment eq " +
                    "where eq.mgrId = d.deptMgrId and d.deptMgrId = em.empId " +
                    "and {0} like N'%{1}%';", accord, key);
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