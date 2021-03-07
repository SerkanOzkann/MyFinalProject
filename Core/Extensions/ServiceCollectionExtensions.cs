using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions // Extensions için static olmak zorundadır.
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection,
            ICoreModule[] modules) //neyi genişletmek istiyorsun?
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }

            return ServiceTool.Create(serviceCollection);

            //bizim core katmanıda dahıl olmak uzere ekleyecegımız butun extensionsları bır arada tutar.

        }
    }
}
