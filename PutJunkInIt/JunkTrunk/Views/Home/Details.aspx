<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<JunkTrunk.Models.FileItemModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Details</h2>
    <fieldset>
        <legend>Fields</legend>
        <div class="display-label">
            FileName</div>
        <div class="display-field">
            <%: Model.FileName %></div>
        <div class="display-label">
            DownloadedOn</div>
        <div class="display-field">
            <%: String.Format("{0:g}", Model.DownloadedOn) %></div>
        <div class="display-label">
            Description</div>
        <div class="display-field">
            <%: Model.Description %></div>
    </fieldset>
    <p>
        <%: Html.ActionLink("Upload New File", "Upload") %>
        |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
</asp:Content>
