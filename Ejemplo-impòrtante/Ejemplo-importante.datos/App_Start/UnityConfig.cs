using Unity;
using Unity.Mvc5;
using System.Web.Mvc;

namespace Ejemplo_importante.datos
{
    public static class UnityConfig
    {
        private static IUnityContainer _container;

        public static IUnityContainer Container
        {
            get
            {
                if (_container == null)
                {
                    _container = new UnityContainer();
                    RegisterComponents(_container);
                }
                return _container;
            }
        }

        public static void RegisterComponents(IUnityContainer container)
        {
            // Registrar dependencias, por ejemplo:
            // container.RegisterType<IMyRepository, MyRepository>();

            // Configurar el DependencyResolver para MVC, si es necesario.
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}