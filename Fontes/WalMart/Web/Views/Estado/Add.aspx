<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Model.EstadoModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Estados - Novo</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Campos</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Pais) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Pais) %>
                <%: Html.ValidationMessageFor(model => model.Pais) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Nome) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Nome) %>
                <%: Html.ValidationMessageFor(model => model.Nome) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Sigla) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Sigla) %>
                <%: Html.ValidationMessageFor(model => model.Sigla) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Regiao) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Regiao) %>
                <%: Html.ValidationMessageFor(model => model.Regiao) %>
            </div>
            
            <p>
                <input type="submit" value="Salvar" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Voltar", "Index") %>
    </div>

</asp:Content>

