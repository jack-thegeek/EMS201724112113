<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Manage_dept.aspx.cs" Inherits="EMS201724112113.Manage_dept" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <asp:Button ID="Button1" runat="server" Text="新增部门" class="btn-sm btn-primary" OnClick="Button1_Click"/>
        <table class="table table-bordered table-sm">
            <thead>
                <tr>
                    <th>部门编号</th>
                    <th>部门名称</th>
                    <th>部门负责人</th>
                    <th>编辑</th>
                    <th>删除</th>
                </tr>
            </thead>
            <%for (int i = 0; i < deptlist.Count; i++)
            {%>
            <tbody>
                <tr>
                    <td><%=deptlist[i].DeptId%></td>
                    <td><%=deptlist[i].DeptName%></td>
                    <td><%=deptlist[i].DeptMgr%></td>
                    <td><a href="Edit_department.aspx?id=<%=deptlist[i].DeptId%>" class="btn-sm btn-secondary">修改</a></td>
                    <td>
                        <a href="Del.aspx?del=dept&id=<%=deptlist[i].DeptId%>" class="btn-sm btn-warning">删除</a>
                    </td>
                </tr>
            </tbody>
            <%}%>
        </table>
    </div>

</asp:Content>
