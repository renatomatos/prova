<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Model.UsuarioModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Meus dados</h2>

    <% using (Html.BeginForm()) {%>
    <%: Html.ValidationSummary(true) %>

    <fieldset>
        <legend>Dados - <%: Model.Login %></legend>

        <!-- requerido -->
        <%: Html.HiddenFor(model => model.Id) %>
        <%: Html.HiddenFor(model => model.Login) %>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Nome) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Nome) %>
            <%: Html.ValidationMessageFor(model => model.Nome) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Senha) %>
        </div>
        <div class="editor-field">
            <%: Html.PasswordFor(model => model.Senha) %>
            <%: Html.ValidationMessageFor(model => model.Senha) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.SenhaConfirmacao) %>
        </div>
        <div class="editor-field">
            <%: Html.PasswordFor(model => model.SenhaConfirmacao) %>
            <%: Html.ValidationMessageFor(model => model.SenhaConfirmacao) %>
        </div>

        <p>
            <input type="submit" value="Salvar" />
        </p>
    </fieldset>

    <% } %>

</asp:Content>