namespace Recommendations.DataLayer;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class DatabaseExtensions
{
    public static void InstallDatabase(this IServiceCollection service)
    {
        service.AddDbContext<AppContext>(builder => builder.UseInMemoryDatabase(databaseName: "database_name"));
    }
}