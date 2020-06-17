<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Manage_dept.aspx.cs" Inherits="EMS201724112113.Manage_dept" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <div class="container">
        <table class="table table-bordered table-sm">
            <thead>
                <tr>
                    <th>部门编号</th>
                    <th>部门名称</th>
                    <th>部门负责人</th>
                </tr>
            </thead>
            <%for (int i = 0; i < deptlist.Count; i++)
            {%>
            <tbody>
                <tr>
                    <td><%=deptlist[i].DeptId%></td>
                    <td><%=deptlist[i].DeptName%></td>
                    <td><%=deptlist[i].DeptMgr%></td>
                </tr>
            </tbody>
            <%}%>
        </table>
    </div>

</asp:Content>
