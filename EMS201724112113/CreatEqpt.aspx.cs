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
        public static string picture = DateTime.Now.ToFileTimeUtc().ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            bool bok = false;//默认为false
            string path = Server.MapPath("/images/");//储存文件夹路径
            if (this.FileUpload1.HasFile)//检测是否有上传文件
            {
                string file = System.IO.Path.GetExtension(this.FileUpload1.FileName).ToLower();//获取文件夹下的文件路径
                string[] allow = new string[] { ".png", ".jpg", ".gif", ".bmp", ".jpeg" };//后缀名数组


                foreach (string s in allow)//读取后缀名数组
                {
                    if (s == file) //如果符合数组里的类型
                    {
                        bok = true;//bool值为true
                    }
                }

                if (bok)//如果为true
                {
                    try
                    {
                        this.FileUpload1.PostedFile.SaveAs(path + picture + ".jpg");//上传文件
                        this.lbl.Text = "文件" + FileUpload1.FileName + "上传成功!";
                    }
                    catch (Exception ex)
                    {
                        this.lbl.Text = "文件上传失败!" + ex.Message;
                    }
                }
                else
                {
                    this.lbl.Text = "上传的图片格式不正确：只能上传.png,jpg,.gif,.bmp,.jpeg";
                }
            }
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
                    " values( N'{0}',N'{1}',N'{2}','{3}','{4}',N'{5}','{6}','{7}');",
                    Name,Specifications, picture, Price,PurchaseDate,Location,Mgr,Num);
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    Label3.Text = "新建成功";
                }
                else
                {
                    Label3.Text = "新建失败";
                }
            }
        }
 
    }
}