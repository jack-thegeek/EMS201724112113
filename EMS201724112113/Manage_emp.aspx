<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Manage_emp.aspx.cs" Inherits="EMS201724112113.Manage_emp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <div class="container">
        <table class="table table-bordered table-sm">
            <thead>
                <tr>
                    <th>工号</th>
                    <th>姓名</th>
                    <th>密码</th>
                    <th>手机</th>
                    <th>所属部门</th>
                    <th>是否是管理员</th>
                </tr>
            </thead>
            <%for (int i = 0; i < emplist.Count; i++)
            {%>
            <tbody>
                <tr>
                    <td><%=emplist[i].EmpId%></td>
                    <td><%=emplist[i].Name%></td>
                    <td><%=emplist[i].Password%></td>
                    <td><%=emplist[i].Phone%></td>
                    <td><%=emplist[i].Dept%></td>
                    <td><%=emplist[i].IsMgr%></td>
                </tr>
            </tbody>
            <%}%>
        </table>
    </div>
</asp:Content>
