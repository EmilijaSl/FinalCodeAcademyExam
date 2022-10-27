using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddScoped<IUserDbRepository, UserDbRepository>();
            services.AddScoped<IUserInformationDbRepository, UserInformationDbRepository>();
            services.AddScoped<IImageDbRepository, ImageDbRepository>();
            services.AddScoped<IUserInformationDbRepository, UserInformationDbRepository>();

            return services;
        }
    }
}
