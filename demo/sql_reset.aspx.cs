using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sql_reset : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["id"] == null && Session["name"] == null)
            {
                Response.Write("<script>alert('未登录，请重新登录！');location.href='index.aspx';</script>");
            }
            if (Session["power"] == null || Session["power"].ToString() != "admin")
            {
                Response.Write("<script>alert('您账号权限不足！');location.href='index.aspx';</script>");
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if(TextBox1.Text.ToString() == "我已了解此操作后果")
        {
            string ConStr = "server=(local);user id=sa;pwd=19991021391X;database=microblog";
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();
            string Sqlinsert = "TRUNCATE TABLE blog";
            SqlCommand mycom = new SqlCommand(Sqlinsert, con);
            mycom.ExecuteNonQuery();     //执行插入语句
            string Sqlinsert1 = "TRUNCATE TABLE comment";
            SqlCommand mycom1 = new SqlCommand(Sqlinsert1, con);
            mycom1.ExecuteNonQuery();     //执行插入语句
            string Sqlinsert2 = "TRUNCATE TABLE Friends";
            SqlCommand mycom2 = new SqlCommand(Sqlinsert2, con);
            mycom2.ExecuteNonQuery();     //执行插入语句
            string Sqlinsert3 = "TRUNCATE TABLE users";
            SqlCommand mycom3 = new SqlCommand(Sqlinsert3, con);
            mycom3.ExecuteNonQuery();     //执行插入语句
            Response.Write("<script>alert('删除成功！');</script>");
            string Sqlinsert4 = "insert into users values ('" + "admin "+ "','" + "admin" + "','" + "123456" + "','" + "" + "','" + "admin" + "')";
            SqlCommand mycom4 = new SqlCommand(Sqlinsert4, con);
            mycom4.ExecuteNonQuery();      //执行插入语句
            con.Close();
            con.Dispose();
            Session["url"] = null;
            Session["state"] = null;
            Session["user_index"] = null;
            Session["id_blog"] = null;
            Session["id"] = null;
            Session["name"] = null;
            Session["power"] = null;
            Response.Write("<script>alert('已生成管理员账号admin，密码123456！');location.href='admin.aspx';</script>");
            
        }
        else
        {
            Response.Write("<script>alert('点击失败！');</script>");
        }
    }
}