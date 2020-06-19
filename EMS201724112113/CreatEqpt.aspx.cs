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
    public partial class CreatEqpt : System.Web.UI.Page
    {
        String strConn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\\EMSdb.mdf';";
        public string id;

        
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            GetId();
            Label2.Text = id;
        }
        protected void Button1_Click1(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string Name = TextBox1.Text;
            string Specifications = TextArea1.Value;
            string Price = TextBox4.Text;
            string PurchaseDate = TextBox5.Text;
            string Location = TextBox6.Text;
            string Mgr = DropDownList1.SelectedValue;
            string Num = TextBox8.Text;

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                string sql = string.Format("insert into equipment (eqptName,specifications,picture,price,PurchaseDate,location,mgrId,num)" +
                    " values( '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}');",
                    Name,Specifications,id,Price,PurchaseDate,Location,Mgr,Num);
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    Label2.Text = "插入成功";
                }
                else
                {
                    Label2.Text = "插入失败";
                }
            }
        }

        void GetId()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                string sql = string.Format("select count(*) from equipment");
                SqlCommand cmd = new SqlCommand(sql, conn);
                id = cmd.ExecuteScalar().ToString();
            }
        }
    }
}