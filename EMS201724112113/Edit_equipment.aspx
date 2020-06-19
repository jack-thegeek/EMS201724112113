<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Edit_equipment.aspx.cs" Inherits="EMS201724112113.Edit_equipment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="container mw-480">
        <div class="form-group">
          <label for="TextBox1">设备名称:</label>
            <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
          <label for="TextArea1">规格:</label>
            <textarea id="TextArea1" cols="60" rows="5" runat="server" class="form-control"></textarea>
        </div>
        <div class="form-group">
          <label for="TextBox3">图片:</label>
            
        </div>
        <div class="form-group">
          <label for="TextBox4">价格:</label>
            <asp:TextBox ID="TextBox4" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
          <label for="TextBox5">购入年份:<asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="请输入正确年份" MinimumValue="1990" MaximumValue="2099" ControlToValidate="TextBox5"></asp:RangeValidator>
            </label>
&nbsp;<asp:TextBox ID="TextBox5" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
          <label for="TextBox6">存放位置:</label>
            <asp:TextBox ID="TextBox6" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
          <label for="TextBox7">负责人:</label>
            <asp:TextBox ID="TextBox7" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
            <asp:DropDownList class="dropdown" ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="empId"></asp:DropDownList>
            <asp:SqlDataSource  ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT distinct em.empId, em.name FROM department AS d INNER JOIN equipment AS eq ON d.deptMgrId = eq.mgrId INNER JOIN employee AS em ON d.deptMgrId = em.empId"></asp:SqlDataSource>
        </div>
        <div class="form-group">
          <label for="TextBox8">数量:</label>&nbsp;
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TextBox8" ErrorMessage="请输入正确数量" MaximumValue="999" MinimumValue="1"></asp:RangeValidator>
            <asp:TextBox ID="TextBox8" runat="server" class="form-control"></asp:TextBox>
        </div>
        <asp:Button ID="Button1" runat="server" Text="保存" class="btn btn-info" OnClick="Button1_Click"/>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </div>
</asp:Content>
