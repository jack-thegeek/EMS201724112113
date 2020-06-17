<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="EMS201724112113.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    用户权限 <asp:Label ID="Label1" runat="server"></asp:Label>
    <div class="container">
        <table class="table table-bordered table-sm">
            <thead>
                <tr>
                    <th>编号</th>
                    <th>设备名称</th>
                    <th>规格</th>
                    <th>图片</th>
                    <th>价格</th>
                    <th>购入日期</th>
                    <th>存放位置</th>
                    <th>负责人</th>
                </tr>
            </thead>
            <%for (int i = 0; i < eqptlist.Count; i++)
            {%>
            <tbody>
                <tr>
                    <td><%=eqptlist[i].EqptId%></td>
                    <td><%=eqptlist[i].EqptName%></td>
                    <td><%=eqptlist[i].Specifications%></td>
                    <td><%=eqptlist[i].Picture%></td>
                    <td><%=eqptlist[i].Price%></td>
                    <td><%=eqptlist[i].PurchaseDate%></td>
                    <td><%=eqptlist[i].Location%></td>
                    <td><%=eqptlist[i].Mgr%></td>
                </tr>
            </tbody>
            <%}%>
        </table>
    </div>
</asp:Content>