<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CreatEqpt.aspx.cs" Inherits="EMS201724112113.CreatEqpt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mw-480">
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <div class="form-group">
          <label for="TextBox1">设备名称:</label>
            <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
          <label for="TextArea1">规格:</label>
            <textarea id="TextArea1" cols="60" rows="5" runat="server" class="form-control"></textarea>
        </div>
        <div class="form-group">
          <label for="">图片:</label>
            <div>
                <asp:FileUpload ID="FileUpload1" runat="server" class="form-control"/>
                <asp:Label ID="lbl" runat="server" Text=""></asp:Label>
           <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="上传" />
&nbsp;            </div>
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
            <asp:DropDownList class="dropdown" ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="empId"></asp:DropDownList>
            <asp:SqlDataSource  ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT distinct em.empId, em.name FROM department AS d INNER JOIN equipment AS eq ON d.deptMgrId = eq.mgrId INNER JOIN employee AS em ON d.deptMgrId = em.empId"></asp:SqlDataSource>
        </div>
        <div class="form-group">
          <label for="TextBox8">数量:</label>&nbsp;
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TextBox8" ErrorMessage="请输入正确数量" MaximumValue="999" MinimumValue="1"></asp:RangeValidator>
            <asp:TextBox ID="TextBox8" runat="server" class="form-control"></asp:TextBox>
        </div>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <asp:Button ID="Button2" runat="server" Text="新建设备" OnClick="Button2_Click" />
    </div>
</asp:Content>
