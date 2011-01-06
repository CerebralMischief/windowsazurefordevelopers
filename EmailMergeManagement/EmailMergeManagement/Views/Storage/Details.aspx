<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<EmailMergeManagement.Models.EmailMergeModel>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Details</title>
</head>
<body>
    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Email</div>
        <div class="display-field"><%: Model.Email %></div>
        
        <div class="display-label">First</div>
        <div class="display-field"><%: Model.First %></div>
        
        <div class="display-label">Last</div>
        <div class="display-field"><%: Model.Last %></div>
        
        <div class="display-label">LastEditStamp</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.LastEditStamp) %></div>
        
        <div class="display-label">Timestamp</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.Timestamp) %></div>
        
        <div class="display-label">PartitionKey</div>
        <div class="display-field"><%: Model.PartitionKey %></div>
        
        <div class="display-label">RowKey</div>
        <div class="display-field"><%: Model.RowKey %></div>
        
    </fieldset>
    <p>
<%: Html.ActionLink("Edit", "Edit", new { id = Model.RowKey })%> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>

</body>
</html>
