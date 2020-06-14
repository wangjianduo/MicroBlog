<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="main" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" lang="zh-cn">
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
        <!-- 导航栏页头 -->
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


        <div>
            <br />
            <br />
            <br />
        </div>    
        <div class="container">
            <div class="row card mb-3">

                <div id="carouselExampleIndicators" class="carousel slide carousel-fade row" data-ride="carousel">
                    <ol class="carousel-indicators">
                        <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                        <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                    </ol>
                    <div class="carousel-inner">
                        <div class="carousel-item active">
                            <img src="/img/img1.png" class="d-block w-100" alt="...">
                        </div>
                        <div class="carousel-item">
                            <img src="/img/img2.png" class="d-block w-100" alt="...">
                        </div>
                    </div>
                    <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="sr-only">Previous</span>
                    </a>
                    <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="sr-only">Next</span>
                    </a>
                </div>
            </div>
        </div>

        <div class="container">
            <div class="row">

                <div class="col-lg-5">
                    <div class="continer">
                        <div class="row card mb-3" style="background-color: #000000;">

                            <h5 class="card-header text-center " style="background-color: #F7971D; color: #000000;">
                                <b>
                                    <asp:Label ID="Label2" runat="server" Text="发个微博？"></asp:Label>
                                </b>
                            </h5>
                            <div class="card-body" style="background-color: #000000">
                                <div class="col text-center container">
                                    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Height="100px" Style="color: #FFFFFF; text-align: center; vertical-align: middle" Width="100%" BorderStyle="Inset" BackColor="#333333"></asp:TextBox>
                                </div>
                                <p></p>
                                <div class="col text-center">
                                    <asp:Button ID="Button2" class="btn btn-sm btn-outline-warning" runat="server" Text="发送" OnClick="Button2_Click" Width="40%" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-1"></div>
                <div class="col-lg-6">
                    <div class="continer">
                        <div class="row card mb-3" style="background-color: #000000">
                            <div class="card-header text-center" style="background-color: #F7971D;">

                                <div class="col-auto">
                                    <h5 style="color: #000000;">
                                        <b>微博广场</b>
                                    </h5>
                                </div>
                            </div>
                            <br>
                            <div class="row justify-content-start">
                                <div class="row justify-content-center col">
                                    <div class="btn-group" style="font-weight: bolder">
                                        <span class="btn" style="background-color: #FFC107; color: #000000;">当前条数</span>
                                        <asp:DropDownList ID="DropDownList1" class="btn btn-warning dropdown-toggle dropdown-toggle-split" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>8</asp:ListItem>
                                            <asp:ListItem>16</asp:ListItem>
                                            <asp:ListItem>32</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row justify-content-center col">
                                    <div class="btn-group" style="font-weight: bolder">
                                        <span class="btn" style="background-color: #FFC107; color: #000000;">显示顺序</span>
                                        <asp:DropDownList ID="DropDownList2" class="btn btn-warning dropdown-toggle dropdown-toggle-split" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                            <asp:ListItem>热度</asp:ListItem>
                                            <asp:ListItem>时间</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="card-body container " style="background-color: #000000">
                                <div class="container text-center" style="color: #FFFFFF; font-size: 30px; font-weight: bolder;">
                                    <asp:Label ID="Label_nothing" runat="server" Text="广场中没有微博！" Visible="false"></asp:Label>
                                </div>
                                <br />
                                <asp:ListView ID="ListView1" runat="server" OnItemCommand="ListView1_SelectedIndexChanged">
                                    <LayoutTemplate>
                                        <span id="itemPlaceholder" runat="server"></span>
                                        <div class="row justify-content-center">
                                            <asp:DataPager ID="DataPager1" class="page-item" runat="server" PageSize="4">
                                                <Fields>

                                                    <asp:NextPreviousPagerField ButtonCssClass="btn btn-warning" RenderDisabledButtonsAsLabels="False" ShowFirstPageButton="True" ShowLastPageButton="False" ShowPreviousPageButton="True" ShowNextPageButton="False" FirstPageText="&lt&lt" LastPageText="&gt&gt" PreviousPageText="&lt" NextPageText="&gt" />
                                                    <asp:NumericPagerField CurrentPageLabelCssClass="btn btn-warning" NextPreviousButtonCssClass="btn btn-warning" NumericButtonCssClass="btn btn-warning" />
                                                    <asp:NextPreviousPagerField ButtonCssClass="btn btn-warning" RenderDisabledButtonsAsLabels="False" ShowFirstPageButton="False" ShowLastPageButton="True" ShowNextPageButton="True" ShowPreviousPageButton="False" FirstPageText="&lt&lt" PreviousPageText="&lt" LastPageText="&gt&gt" NextPageText="&gt" />

                                                </Fields>
                                            </asp:DataPager>
                                        </div>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <div class="card mb-3" style="background-color: #333333">
                                            <div class="card-header container" style="background: #333333">
                                                <div class="row justify-content-between">
                                                    <div class="col-6">
                                                        <b class="" style="font-weight: bolder; font-family: 宋体; font-size: 20px; color: #FFFFFF;"><%# Eval("name_user")%></b>
                                                        <asp:Button ID="Button_follow" Style="font-weight: bolder" CssClass="btn btn-sm btn-warning" runat="server" Text="查看主页" CommandName="user_index" CommandArgument='<%# Eval("id_user")%>' />
                                                    </div>
                                                    <div class="">
                                                        <span class="btn btn-sm" style="background-color: #F7971D; font-family: 宋体, Arial, Helvetica, sans-serif; font-weight: bolder; font-size: 14px;">热度 <span class="badge badge-light" style="font-family: 'times New Roman', Times, serif; font-weight: bolder; font-size: 14px;"><%# Eval("score")%></span></span>
                                                    </div>

                                                </div>

                                            </div>
                                            <div class="card-body" style="background-color: #666666">
                                                <div class="text-left">
                                                </div>

                                                <div class="col container  text-center">

                                                    <p class="card-text" style="color: #FFFFFF"><%# Eval("text")%></p>

                                                </div>
                                            </div>
                                            <div class="card-footer text-muted" style="background: #333333">
                                                <div class="container">
                                                    <div class="row justify-content-between">
                                                        <asp:Button ID="Button_comment" class="col-2 btn btn-sm btn-outline-warning " runat="server" Text="评论" CommandName="Comment" CommandArgument='<%# Eval("id_blog")%>' />
                                                        <asp:Button ID="Button1" class="col-2 btn btn-sm btn-outline-warning" runat="server" Text="点赞" CommandName="Nice" CommandArgument='<%# Eval("id_blog")%>' />

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                    </ItemTemplate>
                                </asp:ListView>
                                <br />
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
