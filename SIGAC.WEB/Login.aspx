<%@ Page Title="LOGIN" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SIGAC.WEB.Login" %>

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
    <link href="../Content/CSS/loginCSS.css" rel="stylesheet" />
</head>
<body>
    <form id="formLogin" runat="server">
        <div class="login-page">
            <img runat="server" src="../Content/Imagenes/LoginBanner.png" alt="Logo CMS" class="login-Logo" />
            <div class="form">
                <asp:Label ID="labelError" runat="server" visible="false" CssClass="errorText"></asp:Label>
                <input id="textboxUsuario" runat="server" type="text" placeholder="Usuario" required="required"/>
                <input id="textboxContraseña" runat="server" type="password" placeholder="Contraseña" required="required"/>
                <asp:Button runat="server" ID="btnIniciarSesion" Text="Iniciar Sesion" OnClick="btnIniciarSesion_Click"></asp:Button>
                <p class="message">&iquest;Credenciales Invalidas? <a href="#">Escribale al Administrador</a></p>
            </div>
        </div>
    </form>
</body>
</html>
