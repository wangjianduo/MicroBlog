<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--导入bootstrap css文件-->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <!--适配-->

    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <title>MicroBlog</title>
    <style>
        html {
            position: relative;
            min-height: 100%;
        }

        body {
            /* Margin bottom by footer height */
            margin-bottom: 60px;
        }

        .footer {
            position: absolute;
            bottom: 0;
            width: 100%;
            /* Set the fixed height of the footer here */
            height: auto;
            background-color: #f5f5f5;
        }
    </style>
</head>
<body style="background-color: #E3E5E9">
    <form id="form1" runat="server">
        <header>
            <nav class="navbar navbar-expand-lg navbar-dark fixed-top" style="background-color: #000000">
                <div class="container">
                    <div>
                        <a class="" href="index.aspx" style="font-weight: bolder; font-family: 'times New Roman', Times, serif; font-size: 25px; color: #FFFFFF;">Micro</a>
                        <a class="navbar-brand badge" href="index.aspx" style="font-weight: bolder; background-color: #F7971D; color: #000000; font-size: 22px; font-family: 'times New Roman', Times, serif;">Blog</a>
                    </div>

                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarNavDropdown">
                        <ul class="navbar-nav ml-auto">
                            <li class=" nav-item dropdown">

                                <asp:Label ID="Label1" class="nav-link dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" runat="server" Text="未登录"></asp:Label>

                                <div class="dropdown-menu row">
                                    <asp:Button ID="Button_sign" class="dropdown-item" runat="server" Text="登录" Visible="true" OnClick="Button_sign_Click" />
                                    <asp:Button ID="Button_register" class="dropdown-item" runat="server" Text="注册" OnClick="Button_register_Click" />
                                    <asp:Button ID="Button_user" class="dropdown-item" runat="server" Text="我的微博" OnClick="Button_user_Click" />
                                    <asp:Button ID="Button_friend" class="dropdown-item" runat="server" Text="好友列表" OnClick="Button_friend_Click" />
                                    <asp:Button ID="Button_modify" class="dropdown-item" runat="server" Text="修改信息" OnClick="Button_modify_Click" />
                                    <asp:Button ID="Button_admin" class="dropdown-item" runat="server" Text="管理" OnClick="Button_admin_Click" />
                                    <asp:Button ID="Button_out" class="dropdown-item" runat="server" Text="注销" OnClick="Button_out_Click" />
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>

            </nav>
        </header>
        <br />
        <br />
        <br />
        <div class="container">
            <div class="row">
                <div class="card col-sm-6 m-auto" style="font-weight: bolder; background-color: #000000;">
                    <div class="card-body">
                        <div class="text-center">
                            <h3 class="badge text-center" style="color: #000000; background-color: #FF9900; font-size: 25px;">注册</h3>
                        </div>
                        <div class="form-group">
                            <label class="control-label" style="color: #FFFFFF">昵称</label>
                            <asp:TextBox ID="TextBox1" class="form-control" placeholder="昵称（必填）" type="text" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label class="control-label" style="color: #FFFFFF">用户名ID</label>
                            <asp:TextBox ID="TextBox2" class="form-control" placeholder="用户名（必填）" type="text" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label class="control-label" style="color: #FFFFFF">密码</label>
                            <asp:TextBox ID="TextBox3" class="form-control" placeholder="密码（必填）" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label class="control-label" style="color: #FFFFFF">重复密码</label>
                            <asp:TextBox ID="TextBox5" class="form-control" placeholder="重复密码（必填）" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label class="control-label" style="color: #FFFFFF">签名</label>
                            <asp:TextBox ID="TextBox4" class="form-control" placeholder="个人签名（非必填）" type="text" runat="server"></asp:TextBox>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-6">
                                <asp:Button ID="Button1" class="btn btn-block" Style="margin-bottom: 15px" runat="server" Text="注册" OnClick="Button1_Click" Visible="True" BorderColor="#FF9900" BackColor="#FF9900" />
                            </div>
                            <div class="col-6">
                                <asp:Button ID="Button2" class="btn btn-secondary btn-block" Style="margin-bottom: 15px" runat="server" Text="清除" OnClick="Button2_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <br />
    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>
<footer class="footer" style="background-color: #000000">

    <div class="container text-center">
        <div class="row align-items-center">
            <div class="col">
            </div>
            <div class="col-lg-8 small" style="color: #FFFFFF">
                <span class="">MicroBlog V1.0.0 Build20200613</span><br>
                <span class="">此网站只作为作品展示不用于任何盈利</span><br>
                <span class="">Copyright © 2019-2020 AutoWA Studio All Rights Reserved.</span><br>
                <span class="">源代码：<a href='https://github.com/wangjianduo/CSharp-GraduationWorks-MicroBlog' style="color: #FF9900">Design By AutoWA Studio</a></span><span class="">  备案号：<a href='http://www.beian.miit.gov.cn/' style="color: #FF9900">黑ICP备20003059号-1</a></span>
            </div>
            <div class="col">
            </div>
        </div>

    </div>
</footer>
