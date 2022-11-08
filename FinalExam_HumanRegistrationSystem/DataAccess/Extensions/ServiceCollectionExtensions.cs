using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddScoped<IUserDbRepository, UserDbRepository>();
            services.AddScoped<IUserInformationDbRepository, UserInformationDbRepository>();
            services.AddScoped<IImageDbRepository, ImageDbRepository>();
            services.AddScoped<IPlaceOfResidenceDbRepository, PlaceOfResidenceDbRepository>();

            return services;
        }
    }
}
