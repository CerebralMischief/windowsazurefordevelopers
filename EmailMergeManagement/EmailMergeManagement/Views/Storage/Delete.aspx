<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<EmailMergeManagement.Models.EmailMergeModel>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Delete</title>
</head>
<body>
	<h3>
		Are you sure you want to delete this?</h3>
	<% using (Html.BeginForm())
	   {%>
	<fieldset>
		<legend>Fields</legend>
		<div class="editor-label">
			<%: Html.LabelFor(model => model.Email) %>
		</div>
		<div class="editor-field">
			<%: Html.TextBoxFor(model => model.Email, 
			new { style="display: inactive;"})%>
		</div>
		<div class="editor-label">
			<%: Html.LabelFor(model => model.First) %>
		</div>
		<div class="editor-field">
			<%: Html.TextBoxFor(model => model.First) %>
		</div>
		<div class="editor-label">
			<%: Html.LabelFor(model => model.Last) %>
		</div>
		<div class="editor-field">
			<%: Html.TextBoxFor(model => model.Last) %>
		</div>
		<div class="editor-label">
			<%: Html.LabelFor(model => model.LastEditStamp) %>
		</div>
		<div class="editor-field">
			<%: Html.TextBoxFor(model => model.LastEditStamp, 
			String.Format("{0:g}", Model.LastEditStamp)) %>
		</div>
		<div class="editor-label">
			<%: Html.LabelFor(model => model.Timestamp) %>
		</div>
		<div class="editor-field">
			<%: Html.TextBoxFor(model => model.Timestamp, 
			String.Format("{0:g}", Model.Timestamp)) %>
		</div>
		<div class="editor-label">
			<%: Html.LabelFor(model => model.PartitionKey) %>
		</div>
		<div class="editor-field">
			<%: Html.TextBoxFor(model => model.PartitionKey) %>
		</div>
		<div class="editor-label">
			<%: Html.LabelFor(model => model.RowKey) %>
		</div>
		<div class="editor-field">
			<%: Html.TextBoxFor(model => model.RowKey) %>
		</div>
		<p>
			<input type="submit" value="Delete" />
		</p>
	</fieldset>
	<% } %>
	<div>
		<%: Html.ActionLink("Back to List", "List") %>
	</div>
</body>
</html>
