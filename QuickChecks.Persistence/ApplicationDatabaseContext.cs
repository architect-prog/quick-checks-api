using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using QuickChecks.Kernel.Entities;
using QuickChecks.Persistence.EntityTypeConfigurations;
using QuickChecks.Persistence.Settings;
using System.Reflection;

namespace QuickChecks.Persistence;

public sealed class ApplicationDatabaseContext : DbContext
{
    private readonly DatabaseSettings settings;

    private DbSet<PollTemplateEntity> PollTemplates { get; set; }

    public ApplicationDatabaseContext(IOptions<DatabaseSettings> settings)
    {
        this.settings = settings.Value;

        ChangeTracker.LazyLoadingEnabled = false;
        ChangeTracker.AutoDetectChangesEnabled = false;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        EntityEnumConfiguration.MapEnums();

        optionsBuilder
            .UseNpgsql(settings.ConnectionString)
            .UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        EntityEnumConfiguration.RegisterEnums(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
