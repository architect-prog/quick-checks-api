using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using QuickChecks.Persistence.Infrastructure.Interface;

namespace QuickChecks.Api.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var migrationApplier = scope.ServiceProvider.GetRequiredService<IDatabaseMigrationApplier>();
            migrationApplier.ApplyMigrations();
        }
    }
}