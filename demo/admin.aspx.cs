using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id"] == null && Session["name"] == null)
        {
            Response.Write("<script>alert('未登录，请重新登录！');location.href='index.aspx';</script>");
        }
        if(Session["power"] == null || Session["power"].ToString() != "admin")
        {
            Response.Write("<script>alert('您账号权限不足！');location.href='index.aspx';</script>");
        }
    }
}