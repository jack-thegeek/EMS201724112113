<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Edit_department.aspx.cs" Inherits="EMS201724112113.Edit_department" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mw-480">
        <div class="form-group">
          <label for="txtId">部门编号:</label>
            <asp:TextBox ID="txtId" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="form-group">
          <label for="txtId">部门名称:</label>
            <asp:TextBox ID="txtName" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
          <label for="txtId">部门负责人:</label>
            <asp:TextBox ID="txtMgr" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="empId"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [empId], [name] FROM [employee] where isMgr = 1"></asp:SqlDataSource>
        </div>
        
        <asp:Button ID="Button1" runat="server" Text="保存" class="btn btn-info" OnClick="Button1_Click"/>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </div>
</asp:Content>
