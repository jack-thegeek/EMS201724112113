<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="EMS201724112113.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mw-480 mb-4">
        <div class="input-group mb-3">
            <div class="input-group-prepend">
                <asp:Button ID="Button1" runat="server" Text="新增设备" class="btn-sm btn-primary" OnClick="Button1_Click"/>
            </div>
            <div class="input-group-prepend">
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="eq.eqptId" Selected="True">设备编号</asp:ListItem>
                    <asp:ListItem Value="eq.eqptName">设备名称</asp:ListItem>
                    <asp:ListItem Value="eq.purchaseDate">购入年份</asp:ListItem>
                    <asp:ListItem Value="eq.location">存放位置</asp:ListItem>
                    <asp:ListItem Value="em.name">设备负责人</asp:ListItem>
                    <asp:ListItem Value="d.deptName">部门名称</asp:ListItem>
                </asp:DropDownList>
            </div>
            <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>
            <div class="input-group-append">
                <asp:Button ID="Button2" runat="server" Text="搜索" OnClick="Button2_Click" class="btn btn-success"/>
             </div>
        </div>
    </div>

    <div class="container mw-1344">
        
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
                    <th>修改</th>
                    <th>删除</th>
                </tr>
            </thead>
            <tbody style="text-align: center;">
                <%for (int i = 0; i < eqptlist.Count; i++)
                {%>
                <tr>
                    <td><%=eqptlist[i].EqptId%></td>
                    <td><%=eqptlist[i].EqptName%></td>
                    <td style="width:30%;text-align:left;"><%=eqptlist[i].Specifications%></td>
                    <td style="max-width:90px"><img src="images/<%=eqptlist[i].Picture%>.jpg" style="width:50%"/></td>
                    <td><%=eqptlist[i].Price%></td>
                    <td><%=eqptlist[i].PurchaseDate%></td>
                    <td><%=eqptlist[i].Location%></td>
                    <td><%=eqptlist[i].Mgr%></td>
                    <td><a href="Edit_equipment.aspx?id=<%=eqptlist[i].EqptId%>" class="btn-sm btn-secondary">修改</a></td>
                    <td>
                        <a href="Del.aspx?del=eqpt&id=<%=eqptlist[i].EqptId%>" class="btn-sm btn-warning">删除</a>
                    </td>
                </tr>
                <%}%>
            </tbody>
        </table>
    </div>
</asp:Content>