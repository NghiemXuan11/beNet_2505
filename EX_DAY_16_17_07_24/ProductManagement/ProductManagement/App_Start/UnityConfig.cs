using System;
using ProductManagement.Data.DAOImpl;
using ProductManagement.Data.Interfaces;
using System.Web.Mvc;

using Unity;
using Unity.AspNet.Mvc;

namespace ProductManagement
{
    public static class UnityConfig
    {
        private static IUnityContainer container;

        public static IUnityContainer Container => container;

        public static IUnityContainer RegisterComponents()
        {
            container = new UnityContainer();

            container.RegisterType<IProductRepository, ProductRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }
    }
}