using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class friend_admin : System.Web.UI.Page
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
            string ConStr = "server=(local);user id=sa;pwd=19991021391X;database=microblog";
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();             //打开连接
            string SqlStr;
            SqlStr = "SELECT friend_user_id, friend_id, friend_introduction, friend_name FROM Friends select top 10000 * from Friends ";
            SqlDataAdapter ada = new SqlDataAdapter(SqlStr, con);
            DataSet ds = new DataSet();
            ada.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

    }
    protected void Page_PreRender()
    {
        string ConStr = "server=(local);user id=sa;pwd=19991021391X;database=microblog";
        SqlConnection con = new SqlConnection(ConStr);
        con.Open();             //打开连接
        string SqlStr;
        SqlStr = "SELECT friend_user_id, friend_id, friend_introduction, friend_name FROM Friends select top 10000 * from Friends ";
        SqlDataAdapter ada = new SqlDataAdapter(SqlStr, con);
        DataSet ds = new DataSet();
        ada.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindToDataGrid();
    }

    private void BindToDataGrid()
    {
        string ConStr = "server=(local);user id=sa;pwd=19991021391X;database=microblog";
        SqlConnection con = new SqlConnection(ConStr);
        con.Open();             //打开连接
        string SqlStr;
        SqlStr = "SELECT friend_user_id, friend_id, friend_introduction, friend_name FROM Friends select top 10000 * from Friends ";
        SqlDataAdapter ada = new SqlDataAdapter(SqlStr, con);
        DataSet ds = new DataSet();
        ada.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string ConStr = "server=(local);user id=sa;pwd=19991021391X;database=microblog";
        SqlConnection con = new SqlConnection(ConStr);
        con.Open();             //打开连接
        if (e.CommandName == "friend_delete")
        {
            //多参数传递
            string[] com = e.CommandArgument.ToString().Split(new char[] { '#' });
            string user_id = com[0]; //传递参数1
            string friend_id = com[1];//传递参数2

            string SqlStr = "delete from Friends where friend_user_id = '" + user_id + "' and friend_id='" + friend_id + "'";
            SqlCommand mycom = new SqlCommand(SqlStr, con);
            mycom.ExecuteNonQuery();     //执行插入语句
            Response.Write("<script>alert('删除成功！');</script>");
            con.Close();
            con.Dispose();
            Response.AddHeader("Refresh", "0");
        }
    }
}