using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Ejemplo_importante.datos;
using Ejemplo_importante.datos.Interfaces;
using Ejemplo_importante.datos.Repository;
using Ejemplo_importante.Interfaces;
using Ejemplo_importante.Busines;

namespace Ejemplo_impòrtante
{
    public static class UnityConfig
    {
        public static IUnityContainer Container { get; private set; }

        public static void RegisterComponents()
        {
            // Inicializar el contenedor
            Container = new UnityContainer();

            // Registrar DbContexts
            Container.RegisterType<ApplicationDbContext>();
            Container.RegisterType<SecondDbContext>();

            // Registrar Repositorios
            Container.RegisterType<ICustomerRepository, CustomerRepository>();
            Container.RegisterType<IOrderRepository, OrderRepository>();
            Container.RegisterType<ICategoryRepository, CategoryRepository>();
            Container.RegisterType<IProductRepository, ProductRepository>();

            // Registrar Servicios de Negocio
            Container.RegisterType<ICustomerService, CustomerService>();
            Container.RegisterType<IOrderService, OrderService>();
            Container.RegisterType<ICategoryService, CategoryService>();
            Container.RegisterType<IProductService, ProductService>();

            // Configurar el DependencyResolver para MVC
            DependencyResolver.SetResolver(new UnityDependencyResolver(Container));
        }
    }
}