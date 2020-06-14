using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class my_blog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id"] == null)
        {
            Response.Write("<script>alert('未登录，请返回主页登录！');location.href='index.aspx';</script>");
        }
        if (!IsPostBack)
        {
            Session["state"] = null;
            Session["id_blog"] = null;
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
        Session["id_blog"] = null;
        if (Session["id"] != null && Session["name"] != null)
        {
            string ConStr = "server=(local);user id=sa;pwd=19991021391X;database=microblog";
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();             //打开连接
            string SqlStr;
            SqlStr = "select introduction from users where id = '" + Session["id"] + "'";
            SqlDataAdapter ada = new SqlDataAdapter(SqlStr, con);
            DataSet ds = new DataSet();
            ada.Fill(ds);
            string introduction = ds.Tables[0].Rows[0][0].ToString();
            Label1.Text = Session["name"].ToString();
            if (introduction != "")
            {
                TextBox1.Text = introduction;
            }
            else
            {
                TextBox1.Text = "我还没有签名！";
            }
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
        if (Session["state"] == null)
        {
            string ConStr = "server=(local);user id=sa;pwd=19991021391X;database=microblog";
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();             //打开连接
            string SqlStr;
            SqlStr = "SELECT text, score, name_user, id_blog, id_user FROM blog where id_user = '" + Session["id"] + "' ORDER BY score DESC select top 100 * from blog ";
            SqlDataAdapter ada = new SqlDataAdapter(SqlStr, con);
            DataSet ds = new DataSet();
            ada.Fill(ds);
            if (ds.Tables[0].Rows.Count <= 0)
            {
                Label_nothing.Visible = true;
            }
            else
            {
                Label_nothing.Visible = false;
            }
            ListView1.DataSource = ds;
            ListView1.DataBind();
        }
        else
        {
            string ConStr = "server=(local);user id=sa;pwd=19991021391X;database=microblog";
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();             //打开连接
            string SqlStr;
            SqlStr = "SELECT text, score, name_user, id_blog, id_user FROM blog where id_user = '" + Session["id"] + "' ORDER BY id_blog DESC select top 100 * from blog ";
            SqlDataAdapter ada = new SqlDataAdapter(SqlStr, con);
            DataSet ds = new DataSet();
            ada.Fill(ds);
            if (ds.Tables[0].Rows.Count <= 0)
            {
                Label_nothing.Visible = false;
            }
            else
            {
                Label_nothing.Visible = true;
            }
            ListView1.DataSource = ds;
            ListView1.DataBind();
        }

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataPager pa = (DataPager)(ListView1.FindControl("DataPager1"));
        pa.PageSize = Convert.ToInt32(DropDownList1.SelectedValue);
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        string State = DropDownList2.SelectedValue.ToString();
        if (State.ToString() == "热度")
        {
            Session["state"] = null;
        }
        else if (State.ToString() == "时间")
        {
            Session["state"] = "time";
        }
        else
        {
            Response.Write("<script>alert('消息排序状态错误！')</script>");
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Session["id"] != null && Session["name"] != null)
        {
            Response.Redirect("comment_history.aspx");
        }
        else
        {
            Response.Write("<script>alert('您没有登录！');location.href='index.aspx';</script>");
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

    protected void ListView1_SelectedIndexChanged(object sender, ListViewCommandEventArgs e)
    {
        if (Session["id"] != null && Session["name"] != null)
        {

            if (e.CommandName == "Nice")
            {
                string ConStr2 = "server=(local);user id=sa;pwd=19991021391X;database=microblog";
                SqlConnection con2 = new SqlConnection(ConStr2);
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                string SqlStr = "select * from blog where id_blog = '" + id + "'";
                SqlDataAdapter ada = new SqlDataAdapter(SqlStr, con2);
                con2.Open();                 //打开连接 
                DataSet ds = new DataSet();
                ada.Fill(ds);
                int num = Convert.ToInt32(ds.Tables[0].Rows[0][2]);
                num++;
                string Sqlmodify2 = "update blog set score='" + num + "' where id_blog = '" + id + "'";
                SqlCommand mycom2 = new SqlCommand(Sqlmodify2, con2);
                mycom2.ExecuteNonQuery();     //执行插入语句
                con2.Close();
                con2.Dispose();
                Response.AddHeader("Refresh", "0"); //刷新页面
            }
            if (e.CommandName == "Comment")
            {
                Session["id_blog"] = e.CommandArgument.ToString();
                Response.Redirect("blog_comment.aspx");
            }
            if(e.CommandName == "edit")
            {
                Session["url"] = "my_blog.aspx";
                Session["id_blog"] = e.CommandArgument.ToString();
                Response.Redirect("blog_edit.aspx");
            }
            if(e.CommandName == "delete_blog")
            {
                string ID = e.CommandArgument.ToString();
                string ConStr = "server=(local);user id=sa;pwd=19991021391X;database=microblog";
                SqlConnection con = new SqlConnection(ConStr);
                con.Open();
                string Sqlinsert = "delete from blog where id_blog = '"+ ID +"'";
                SqlCommand mycom = new SqlCommand(Sqlinsert, con);
                mycom.ExecuteNonQuery();     //执行插入语句
                string SqlStr3 = "delete from comment where id_blog = '" + ID + "'";
                SqlCommand mycom3 = new SqlCommand(SqlStr3, con);
                mycom3.ExecuteNonQuery();     //执行插入语句
                Response.Write("<script>alert('删除成功！');</script>");
                con.Close();
                con.Dispose();
                Response.AddHeader("Refresh", "0");
            }
        }
        else
        {
            Response.Write("<script>alert('您没有登录！');location.href='index.aspx';</script>");
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        if (Session["id"] != null && Session["name"] != null)
        {
            String Text = TextBox2.Text.ToString();
            if (Text != "")
            {
                int n = 0;
                string ConStr = "server=(local);user id=sa;pwd=19991021391X;database=microblog";
                SqlConnection con = new SqlConnection(ConStr);
                con.Open();                 //打开连接 
                string Sqlmodify = "INSERT INTO blog VALUES( '" + Text + "', '" + n + "', '" + Session["id"].ToString() + "', '" + Session["name"].ToString() + "')";
                SqlCommand mycom = new SqlCommand(Sqlmodify, con);
                mycom.ExecuteNonQuery();     //执行插入语句
                con.Close();
                con.Dispose();
                Response.AddHeader("Refresh", "0");
            }
            else
            {
                Response.Write("<script>alert('内容不能为空!');location.href='index.aspx';</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('您没有登录！');location.href='index.aspx';</script>");
        }
    }
}