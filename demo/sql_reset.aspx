<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sql_reset.aspx.cs" Inherits="sql_reset" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head lang="zh-cn">
    <!--导入bootstrap css文件-->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <!--适配-->
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <title>MicroBlog 管理后台</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="container">
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <div class="row">
                        <div class="col-3"></div>
                        <div class="alert alert-danger col-6" style="background-color:#DC3545" role="alert">
                            <br />
                            <br />
                            <div class="text-center">
                                <!-- Button trigger modal -->
                                <button type="button" class="btn btn-lg btn-danger" data-toggle="modal" data-target="#exampleModalCenter">
                                    重置数据库
                                </button>

                                <!-- Modal -->
                                <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                                    <div class="modal-dialog modal-dialog-centered" role="document">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <h5 class="modal-title" id="exampleModalCenterTitle">警告</h5>
                                                <button type="button" style="font-weight: bolder" class="close" data-dismiss="modal" aria-label="Close">
                                                    <span aria-hidden="true">&times;</span>
                                                </button>
                                            </div>
                                            <div class="modal-body">
                                                <p class="col">
                                                    此操作会将本站中所有用户数据、微博数据、评论数据、好友关系清空！
                                                    <br />
                                                    如若确定进行此操作请在下面文本框输入<b>我已了解此操作后果</b>，并点击确认重置！
                                                </p>
                                                <div class="text-center">
                                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-secondary" data-dismiss="modal">返回</button>
                                                <asp:Button ID="Button1" class="btn btn-danger" runat="server" Text="确定重置" OnClick="Button1_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <br />
                            <br />
                        </div>
                        <div class="col-3"></div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>
