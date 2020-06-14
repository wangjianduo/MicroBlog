using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sign : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["id"] != null && Session["name"] != null)
            {
                Label1.Text = Session["name"].ToString();
                if (Session["power"].ToString() == "admin")
                {
                    Button_sign.Visible = false;
                    Button_register.Visible = false;
                }
                else if (Session["power"].ToString() == "normal")
                {
                    Button_sign.Visible = false;
                    Button_register.Visible = false;
                    Button_admin.Visible = false;
                }
                else
                {
                    Session["id"] = null;
                    Session["name"] = null;
                    Session["power"] = null;
                    Response.Write("<script>alert('权限出错！');location.href='index.aspx';</script>");

                }
            }
            else
            {
                Button_friend.Visible = false;
                Button_user.Visible = false;
                Button_admin.Visible = false;
                Button_modify.Visible = false;
                Button_out.Visible = false;
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string name = TextBox1.Text;
        string password = TextBox2.Text;
        if (name.Length == 0 || password.Length == 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('账号或密码能不为空，请重新输入！');</script>");
        }
        else
        {
            string ConStr = "server=(local);user id=sa;pwd=19991021391X;database=microblog";
            SqlConnection con = new SqlConnection(ConStr);
            string SqlStr = "select * from users where id = '" + name + "' and psw = '" + password + "'";
            SqlDataAdapter ada = new SqlDataAdapter(SqlStr, con);
            con.Open();                 //打开连接
            DataSet ds = new DataSet();
            ada.Fill(ds);
            if (ds.Tables[0].Rows.Count <= 0)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('您输入账号或密码有误！');</script>");

            }
            else
            {
                //读取权限信息，进行用户种类判断
                string Power = ds.Tables[0].Rows[0][4].ToString();
                if (Power == "admin")
                {
                    //ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('欢迎回来，尊敬的管理员用户！');</script>");
                    Session["id"] = name;
                    Session["power"] = Power;
                    Session["name"] = ds.Tables[0].Rows[0][1].ToString();
                    Response.Write("<script>alert('欢迎回来，尊敬的管理员用户！');location.href='index.aspx';</script>");

                    //Response.Redirect("index.aspx");
                }
                else if (Power == "normal")
                {
                    Session["id"] = name;
                    Session["power"] = Power;
                    Session["name"] = ds.Tables[0].Rows[0][1].ToString();
                    Response.Write("<script>alert('登陆成功！');location.href='index.aspx';</script>");
                    //ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('登陆成功！');</script>");

                    //Response.Redirect("index.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('数据库错误！');</script>");
                }

            }
        }


    }
    protected void Button_sign_Click(object sender, EventArgs e)
    {
        Response.Redirect("Sign.aspx");
    }

    protected void Button_register_Click(object sender, EventArgs e)
    {
        Response.Redirect("register.aspx");
    }

    protected void Button_user_Click(object sender, EventArgs e)
    {
        Response.Redirect("my_blog.aspx");
    }

    protected void Button_friend_Click(object sender, EventArgs e)
    {
        Response.Redirect("friend.aspx");
    }

    protected void Button_modify_Click(object sender, EventArgs e)
    {
        Response.Redirect("modify.aspx");
    }

    protected void Button_admin_Click(object sender, EventArgs e)
    {
        Response.Redirect("admin.aspx");
    }

    protected void Button_out_Click(object sender, EventArgs e)
    {
        Session["id"] = null;
        Session["name"] = null;
        Session["power"] = null;
        Response.Write("<script>alert('您已退出登录！');location.href='index.aspx';</script>");
    }
}