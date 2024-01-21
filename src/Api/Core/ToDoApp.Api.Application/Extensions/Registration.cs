using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Api.Application.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddApplicationRegistration(this IServiceCollection services)
        {

            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(conf =>
            {
                conf.RegisterServicesFromAssembly(assembly);
            });

            services.AddAutoMapper(assembly);


            return services;
        }
    }
}
