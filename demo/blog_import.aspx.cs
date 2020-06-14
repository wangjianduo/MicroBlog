using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class blog_import : System.Web.UI.Page
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
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        String pathc = Server.MapPath("~/Excel/");
        string excelpath = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
        if(FileUpload1.FileName.ToString() != "模板.xls")
        {
            Response.Write("<script>alert('添加失败，请检查文件或重新下载模板！');</script>");
            return ;
        }
        FileUpload1.PostedFile.SaveAs(pathc + FileUpload1.FileName);
        string path = Server.MapPath("~/Excel/") + FileUpload1.FileName.ToString();
        string conString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + "; Extended Properties=Excel 8.0;";
        OleDbConnection con = new OleDbConnection(conString);
        OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM [blog]", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        for (int i = 0; i < ds.Tables[0].Rows.Count; ++i)
        {
            if (ds.Tables[0].Rows[i][0].ToString() == "")
            {
                break;
            }
            string blog_text = ds.Tables[0].Rows[i][0].ToString();
            string blog_score = ds.Tables[0].Rows[i][1].ToString();
            string user_id = ds.Tables[0].Rows[i][2].ToString();
            string user_name = ds.Tables[0].Rows[i][3].ToString();
            string ConStr = "server=(local);user id=sa;pwd=19991021391X;database=microblog";
            int score = Convert.ToInt32(blog_score);
            SqlConnection con1 = new SqlConnection(ConStr);
            con1.Open();
            string Sqlinsert = "INSERT INTO blog (text, score, id_user, name_user) VALUES('" + blog_text + "', '" + score + "', '" + user_id + "', '" + user_name + "')";
            SqlCommand mycom = new SqlCommand(Sqlinsert, con1);
            mycom.ExecuteNonQuery();     //执行插入语句
            Response.Write("<script>alert('添加成功！');</script>");
            con1.Close();
            con1.Dispose();
            Response.AddHeader("Refresh", "0");
        }
        try
        {

        }
        catch
        {
            Response.Write("<script>alert('添加失败，请检查文件或重新下载模板！');</script>");
            Response.AddHeader("Refresh", "0");
        }
    }
}