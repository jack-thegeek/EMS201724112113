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
            
            if (Session["username"] != null)
            {
                if ((int)Session["isMgr"] == 1)//如果是管理员
                {
                }
                else//如果不是管理员,隐藏部分菜单
                {
                    Button1.Visible = false;
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
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                string sql = string.Format("select distinct eq.eqptId,eq.eqptName," +
                    "eq.specifications,eq.picture,eq.price,eq.PurchaseDate,eq.location," +
                    "eq.num,em.name from employee em, equipment eq " +
                    "where eq.mgrId = em.empId");
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreatEqpt.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string accord = DropDownList1.SelectedValue;
            string key = TextBox1.Text;
            Response.Redirect("SearchResult.aspx?accord=" + accord + "&key=" + key);
        }
    }
}