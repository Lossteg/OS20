﻿using FilmoSearchPortal.Domain.Interfaces;
using FilmoSearchPortal.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FilmoSearchPortal.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbConnectionString");
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString, b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName));
                options.EnableSensitiveDataLogging();
            });
            services.AddScoped<IRepositoryManager, RepositoryManager>();

            return services;
        }
    }
}
