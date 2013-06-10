<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Cadastros</h2>

    <ul>
        <li><%: Html.ActionLink("Usuários", "Index", "Usuario") %></li>
        <li><%: Html.ActionLink("Estados", "Index", "Estado") %></li>
        <li><%: Html.ActionLink("Cidades", "Index", "Cidade") %></li>
    </ul>

</asp:Content>
