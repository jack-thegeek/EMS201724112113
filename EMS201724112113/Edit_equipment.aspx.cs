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
    public partial class Edit_equipment : System.Web.UI.Page
    {
        String strConn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\\EMSdb.mdf';";
        public string id;
        public EqptEntity eqptEntity = new EqptEntity();
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if ((int)Session["isMgr"] == 1)
            {
                id = Request.QueryString["id"];
                GetEqpt();
                if (!IsPostBack)
                {
                    TextBox1.Text = eqptEntity.EqptName;
                    TextArea1.Value = eqptEntity.Specifications;
                    TextBox3.Text = eqptEntity.Picture;
                    TextBox4.Text = eqptEntity.Price;
                    TextBox5.Text = eqptEntity.PurchaseDate;
                    TextBox6.Text = eqptEntity.Location;
                    TextBox7.Text = "原负责人："+eqptEntity.Mgr;
                    TextBox8.Text = eqptEntity.Num.ToString();
                }
            }
            else
            {
                Response.Redirect("Manage.aspx");
            }
            
        }

        void GetEqpt()
        {
            using (SqlConnection conn = new SqlConnection(strConn))//使用using的方式系统自动关闭连接
            {
                //打开数据库连接
                conn.Open();
                //设定SQL叙述
                string sql = string.Format("select eq.eqptId,eq.eqptName,eq.specifications,eq.picture," +
                    "eq.price,eq.PurchaseDate,eq.location,eq.num,em.name " +
                    "from department d, employee em, equipment eq " +
                    "where eq.mgrId = d.deptMgrId and d.deptMgrId = em.empId and eqptId = {0}",id);
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
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
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(strConn))//使用using的方式系统自动关闭连接
            {
                conn.Open();
                string sql = string.Format("update equipment set eqptName = N'{0}',specifications = N'{1}'," +
                    "price = '{2}',PurchaseDate = '{3}',location = N'{4}', mgrId = '{5}', num = '{6}' where eqptId = '{7}';", 
                    TextBox1.Text, TextArea1.Value, TextBox4.Text,TextBox5.Text, TextBox6.Text, DropDownList1.SelectedValue, TextBox8.Text,id);
                SqlCommand cmd = new SqlCommand(sql, conn);
                Label1.Text = sql;
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