using Library.Infastructure.Interfaces;
using Library.Infastructure.Repositories;
using Library.Services.Services.Token;
using Library.Services.Services.User;
using Library.Web.HandleResponse;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Extensions
{
    public static class AppServiceExtensions
    {
        public static IServiceCollection AddAplicationService(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                                .Where(model => model.Value?.Errors.Count > 0)
                                .SelectMany(model => model.Value?.Errors)
                                .Select(error => error.ErrorMessage)
                                .ToList();

                    var errorResponse = new ValidationErrorResponse
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });
            return services;
        }
    }
}
