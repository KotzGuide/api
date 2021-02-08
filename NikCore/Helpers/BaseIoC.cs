using Microsoft.Extensions.DependencyInjection;
using NikCore.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NikCore.Helpers
{
    public class BaseIoC
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ErrorContext>();
            services.AddTransient<TokenService>();
            services.AddHttpContextAccessor();
        }
    }
}
