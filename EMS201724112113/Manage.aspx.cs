﻿using EMS201724112113.Entity;
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
                string sql = string.Format("select * from equipment");
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EqptEntity eqptEntity = new EqptEntity();
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        eqptEntity.EqptId = int.Parse(dr[].ToString());
                        eqptEntity.EqptName = dr[].ToString();
                        eqptEntity.Specifications = dr[].ToString();
                        eqptEntity.Picture = dr[].ToString();
                        eqptEntity.Price = dr[].ToString();
                        eqptEntity.PurchaseDate = Convert.ToDateTime(dr[]).Year.ToString();
                        eqptEntity.Location = dr[].ToString();
                        eqptEntity.Mgr = dr[].ToString();
                        eqptEntity.Num = int.Parse(dr[].ToString());
                    }
                    eqptlist.Add(eqptEntity);
                }
            }
        }
    }
}