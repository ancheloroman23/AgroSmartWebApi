using AgroSmart.Core.Application.Facade;
using AgroSmart.Core.Application.Interfaces.Services;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RealState.Core.Application.Behaviors;
using System.Reflection;


namespace AgroSmart.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


            #region Facade
            //services.AddScoped<FacadeForImages>();
            #endregion

        }
    }
}
