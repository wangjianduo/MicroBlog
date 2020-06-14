<%@ Page Language="C#" AutoEventWireup="true" CodeFile="blog_import.aspx.cs" Inherits="blog_import" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <!--导入bootstrap css文件-->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.0/dist/css/bootstrap.min.css">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <!--适配-->
    <style>
        .custom-file-input:lang(zh) ~ .custom-file-label::after {
            content: "浏览";
        }

        .custom-file-label::after {
            content: "浏览";
        }
    </style>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <title>MicroBlog</title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <br />
        <div class="container">

            <div class="container">
                <div class="row card mb-3">
                    <div class="card-body text-center">
                        <h3>导入历史微博</h3>

                        <br />
                        <div class="alert alert-danger" role="alert">
                            请务必下载模板进行导入，并且保证文件名为“模板.xls”，不要随意改动模板中任何格式！<a href="static/Template.xls" class="btn btn-sm btn-outline-danger" download="模板.xls">下载模板</a>
                        </div>
                        <br />

                        <div class="input-group">
                            <div class="custom-file">
                                <asp:FileUpload ID="FileUpload1" type="file" class="custom-file-input" onchange="showFilename(this.files[0])" runat="server" BorderStyle="NotSet" aria-describedby="FileUpload1" />
                                <label id="filename_label" class="custom-file-label" for="FileUpload1">选择文件</label>
                            </div>
                            <div class="input-group-append">
                                <asp:Button ID="Button1" class="btn btn-outline-secondary" runat="server" Text="提交" OnClick="Button1_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script>
        function showFilename(file) {
            $("#filename_label").html(file.name);
        }
    </script>
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.5.1/dist/jquery.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.0/dist/js/bootstrap.min.js"></script>
</body>
</html>
