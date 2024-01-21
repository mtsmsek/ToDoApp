using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Api.Application.Services.Repositories.ToDos;
using ToDoApp.Api.Application.Services.Repositories.Users;
using ToDoApp.Infrastructure.Persistance.Context;
using ToDoApp.Infrastructure.Persistance.Repositories.ToDos;
using ToDoApp.Infrastructure.Persistance.Repositories.Users;

namespace ToDoApp.Infrastructure.Persistance.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services,
                                                                       IConfiguration configuration)
        {
            services.AddDbContext<ToDoAppDbContext>(conf =>
            {
                conf.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"), opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            });



            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IToDoRepository, ToDoRepository>();

            //var seedData = new SeedData();
            //seedData.SeedAsync(configuration).GetAwaiter().GetResult();
            return services;
        }
    }
}
