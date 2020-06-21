<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EMS201724112113.Login" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>登录</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/jquery-3.5.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link href="css/ems.css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <div class="container mt-5 mw-480">
                <div class="card rounded">
                    <div class="card-header text-center"><h2>用户登录</h2></div>
                    <div class="card-body">
                        <div class="form-group">
                            <label for="usr">工号:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入工号" ControlToValidate="empId" ForeColor="Red"></asp:RequiredFieldValidator>
                            </label>
                            &nbsp;<asp:TextBox ID="empId" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="pwd">密码:</label><label for="usr"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="请输入密码" ControlToValidate="pwd" ForeColor="Red"></asp:RequiredFieldValidator>
                            </label>&nbsp;<asp:TextBox ID="pwd" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="card-footer text-right">
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                        <asp:Button ID="Button1" runat="server" Text="登录" class="btn btn-primary ml-2" OnClick="Button1_Click"/>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>

</html>