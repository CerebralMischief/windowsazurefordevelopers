<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<JunkTrunk.Models.FileItemModel>>" %>

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
    Existing Files:<br />
    <table>
        <tr>
            <th>
            </th>
            <th>
                FileName
            </th>
            <th>
                DownloadedOn
            </th>
            <th>
                Description
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%: Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ })%>
                |
                <%: Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ })%>
            </td>
            <td>
                <%: item.FileName %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.DownloadedOn) %>
            </td>
            <td>
                <%: item.Description %>
            </td>
        </tr>
        <% } %>
    </table>
    <p>
        <%: Html.ActionLink("Upload a New File", "Upload") %>
    </p>
</asp:Content>
