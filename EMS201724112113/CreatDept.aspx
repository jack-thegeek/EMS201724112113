<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CreatDept.aspx.cs" Inherits="EMS201724112113.CreatDept" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mw-480">
        <div class="form-group">
          <label for="deptName">部门名称:</label>
            <asp:TextBox ID="deptName" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
          <label for="DropDownList1">部门负责人:</label>
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="empId"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [empId], [name] FROM [employee] where isMgr = 1"></asp:SqlDataSource>
        </div>
        
        <asp:Button ID="Button1" runat="server" Text="新建部门" OnClick="Button1_Click" class="btn-sm btn-primary"/>
        <asp:Label ID="Label3" runat="server"></asp:Label>
    </div>
</asp:Content>
