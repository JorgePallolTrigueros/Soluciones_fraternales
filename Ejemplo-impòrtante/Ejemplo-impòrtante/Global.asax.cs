﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Ejemplo_impòrtante
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            UnityConfig.RegisterComponents(); // Inicializar Unity al iniciar la aplicación

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}