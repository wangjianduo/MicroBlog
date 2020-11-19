using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class main : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["url"] = null;
            Session["state"] = null;
            Session["user_index"] = null;
            Session["id_blog"] = null;
        }
        
    }
    protected void Page_PreRender()
    {
        Session["user_index"] = null;
        Session["id_blog"] = null;
        if (Session["id"] != null && Session["name"] != null)
        {
            if(Session["power"].ToString() == "admin")
            {
                Button_sign.Visible = false;
                Button_register.Visible = false;
            }
            else if(Session["power"].ToString() == "normal")
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
            Label2.Text = Session["name"].ToString() + "，发个评论？";
        }
        else
        {
            Button_friend.Visible = false;
            Button_user.Visible = false;
            Button_admin.Visible = false;
            Button_modify.Visible = false;
            Button_out.Visible = false;

        }
        //评论排序
        if (Session["state"] == null)
        {
            string ConStr = "server=(local);user id=sa;pwd=19991021391X;database=microblog";
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();             //打开连接
            string SqlStr;
            SqlStr = " SELECT text, score, name_user, id_blog, id_user FROM blog ORDER BY score DESC select top 100 * from blog ";
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
        else if(Session["state"] != null)
        {
            string ConStr = "server=(local);user id=sa;pwd=19991021391X;database=microblog";
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();             //打开连接
            string SqlStr;
            SqlStr = " SELECT text, score, name_user, id_blog, id_user FROM blog ORDER BY id_blog DESC select top 100 * from blog ";
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
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataPager pa = (DataPager)(ListView1.FindControl("DataPager1"));
        pa.PageSize = Convert.ToInt32(DropDownList1.SelectedValue);
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        string State = DropDownList2.SelectedValue.ToString();
        if(State.ToString() == "热度")
        {
            Session["state"] = null;
        }
        else if(State.ToString() == "时间")
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
            String Text = TextBox1.Text.ToString();
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
            if(e.CommandName == "user_index")
            {
                Session["user_index"] = e.CommandArgument.ToString();
                if(Session["user_index"].ToString() == Session["id"].ToString())
                {
                    Response.Redirect("my_blog.aspx");
                }
                else
                {
                    Response.Redirect("user_index.aspx");
                }
            }
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
        }
        else
        {
            Response.Write("<script>alert('您没有登录！');location.href='index.aspx';</script>");
        }
    }

}