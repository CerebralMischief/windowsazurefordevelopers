<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<EmailMergeManagement.Models.EmailMergeModel>>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>List</title>
</head>
<body>
    <table>
        <tr>
            <th></th>
            <th>
                Email
            </th>
            <th>
                First
            </th>
            <th>
                Last
            </th>
            <th>
                LastEditStamp
            </th>
            <th>
                Timestamp
            </th>
            <th>
                PartitionKey
            </th>
            <th>
                RowKey
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
<%: Html.ActionLink("Edit", "Edit", new {id=item.RowKey }) %> |
<%: Html.ActionLink("Details", "Details", new {id=item.RowKey})%> |
<%: Html.ActionLink("Delete", "Delete", new {id=item.RowKey})%>
            </td>
            <td>
                <%: item.Email %>
            </td>
            <td>
                <%: item.First %>
            </td>
            <td>
                <%: item.Last %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.LastEditStamp) %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.Timestamp) %>
            </td>
            <td>
                <%: item.PartitionKey %>
            </td>
            <td>
                <%: item.RowKey %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</body>
</html>

