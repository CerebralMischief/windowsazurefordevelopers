<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%: Html.Encode(ViewData["Message"])%>
    </title>
</head>
<body>
    <h1>
        <%: Html.Encode(ViewData["Message"])%>
    </h1>
    <ul>
        <li>Email Merge Items
            <%: Html.ActionLink("List", "List", "Storage") %>. </li>
        <li>
            <%: Html.ActionLink("Create", "Create", "Storage") %>
            a new Email Merge Item. </li>
        <li>
            <%: Html.ActionLink("Add", "TableGenerator", "Storage") %>
            lots of generated data to the Windows Azure Table. </li>
    </ul>
</body>
</html>
