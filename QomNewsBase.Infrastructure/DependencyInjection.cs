using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QomNewsBase.Application.Interfaces;
using QomNewsBase.Application.Utilities;
using QomNewsBase.Infrastructure.Contexts;
using QomNewsBase.Infrastructure.Repositories;
using QomNewsBase.Infrastructure.Services;

namespace QomNewsBase.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("QomNewsBaseConnection");

        services.AddDbContext<QomNewsBaseContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        services.AddScoped<INewsRepository, NewsRepository>();
        services.AddScoped<IFileStorageService, FileSystemStorageService>();
        services.AddScoped<INewsGroupRepository, NewsGroupRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();

        return services;
    }
}