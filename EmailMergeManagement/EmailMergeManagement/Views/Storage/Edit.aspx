<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<EmailMergeManagement.Models.EmailMergeModel>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Edit</title>
</head>
<body>
    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Email) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Email) %>
                <%: Html.ValidationMessageFor(model => model.Email) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.First) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.First) %>
                <%: Html.ValidationMessageFor(model => model.First) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Last) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Last) %>
                <%: Html.ValidationMessageFor(model => model.Last) %>
            </div>
            
<%: Html.TextBoxFor(model => model.RowKey, new { @Type="hidden"})%>

            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</body>
</html>

