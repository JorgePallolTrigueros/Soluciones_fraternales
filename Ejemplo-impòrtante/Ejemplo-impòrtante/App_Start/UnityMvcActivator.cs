using System.Linq;
using System.Web.Mvc;
using Unity.AspNet.Mvc;
using Ejemplo_impòrtante; // Asegúrate de que este using apunta al espacio de nombres correcto
using Unity; // Esta directiva es necesaria para IUnityContainer




using System;


[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Ejemplo_impòrtante.UnityMvcActivator), nameof(Ejemplo_impòrtante.UnityMvcActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(Ejemplo_impòrtante.UnityMvcActivator), nameof(Ejemplo_impòrtante.UnityMvcActivator.Shutdown))]

namespace Ejemplo_impòrtante
{
    public static class UnityMvcActivator
    {
        private static IUnityContainer _container;

        public static void Start()
        {
            if (UnityConfig.Container == null)
            {
                UnityConfig.RegisterComponents(); // Inicializa el contenedor si no está inicializado
            }

            _container = UnityConfig.Container;

            if (_container == null)
            {
                throw new InvalidOperationException("El contenedor de Unity no fue inicializado.");
            }

            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(_container));

            DependencyResolver.SetResolver(new UnityDependencyResolver(_container));
        }

        public static void Shutdown()
        {
            _container?.Dispose();
        }
    }
}