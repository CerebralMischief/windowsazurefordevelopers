<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<JunkTrunk.Models.BlobModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<h2>Delete</h2>

	<h3>Are you sure you want to delete this?</h3>
	<fieldset>
		<legend>Fields</legend>
		
		<div class="display-label">ResourceLocation</div>
		<div class="display-field"><%: Model.ResourceLocation %></div>
		
		<div class="display-label">UploadedOn</div>
		<div class="display-field"><%: String.Format("{0:g}", Model.UploadedOn) %></div>
		
	</fieldset>
	<% using (Html.BeginForm()) { %>
		<p>
			<input type="submit" value="Delete" /> |
			<%: Html.ActionLink("Back to List", "Index") %>
		</p>
	<% } %>

</asp:Content>

