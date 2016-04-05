<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPPatterns.Chap3.Layered.WebUI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DropDownList AutoPostBack="true" ID="ddlCustomerType" runat="server">
        <asp:ListItem Value="0">Standard</asp:ListItem>
        <asp:ListItem Value="1">Trade</asp:ListItem>
    </asp:DropDownList>    
    <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
    <asp:Repeater ID="rptProducts" runat="server">
        <HeaderTemplate>
            <table>
                <tr>
                    <td>Name</td>
                    <td>RRP</td>
                    <td>Selling Price</td>
                    <td>Discount</td>
                    <td>Savings</td>
                </tr>
                <tr>
                    <td colspan="5"></hr></td>
                </tr>
            </table>
        </HeaderTemplate>
    </asp:Repeater>
</asp:Content>
