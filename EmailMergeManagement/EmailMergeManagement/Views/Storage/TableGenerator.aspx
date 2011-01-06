<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<EmailMergeManagement.Models.DataCreationParametersModel>" %>

<%@ Import Namespace="HtmlEnumDropDownExtensions" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TableGenerator</title>
</head>
<body>
    <div>
        <h1>
            Create Sample Data in Windows Azure Table Storage</h1>
        <p>
            This page simply creates the number of rows specified below in the Email Merge Listing
            Table Store.</p>
        <% using (Html.BeginForm())
           {%>
        <%: Html.ValidationSummary(true) %>
        <fieldset>
            <legend>Fields</legend>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Rows) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Rows) %>
                <%: Html.ValidationMessageFor(model => model.Rows)%>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.SexOfName) %>
            </div>
            <div class="editor-field">
                <%: Html.EnumDropDownListFor(model => model.SexOfName) %>
                <%: Html.ValidationMessageFor(model => model.SexOfName)%>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.DeleteExistingRows) %>
            </div>
            <div class="editor-field">
                <%: Html.CheckBoxFor(model => model.DeleteExistingRows) %>
            </div>
            <p>
                <input type="submit" value="Create Rows" />
            </p>
        </fieldset>
        <% } %>
    </div>
</body>
</html>
