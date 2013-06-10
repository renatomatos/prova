<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Model.LoginModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Autenticação</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

            <fieldset>
                <legend>Dados da sua conta</legend>
                
                <div class="editor-label">
                    <%: Html.Label("Usuário") %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.Login) %>
                    <%: Html.ValidationMessageFor(m => m.Login) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.Label("Senha") %>
                </div>
                <div class="editor-field">
                    <%: Html.PasswordFor(m => m.Senha)%>
                    <%: Html.ValidationMessageFor(m => m.Senha) %>
                </div>

                <p>
                    <input type="submit" value="Entrar" />
                </p>
            </fieldset>

    <% } %>

</asp:Content>

