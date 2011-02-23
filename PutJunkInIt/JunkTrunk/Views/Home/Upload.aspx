<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<JunkTrunk.Models.BlobModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Upload an Image
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
		Upload</h2>
	<% using (Html.BeginForm("UploadFile", "Home", FormMethod.Post, new { enctype = "multipart/form-data" }))
	   {%>
	<%: Html.ValidationSummary(true) %>
	<fieldset>
		<legend>Fields</legend>
	  
		<div class="editor-label">
			Select file to upload to Windows Azure Blob Storage:
		</div>
		<div class="editor-field">
			<input type="file" id="fileUpload" name="fileUpload" />
		</div>
		<p>
			<input type="submit" value="Upload" />
		</p>
	</fieldset>
	<% } %>
	<div>
		<%: Html.ActionLink("Back to List", "Index") %>
	</div>
</asp:Content>
