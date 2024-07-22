using System.Linq;
using System.Web.Mvc;
using ProductManagement;

using Unity.AspNet.Mvc;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ProductManagement.App_Start.UnityMvcActivator), nameof(ProductManagement.App_Start.UnityMvcActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(ProductManagement.App_Start.UnityMvcActivator), nameof(ProductManagement.App_Start.UnityMvcActivator.Shutdown))]

namespace ProductManagement.App_Start
{
    public static class UnityMvcActivator
    {
        /// <summary>
        /// Integrates Unity when the application starts.
        /// </summary>
        public static void Start()
        {
            var container = UnityConfig.Container;

            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(container));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        /// <summary>
        /// Disposes the Unity container when the application is shut down.
        /// </summary>
        public static void Shutdown()
        {
            var container = UnityConfig.Container;
            container.Dispose();
        }
    }
}