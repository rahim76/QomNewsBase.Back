using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using QomNewsBase.Application.Behaviors;
using QomNewsBase.Application.Profiles;

namespace QomNewsBase.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssemblies(assembly));

        services.AddValidatorsFromAssembly(assembly);
        //services.AddFluentValidationAutoValidation();

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddAutoMapper(typeof(AutoMapperProfile));

        return services;
    }
}