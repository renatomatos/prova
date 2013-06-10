<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Model.CidadeModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Cidade - Alterar</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Campos</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.EstadoCodigo) %>
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model => model.EstadoCodigo, ViewData["uf"] as List<SelectListItem>)%>
                <%: Html.ValidationMessageFor(model => model.EstadoCodigo)%>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Nome) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Nome) %>
                <%: Html.ValidationMessageFor(model => model.Nome) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Capital) %>
            </div>
            <div class="editor-field">
                <%: Html.CheckBoxFor(model => model.Capital) %>
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

