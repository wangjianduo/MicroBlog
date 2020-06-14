using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class friend : System.Web.UI.Page
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
            string ConStr1 = "server=(local);user id=sa;pwd=19991021391X;database=microblog";
            SqlConnection con1 = new SqlConnection(ConStr1);
            con1.Open();             //打开连接
            string SqlStr1;
            SqlStr1 = "select introduction from users where id = '" + Session["id"] + "'";
            SqlDataAdapter ada1 = new SqlDataAdapter(SqlStr1, con1);
            DataSet ds1 = new DataSet();
            ada1.Fill(ds1);
            string introduction = ds1.Tables[0].Rows[0][0].ToString();
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
        string ConStr = "server=(local);user id=sa;pwd=19991021391X;database=microblog";
        SqlConnection con = new SqlConnection(ConStr);
        con.Open();             //打开连接
        string SqlStr;
        SqlStr = "SELECT friend_user_id, friend_id, friend_introduction, friend_name FROM Friends where friend_user_id = '" + Session["id"] + "' select top 100 * from blog ";
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
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataPager pa = (DataPager)(ListView1.FindControl("DataPager1"));
        pa.PageSize = Convert.ToInt32(DropDownList1.SelectedValue);
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
            if (e.CommandName == "user_index")
            {
                Session["user_index"] = e.CommandArgument.ToString();
                if (Session["user_index"].ToString() == Session["id"].ToString())
                {
                    Response.Redirect("my_blog.aspx");
                }
                else
                {
                    Response.Redirect("user_index.aspx");
                }
            }
            if (e.CommandName == "delete_friend")
            {
                string ConStr = "server=(local);user id=sa;pwd=19991021391X;database=microblog";
                SqlConnection con = new SqlConnection(ConStr);
                con.Open();
                string Sqlinsert = "delete from Friends where friend_user_id = '" + Session["id"] + "' and friend_id = '" + e.CommandArgument.ToString() + "'";
                SqlCommand mycom = new SqlCommand(Sqlinsert, con);
                mycom.ExecuteNonQuery();     //执行插入语句
                Response.Write("<script>alert('已取消关注！');</script>");
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

}