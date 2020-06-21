<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Edit_employee.aspx.cs" Inherits="EMS201724112113.Edit_employee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    <div class="container mw-480">
        <div class="form-group">
          <label for="txtId">工号:</label>
            <asp:TextBox ID="txtId" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="form-group">
          <label for="txtName">姓名:</label>
            <asp:TextBox ID="txtName" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
          <label for="txtPwd">密码:</label>
            <asp:TextBox ID="txtPwd" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
          <label for="txtPhone">手机:</label>
            <asp:TextBox ID="txtPhone" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
          <label for="txtDept">所属部门:</label>
            <asp:TextBox ID="txtDept" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="deptName" DataValueField="deptId" AutoPostBack="True"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [deptName], [deptId] FROM [department]"></asp:SqlDataSource>
        </div>
        <div class="form-group">
          <label for="txtIsMgr">是否是管理员:</label>
            <asp:TextBox ID="txtIsMgr" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
            <asp:DropDownList ID="DropDownList2" runat="server">
                <asp:ListItem Value="1">是</asp:ListItem>
                <asp:ListItem Value="0">否</asp:ListItem>
            </asp:DropDownList>
        </div>
        <asp:Button ID="Button1" runat="server" Text="保存" class="btn btn-info" OnClick="Button1_Click"/>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </div>
</asp:Content>
