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
                <td>Description:</td>
                <td>
                    <textarea id="TextArea1" cols="50" rows="5"></textarea>
                   
                </td>
            </tr>
            <tr valign="top">
                <td>Date:</td>
                <td>
                    <input id="Date" type="text" />
                </td>
            </tr>
            <tr valign="top">
                <td>Select file: </td>
                <td>put uploader here</td>
            </tr>
        </table>
</asp:Content>
<asp:Content runat="server" ID="trailing" ContentPlaceHolderID="trailingJavascript">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("[ID$='Date']").datepicker();
            $("[ID$='FileUpload']").css("width", "425px");
        });
    </script>
</asp:Content>
