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
            //var settings = new FriendlyUrlSettings();
            //settings.AutoRedirectMode = RedirectMode.Permanent;
            //routes.EnableFriendlyUrls(settings);

            //routes.MapPageRoute("RouteName", "routeUrl", "physicalFile");

            routes.MapPageRoute("Sistema.Usuarios", "Sistema/Usuarios", "~/Vistas/Sistema/Usuarios.aspx");
            routes.MapPageRoute("AdministrarPAE", "PAE/Administrar", "~/Vistas/AdministrarPAE/Adm_Pae.aspx");
            routes.MapPageRoute("Default", string.Empty , "~/Default.aspx");
            routes.MapPageRoute("Login", "IniciarSesion", "~/login.aspx");
            routes.MapPageRoute("ErrorPage", "error/{handler}/{msg}", "~/ErrorPage.aspx");
        }
    }
}
