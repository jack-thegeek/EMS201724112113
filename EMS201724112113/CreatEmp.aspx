<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CreatEmp.aspx.cs" Inherits="EMS201724112113.CreatEmp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mw-480">
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
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="deptName" DataValueField="deptId"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="select distinct e.deptId,d.deptName
from department d,employee e
where d.deptId = e.deptId"></asp:SqlDataSource>
        </div>
        <div class="form-group">
          <label for="txtIsMgr">是否是管理员:</label>
            <asp:DropDownList ID="DropDownList2" runat="server">
                <asp:ListItem Value="1">是</asp:ListItem>
                <asp:ListItem Value="0">否</asp:ListItem>
            </asp:DropDownList>
        </div>
        <asp:Button ID="Button1" runat="server" Text="新增员工" class="btn btn-info" OnClick="Button1_Click"/>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </div>
</asp:Content>
