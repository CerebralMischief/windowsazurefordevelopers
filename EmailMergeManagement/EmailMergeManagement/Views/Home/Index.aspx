<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%:Html.Encode(ViewData["Message"])%>
    </title>
</head>
<body>
    <h1>
        <%:Html.Encode(ViewData["Message"])%>
    </h1>
    <p>
        This ASP.NET MVC Windows Azure Project provides examples around 
        the Windows Azure Storage usage utilizing the Windows Azure SDK.
    </p>
    <ul>
        <li>
            <%:Html.ActionLink("Windows Azure Table Storage", "Index",
                                              "Storage")%></li>
    </ul>
</body>
</html>
