using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class modify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id"] == null && Session["name"] == null)
        {
            Response.Write("<script>alert('未登录，请返回主页登录！');location.href='index.aspx';</script>");
        }
        if (!IsPostBack)
        {
            if (Session["id"] != null && Session["name"] != null)
            {
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
                Label1.Text = Session["name"].ToString();
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

    protected void Page_PreRender()
    {
        if (Session["id"] != null && Session["name"] != null)
        {
            Label1.Text = Session["name"].ToString();
            string ConStr = "server=(local);user id=sa;pwd=19991021391X;database=microblog";
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();             //打开连接
            string SqlStr;
            SqlStr = "SELECT * FROM users where id = '" + Session["id"] + "'";
            SqlDataAdapter ada = new SqlDataAdapter(SqlStr, con);
            DataSet ds = new DataSet();
            ada.Fill(ds);
            TextBox1.Text = ds.Tables[0].Rows[0][1].ToString();
            TextBox2.Text = ds.Tables[0].Rows[0][0].ToString();
            TextBox3.Text = ds.Tables[0].Rows[0][2].ToString();
            TextBox4.Text = ds.Tables[0].Rows[0][3].ToString();
            TextBox5.Text = ds.Tables[0].Rows[0][2].ToString();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string Name = TextBox1.Text;
        string ID = TextBox2.Text;
        string PSW = TextBox3.Text;
        string INTRO = TextBox4.Text;
        string REPSW = TextBox5.Text;
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
                con.Open();                 //打开连接
                string SqlStr2 = "select * from users where name = '" + Name + "'";
                SqlDataAdapter ada2 = new SqlDataAdapter(SqlStr2, con);
                DataSet ds = new DataSet();
                ada2.Fill(ds);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    string Sqlmodify = "update users set name='" + Name + "', psw = '" + PSW + "', introduction = '" + INTRO + "' where id='" + ID + "'";
                    SqlCommand mycom = new SqlCommand(Sqlmodify, con);
                    mycom.ExecuteNonQuery();     //执行插入语句
                    //blog表同步修改
                    string SqlStr3 = "select * from blog where id_user = '" + ID + "'";
                    SqlDataAdapter ada3 = new SqlDataAdapter(SqlStr3, con);
                    ds.Clear();
                    ada3.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string Sqlmodify1 = "update blog set name_user='" + Name + "' where id_user='" + ID + "'";
                        SqlCommand mycom1 = new SqlCommand(Sqlmodify1, con);
                        mycom1.ExecuteNonQuery();     //执行插入语句
                    }
                    //comment同步修改
                    string SqlStr4 = "select * from comment where id_user = '" + ID + "'";
                    SqlDataAdapter ada4 = new SqlDataAdapter(SqlStr4, con);
                    ds.Clear();
                    ada4.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string Sqlmodify2 = "update comment set name_user='" + Name + "' where id_user='" + ID + "'";
                        SqlCommand mycom2 = new SqlCommand(Sqlmodify2, con);
                        mycom2.ExecuteNonQuery();     //执行插入语句
                    }
                    //Friends同步修改
                    string SqlStr5 = "select * from Friends where friend_id = '" + ID + "'";
                    SqlDataAdapter ada5 = new SqlDataAdapter(SqlStr5, con);
                    ds.Clear();
                    ada5.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string Sqlmodify3 = "update Friends set friend_introduction='" + INTRO + "', friend_name='" + Name + "' where friend_id='" + ID + "'";
                        SqlCommand mycom3 = new SqlCommand(Sqlmodify3, con);
                        mycom3.ExecuteNonQuery();     //执行插入语句
                    }
                    con.Close();
                    con.Dispose();
                    Session["name"] = Name;
                    Session["id"] = ID;
                    Response.Write("<script>alert('修改成功！');location.href='index.aspx';</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('账号昵称重复！');</script>");
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