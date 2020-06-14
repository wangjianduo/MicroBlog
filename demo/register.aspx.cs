using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class register : System.Web.UI.Page
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
        string Name = TextBox1.Text;
        string ID = TextBox2.Text;
        string PSW = TextBox3.Text;
        string INTRO = TextBox4.Text;
        string REPSW = TextBox5.Text;
        string Power = "normal";
        string ConStr = "server=(local);user id=sa;pwd=19991021391X;database=microblog";
        if (Name.ToString() == "" || ID.ToString() == "" || PSW.ToString() == "" || REPSW.ToString() == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('必填项不能为空！');</script>");
        }
        else
        {
            if (PSW.ToString() != REPSW.ToString())
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('两次密码不同！');</script>");
            }
            else
            {
                SqlConnection con = new SqlConnection(ConStr);
                string SqlStr1 = "select * from users where id = '" + ID + "'";
                SqlDataAdapter ada1 = new SqlDataAdapter(SqlStr1, con);
                con.Open();                 //打开连接
                DataSet ds = new DataSet();
                ada1.Fill(ds);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    string SqlStr2 = "select * from users where name = '" + Name + "'";
                    SqlDataAdapter ada2 = new SqlDataAdapter(SqlStr2, con);
                    ds.Clear();
                    ada2.Fill(ds);
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        string Sqlinsert = "insert into users values ('" + ID + "','" + Name + "','" + PSW + "','" + INTRO + "','" + Power + "')";
                        SqlCommand mycom = new SqlCommand(Sqlinsert, con);
                        mycom.ExecuteNonQuery();      //执行插入语句
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('注册成功！');</script>");
                        con.Close();
                        con.Dispose();
                        Response.Redirect("sign.aspx");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('账号昵称重复！');</script>");
                    }

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('账号用户名重复！');</script>");
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

    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
    }
}