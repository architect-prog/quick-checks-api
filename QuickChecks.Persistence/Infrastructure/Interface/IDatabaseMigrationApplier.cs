namespace QuickChecks.Persistence.Infrastructure.Interface;

public interface IDatabaseMigrationApplier
{
    void ApplyMigrations();
}