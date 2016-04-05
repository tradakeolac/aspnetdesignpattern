<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPNETPatterns.Chap8.FrontController.UI.Web._Default" %>
<%@ Import Namespace="ASPNETPatterns.Chap8.FrontController.Controller.Storage" %>
<%@ Import Namespace="ASPNETPatterns.Chap8.FrontController.Model" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <% Product product = (Product)ViewStorageFactory.GetStorage().Get(ViewStorageKeys.Product); %>

    <h2><%=product.Name %></h2>
    <p>pay: <%=string.Format("{0:C}", product.Price) %></p>
    <p><%=product.Description %></p>
</asp:Content>
