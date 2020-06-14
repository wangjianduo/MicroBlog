using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class blog_comment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id_blog"] == null)
        {
            Response.Write("<script>alert('未接收到博客ID，返回主页！');location.href='index.aspx';</script>");
        }
        if (!IsPostBack)
        {
            Session["state"] = null;
            Session["user_index"] = null;
        }
    }
    protected void Page_PreRender()
    {
        //导航栏等后台以及初始化
        Session["user_index"] = null;
        if (Session["id"] != null && Session["name"] != null)
        {
            string ConStr = "server=(local);user id=sa;pwd=19991021391X;database=microblog";
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();             //打开连接
            string SqlStr;
            SqlStr = "select text, score, name_user from blog where id_blog = '" + Session["id_blog"] + "'";
            SqlDataAdapter ada = new SqlDataAdapter(SqlStr, con);
            DataSet ds = new DataSet();
            ada.Fill(ds);
            string Txt = ds.Tables[0].Rows[0][0].ToString();
            string Score = ds.Tables[0].Rows[0][1].ToString();
            string name = ds.Tables[0].Rows[0][2].ToString();
            Label1.Text = Session["name"].ToString();
            Label_name.Text = name;
            Label_hot.Text = Score;
            Label_blog.Text = Txt;

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
            SqlStr = "SELECT text, score, name_user, id_comment, id_user FROM comment where id_blog = '" + Session["id_blog"] + "' ORDER BY score DESC select top 100 * from comment ";
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
        else if (Session["state"] != null)
        {
            string ConStr = "server=(local);user id=sa;pwd=19991021391X;database=microblog";
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();             //打开连接
            string SqlStr;
            SqlStr = "SELECT text, score, name_user, id_comment, id_user FROM comment where id_blog = '" + Session["id_blog"] + "' ORDER BY id_comment DESC select top 100 * from blog ";
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

    }
    //导航栏button
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
    //DropdownList
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
    //listview
    protected void ListView1_SelectedIndexChanged(object sender, ListViewCommandEventArgs e)
    {
        if (Session["id"] != null && Session["name"] != null)
        {
            if (e.CommandName == "user_index")
            {
                Session["user_index"] = e.CommandArgument.ToString();
                Response.Redirect("user_index.aspx");
            }
            if (e.CommandName == "Nice")
            {
                string ConStr2 = "server=(local);user id=sa;pwd=19991021391X;database=microblog";
                SqlConnection con2 = new SqlConnection(ConStr2);
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                string SqlStr = "select * from comment where id_comment = '" + id + "'";
                SqlDataAdapter ada = new SqlDataAdapter(SqlStr, con2);
                con2.Open();                 //打开连接 
                DataSet ds = new DataSet();
                ada.Fill(ds);
                int num = Convert.ToInt32(ds.Tables[0].Rows[0][5]);
                num++;
                string Sqlmodify2 = "update comment set score='" + num + "' where id_comment = '" + id + "'";
                SqlCommand mycom2 = new SqlCommand(Sqlmodify2, con2);
                mycom2.ExecuteNonQuery();     //执行插入语句
                con2.Close();
                con2.Dispose();
                Response.AddHeader("Refresh", "0"); //刷新页面
            }
        }
        else
        {
            Response.Write("<script>alert('您没有登录！');location.href='index.aspx';</script>");
        }
    }
    //主博客点赞
    protected void Button2_Click(object sender, EventArgs e)
    {
        string ConStr2 = "server=(local);user id=sa;pwd=19991021391X;database=microblog";
        SqlConnection con2 = new SqlConnection(ConStr2);
        string SqlStr = "select * from blog where id_blog = '" + Session["id_blog"] + "'";
        SqlDataAdapter ada = new SqlDataAdapter(SqlStr, con2);
        con2.Open();                 //打开连接 
        DataSet ds = new DataSet();
        ada.Fill(ds);
        int num = Convert.ToInt32(ds.Tables[0].Rows[0][2]);
        num++;
        string Sqlmodify2 = "update blog set score='" + num + "' where id_blog = '" + Session["id_blog"] + "'";
        SqlCommand mycom2 = new SqlCommand(Sqlmodify2, con2);
        mycom2.ExecuteNonQuery();     //执行插入语句
        con2.Close();
        con2.Dispose();
        Response.AddHeader("Refresh", "0"); //刷新页面
    }
    //评论
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (Session["id"] != null && Session["name"] != null)
        {
            String Text = TextBox1.Text.ToString();
            if (Text != "")
            {
                int n = 0;
                string ConStr = "server=(local);user id=sa;pwd=19991021391X;database=microblog";
                SqlConnection con = new SqlConnection(ConStr);
                con.Open();                 //打开连接 
                string Sqlmodify = "INSERT INTO comment VALUES( '" + Session["id"].ToString() + "', '" + Session["name"].ToString() + "', '" + Text + "', '" + Session["id_blog"].ToString() + "', '" + n + "')";
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