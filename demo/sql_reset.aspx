<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sql_reset.aspx.cs" Inherits="sql_reset" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head lang="zh-cn">
    <!--导入bootstrap css文件-->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.0/dist/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
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
                                                    此操作会将本站中所有用户数据、评论数据、留言数据、好友关系清空！
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
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.5.1/dist/jquery.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.0/dist/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>
</body>
</html>
