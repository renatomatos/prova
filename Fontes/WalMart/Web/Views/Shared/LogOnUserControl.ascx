<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        Bem vindo <b><%: Page.User.Identity.Name %></b> 
        [ <%: Html.ActionLink("Log Off", "LogOff", "Login") %> ]
<%
    }
    else {
%> 
        [ <%: Html.ActionLink("Log On", "LogOn", "Login") %> ]
<%
    }
%>
