<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage" MasterPageFile="~/Views/Shared/Site.Master" %>

<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    Blob Uploader
</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <p>
        Select the file to upload and then enter the information. Click on upload to complete
        the process.</p>
    <table>
        <tr valign="top">
            <h2>
                Files uploaded to server</h2>
            <div id="dialog" title="Upload files">
                <% using (Html.BeginForm("Upload", "Home", FormMethod.Post, new { enctype = "multipart/form-data" }))
                   {%><br />
                <p>
                    <input type="file" id="fileUpload" name="fileUpload" size="23" />
                </p>
                <br />
                <p>
                    <input type="submit" value="Upload file" /></p>
                <% } %>
            </div>
            <a href="#" onclick="jQuery('#dialog').dialog('open'); return false">Upload File</a>
        </tr>
    </table>
</asp:Content>
<asp:Content runat="server" ID="trailing" ContentPlaceHolderID="trailingJavascript">
    <%-- <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("[ID$='Date']").datepicker();
            $("[ID$='FileUpload']").css("width", "425px");
        });
    </script>--%>
</asp:Content>
