<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<JunkTrunk.Models.FileItemModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%: ViewData["Message"] %></h2>
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
                <form id="Form" method="post" action="<%= Url.Action( "Delete", "Home", new { @identifier = item.ResourceId}) %>">
                    <input type="submit" value="Delete" />
                </form>

                <%: Html.ActionLink("Delete", "Delete", new { identifier = item.ResourceId })%>
            </td>
            <td>
                <%: item.ResourceLocation %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.UploadedOn) %>
            </td>
        </tr>
        <% } %>
    </table>
    <p>
        <%: Html.ActionLink("Upload a New File", "Upload") %>
    </p>

</asp:Content>
