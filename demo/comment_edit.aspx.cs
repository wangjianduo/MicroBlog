using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class comment_edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id_blog"] == null)
        {
            Response.Write("<script>alert('未接收到微博ID，请重试！');location.href='index.aspx';</script>");
        }
        if (!IsPostBack)
        {

        }
        string ConStr = "server=(local);user id=sa;pwd=19991021391X;database=microblog";
        SqlConnection con = new SqlConnection(ConStr);
        con.Open();             //打开连接
        string SqlStr;
        SqlStr = "SELECT * FROM blog where id_user = '" + Session["id"] + "'";
        SqlDataAdapter ada = new SqlDataAdapter(SqlStr, con);
        DataSet ds = new DataSet();
        ada.Fill(ds);
    }

    protected void Page_PreRender()
    {
        if (Session["id"] != null && Session["name"] != null)
        {
            if (Session["id_blog"] != null)
            {
                string ConStr = "server=(local);user id=sa;pwd=19991021391X;database=microblog";
                SqlConnection con = new SqlConnection(ConStr);
                con.Open();             //打开连接
                string SqlStr;
                SqlStr = "SELECT * FROM comment where id_comment = '" + Session["id_blog"] + "'";
                SqlDataAdapter ada = new SqlDataAdapter(SqlStr, con);
                DataSet ds = new DataSet();
                ada.Fill(ds);
                TextBox2.Text = ds.Tables[0].Rows[0][3].ToString();
            }
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

    protected void Button3_Click(object sender, EventArgs e)
    {
        string Text = TextBox2.Text;

        string ConStr = "server=(local);user id=sa;pwd=19991021391X;database=microblog";
        SqlConnection con = new SqlConnection(ConStr);
        con.Open();                 //打开连接 
        string Sqlmodify = "update comment set text='" + Text + "' where id_comment='" + Session["id_blog"] + "'";
        SqlCommand mycom = new SqlCommand(Sqlmodify, con);
        mycom.ExecuteNonQuery();     //执行插入语句
        if (Session["url"].ToString() == "comment_admin.aspx")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('已修改！'); location.href='comment_admin.aspx'</script>");
        }
        if (Session["url"].ToString() == "comment_history.aspx")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('已修改！'); location.href='comment_history.aspx'</script>");
        }

        con.Close();
        con.Dispose();
    }
}