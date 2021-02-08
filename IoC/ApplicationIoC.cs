using Data.Interfaces;
using Data.Repositories;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoC
{
    public class ApplicationIoC
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ISaintRepository, SaintRepository>();
            services.AddScoped<ICosmoRepository, CosmoRepository>();
            services.AddScoped<DBContext>();
        }
    }
}
