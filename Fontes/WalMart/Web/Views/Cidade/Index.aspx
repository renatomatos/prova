<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Model.CidadeModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <script src="/Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="/Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script>

    <script type="text/javascript">

        function RefreshPage() {
            document.location.href = "/Cidade/Index";
        }
    
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Cidades - Lista</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Codigo
            </th>
            <th>
                Nome
            </th>
            <th>
                Capital
            </th>
            <th>
                Estado
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Alterar", "Edit", new {  codigo = item.Codigo }) %> |
                <%: Ajax.ActionLink("Excluir", "Delete", new { codigo = item.Codigo }, new AjaxOptions { Confirm = "Confirma excluir o registro selecionado?", HttpMethod = "DELETE", OnComplete = "RefreshPage" })%>
            </td>
            <td>
                <%: item.Codigo %>
            </td>
            <td>
                <%: item.Nome %>
            </td>
            <td>
                <%: item.Capital ? "Sim" : "Não" %>
            </td>
            <td>
                <%: item.Estado.Sigla %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Novo", "Add") %>
    </p>

</asp:Content>

