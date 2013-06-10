<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Model.EstadoModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <script src="/Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="/Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script>

    <script type="text/javascript">

        function RefreshPage() {
            document.location.href = "/Estado/Index";
        }
    
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Estados - Lista</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Código
            </th>
            <th>
                País
            </th>
            <th>
                Nome
            </th>
            <th>
                Sigla
            </th>
            <th>
                Região
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Alterar", "Edit", new { codigo = item.Codigo }) %> |
                <%: Ajax.ActionLink("Excluir", "Delete", new { codigo = item.Codigo }, new AjaxOptions { Confirm = "Confirma excluir o registro selecionado?", HttpMethod = "DELETE", OnComplete = "RefreshPage" })%>
            </td>
            <td>
                <%: item.Codigo %>
            </td>
            <td>
                <%: item.Pais %>
            </td>
            <td>
                <%: item.Nome %>
            </td>
            <td>
                <%: item.Sigla %>
            </td>
            <td>
                <%: item.Regiao %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Novo", "Add") %>
    </p>

</asp:Content>

