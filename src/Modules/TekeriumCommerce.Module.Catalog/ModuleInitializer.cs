﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using TekeriumCommerce.Infrastructure.Modules;
using TekeriumCommerce.Module.Catalog.Services;

namespace TekeriumCommerce.Module.Catalog
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IProductPricingService, ProductPricingService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
        }
    }
}