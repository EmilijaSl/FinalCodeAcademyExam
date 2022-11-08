using DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
