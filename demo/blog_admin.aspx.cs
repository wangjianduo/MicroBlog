using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class blog_admin : System.Web.UI.Page
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
            SqlStr = "SELECT id_blog, text, score, id_user, name_user FROM blog select top 10000 * from blog ";
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
        SqlStr = "SELECT id_blog, text, score, id_user, name_user FROM blog select top 10000 * from blog ";
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
        SqlStr = "SELECT id_blog, text, score, id_user, name_user FROM blog select top 10000 * from blog ";
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
        if (e.CommandName == "blog_delete")
        {
            string SqlStr = "delete from blog where id_blog = '" + e.CommandArgument.ToString() + "'";
            SqlCommand mycom = new SqlCommand(SqlStr, con);
            mycom.ExecuteNonQuery();     //执行插入语句
            string SqlStr3 = "delete from comment where id_blog = '" + e.CommandArgument.ToString() + "'";
            SqlCommand mycom3 = new SqlCommand(SqlStr3, con);
            mycom3.ExecuteNonQuery();     //执行插入语句
            Response.Write("<script>alert('删除成功！');</script>");
            con.Close();
            con.Dispose();
            Response.AddHeader("Refresh", "0");
        }
        if (e.CommandName == "blog_edit")
        {
            Session["url"] = "blog_admin.aspx";
            Session["id_blog"] = e.CommandArgument.ToString();
            Response.Redirect("blog_edit.aspx");
        }
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Attributes.Add("style", "word-break :break-all ; word-wrap:break-word");
    }
}