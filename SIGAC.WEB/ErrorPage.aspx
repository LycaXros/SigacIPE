<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="SIGAC.WEB.ErrorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <% if (string.IsNullOrWhiteSpace(Page.Title))
            { %>
            SIGAC | P.N. R.D.
        <% }
            else
            { %>
            SIGAC | <%=Page.Title%> | P.N. R.D.
        <% } %>
    </title>
    <meta http-equiv="content-type" content="text/html;charset=utf-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width" />
    <meta name="author" content="ComputoIPE - Instituto Policial de Eduacion" />
    <meta name="keywords" content="" />
    <meta name="description" content="" />

    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>
    <link href="https://use.fontawesome.com/releases/v5.0.4/css/all.css" rel="stylesheet"/>
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Lato" />
</head>
<body>
    <div class="w3-content">
        <h2>Error:</h2>
        <p></p>
        <asp:Label ID="FriendlyErrorMsg" runat="server" Text="Label" Font-Size="Large" Style="color: red"></asp:Label>

        <asp:Panel ID="DetailedErrorPanel" runat="server" Visible="false">
            <p>&nbsp;</p>
            <h4>Detailed Error:</h4>
            <p>
                <asp:Label ID="ErrorDetailedMsg" runat="server" Font-Size="Small" /><br />
            </p>

            <h4>Error Handler:</h4>
            <p>
                <asp:Label ID="ErrorHandler" runat="server" Font-Size="Small" /><br />
            </p>

            <h4>Detailed Error Message:</h4>
            <p>
                <asp:Label ID="InnerMessage" runat="server" Font-Size="Small" /><br />
            </p>
            <p>
                <asp:Label ID="InnerTrace" runat="server" />
            </p>
        </asp:Panel>
    </div>
</body>
</html>
