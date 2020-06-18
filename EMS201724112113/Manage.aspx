<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="EMS201724112113.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container">
        <table class="table-responsive table-bordered table-sm table-hover table-condensed">
            <thead>
                <tr style="text-align: center;">
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
            <tbody style="text-align: center;">
                <tr>
                    <td><%=eqptlist[i].EqptId%></td>
                    <td><%=eqptlist[i].EqptName%></td>
                    <td style="width:30%;text-align:left;"><%=eqptlist[i].Specifications%></td>
                    <td style="max-width:90px"><img src="images/<%=eqptlist[i].Picture%>.jpg" style="width:50%"/></td>
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