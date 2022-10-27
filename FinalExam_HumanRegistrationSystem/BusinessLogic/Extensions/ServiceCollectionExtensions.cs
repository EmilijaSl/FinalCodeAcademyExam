using DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserInformationService, UserInformationService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IImagesService, ImagesService>();
            services.AddScoped<IPlaceOfResidenceService, PlaceOfResidenceService>();

            return services;

        }
    }
}
