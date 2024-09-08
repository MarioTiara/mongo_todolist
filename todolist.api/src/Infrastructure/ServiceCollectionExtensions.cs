using Core.IRepositories;
using Infrastructure.Database;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoSettings>(configuration.GetSection("MongoSettings"));
        services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<MongoSettings>>().Value);
        services.AddSingleton<MongoDbContext>();  

        services.AddScoped<IUserRepository, UserRepository>();  
        services.AddScoped<IRoleRepository, RoleRepository>();    

    }
}
