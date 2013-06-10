<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Model.UsuarioModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <script src="/Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="/Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script>

    <script type="text/javascript">

        function RefreshPage() {
            document.location.href = "/Usuario/Index";
        }
    
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Usuários - Lista</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Código
            </th>
            <th>
                Login
            </th>
            <th>
                Nome
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Alterar", "Edit", new {  id=item.Id }) %> |
                <%: Ajax.ActionLink("Excluir", "Delete", new { id = item.Id }, new AjaxOptions { Confirm = "Confirma excluir o registro selecionado?", HttpMethod = "DELETE", OnComplete = "RefreshPage" })%>
            </td>
            <td>
                <%: item.Id %>
            </td>
            <td>
                <%: item.Login %>
            </td>
            <td>
                <%: item.Nome %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Novo", "Add") %>
    </p>

</asp:Content>

