namespace Movies.DataLayer;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class DatabaseExtensions
{
    public static void InstallDatabase(this IServiceCollection services)
    {
        services.AddDbContext<AppContext>(builder => builder.UseInMemoryDatabase(databaseName: "database_name"));
    }
}