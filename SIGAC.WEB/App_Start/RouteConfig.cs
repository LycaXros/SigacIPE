using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace SIGAC.WEB
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //
            //Sistema
            //
            routes.MapPageRoute("Sistema.Usuarios", "Sistema/Usuarios", "~/Vistas/Sistema/Usuarios.aspx");
            routes.MapPageRoute("Sistema.Cursos", "Sistema/Cursos", "~/Vistas/Sistema/Cursos.aspx");
            routes.MapPageRoute("Sistema.Recintos", "Sistema/Recintos", "~/Vistas/Sistema/Recintos.aspx");


            //
            // Programas
            //
            routes.MapPageRoute("Programas.Administrar", "Programas/Administrar", "~/Vistas/AdministrarProgramas.aspx");

            //
            // PAE
            //
            routes.MapPageRoute("PAE.Administrar", "PAE/Administrar", "~/Vistas/AdministrarPAE/Adm_Pae.aspx");

            //
            // Default, Login, ErrorPage
            //
            routes.MapPageRoute("Default", string.Empty , "~/Default.aspx");
            routes.MapPageRoute("Login", "IniciarSesion", "~/login.aspx");
            routes.MapPageRoute("ErrorPage", "error/{handler}/{msg}", "~/ErrorPage.aspx");
        }
    }
}
