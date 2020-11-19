<%@ Page Language="C#" AutoEventWireup="true" CodeFile="blog_admin.aspx.cs" Inherits="blog_admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <!--导入bootstrap css文件-->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.0/dist/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <!--适配-->

    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <title>MicroBlog</title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <br />
        <div class="container">
            <div class="container text-center">
                <asp:GridView ID="GridView1" class="table table-bordered table-striped col-lg-4" runat="server" AllowPaging="True" PageSize="8" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnRowCreated="GridView1_RowCreated" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="评论ID">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("id_blog") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("id_blog") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="内容">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("text") %>' TextMode="MultiLine"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("text").ToString().Length>10?Eval("text").ToString().Substring(0,10)+"...":Eval("text") %>'></asp:Label>
                                    
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="热度">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("score") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("score") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="用户ID">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("id_user") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("id_user") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="用户昵称">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("name_user") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("name_user") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="删除评论">
                            <ItemTemplate>
                                <asp:Button ID="blog_delete" CssClass="btn btn-sm btn-primary" runat="server" Text='删除' CommandName="blog_delete" CommandArgument='<%# Bind("id_blog") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="修改评论">
                            <ItemTemplate>
                                <asp:Button ID="blog_edit" CssClass="btn btn-sm btn-primary" runat="server" Text='编辑' CommandName="blog_edit" CommandArgument='<%# Bind("id_blog") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerTemplate>
                        <br />
                        <asp:Label ID="lblPage" CssClass="btn btn-sm btn-primary" runat="server" Text='<%# "第" + (((GridView)Container.NamingContainer).PageIndex + 1) + "页/共" + (((GridView)Container.NamingContainer).PageCount) + "页" %> '></asp:Label>
                        <asp:LinkButton ID="lbnFirst" CssClass="btn btn-sm btn-outline-primary" runat="Server" Text="首页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="First"></asp:LinkButton>
                        <asp:LinkButton ID="lbnPrev" CssClass="btn btn-sm btn-outline-primary" runat="server" Text="上一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="Prev"></asp:LinkButton>
                        <asp:LinkButton ID="lbnNext" CssClass="btn btn-sm btn-outline-primary" runat="Server" Text="下一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Next"></asp:LinkButton>
                        <asp:LinkButton ID="lbnLast" CssClass="btn btn-sm btn-outline-primary" runat="Server" Text="尾页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Last"></asp:LinkButton>
                        <br />
                    </PagerTemplate>
                </asp:GridView>
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.5.1/dist/jquery.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.0/dist/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>
</body>
</html>
