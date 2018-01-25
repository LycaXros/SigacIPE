<%@ Page Title="Error Handler" Language="C#" AutoEventWireup="true" CodeBehind="ErrorHandlerPage.aspx.cs" Inherits="SIGAC.WEB.ErrorHandlerPage" %>

<!DOCTYPE html>

<html>
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
    <div class="page-wrap">
        <h1 id="Number" runat="server"></h1>
        <h2 id="Name" runat="server"></h2>
        <p>Well, what to say. Hmm? Sorry ...</p>
        <p><a href="/">Home</a></p>
        <div>
            <h3>Descripcion</h3><hr />
            <p id="descr" runat="server"></p>
        </div>
    </div>
</body>
</html>
