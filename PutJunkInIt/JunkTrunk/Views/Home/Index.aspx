<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%: ViewData["Message"] %></h2>
    <%--  Remove this code for the book example.
    <p>
        To learn more about ASP.NET MVC visit <a href="http://asp.net/mvc" title="ASP.NET MVC Website">http://asp.net/mvc</a>.
    </p>--%>
    <!-- Add this to the book example. -->
    <p>
        <%: Html.ActionLink("Upload", "Upload", "Home") %>
        a file to Windows Azure Blob Storage.
    </p>
    <p>
        Existing Files:<br />
        <ul>
            <li>soon to be here.</li>
        </ul>
    </p>
</asp:Content>
