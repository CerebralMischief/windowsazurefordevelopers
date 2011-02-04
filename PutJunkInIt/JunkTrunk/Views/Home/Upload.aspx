<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<JunkTrunk.Models.BlobModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Upload
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Upload</h2>
    <!-- Added form code - be sure to copy -->
    <% using (Html.BeginForm("UploadFile", "Home", FormMethod.Post, new { enctype = "multipart/form-data" }))
       {%>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Fields</legend>
        <%--  This is the code that needs removed.
		   <div class="editor-label">
				<%: Html.LabelFor(model => model.FileName) %>
			</div>
			<div class="editor-field">
				<%: Html.TextBoxFor(model => model.FileName) %>
				<%: Html.ValidationMessageFor(model => model.FileName) %>
			</div>
			
			<div class="editor-label">
				<%: Html.LabelFor(model => model.DownloadedOn) %>
			</div>
			<div class="editor-field">
				<%: Html.TextBoxFor(model => model.DownloadedOn) %>
				<%: Html.ValidationMessageFor(model => model.DownloadedOn) %>
			</div>
			
			<div class="editor-label">
				<%: Html.LabelFor(model => model.Description) %>
			</div>
			<div class="editor-field">
				<%: Html.TextBoxFor(model => model.Description) %>
				<%: Html.ValidationMessageFor(model => model.Description) %>
			</div>--%>
        <!-- Added fields - be sure to copy -->
        <div class="editor-label">
            Select file to upload to Windows Azure Blob Storage:
        </div>
        <div class="editor-field">
            <input type="file" id="fileUpload" name="fileUpload" />
        </div>
        <p>
            <input type="submit" value="Upload" />
        </p>
        <!-- End added fields section (the submit button was just edited to have Upload written on it. -->
    </fieldset>
    <% } %>
    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>
