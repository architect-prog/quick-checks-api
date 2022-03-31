using Microsoft.EntityFrameworkCore;
using Npgsql;
using QuickChecks.Kernel.Entities.Enum;

namespace QuickChecks.Persistence.EntityTypeConfigurations;

public static class EntityEnumConfiguration
{
    public static void MapEnums()
    {
        NpgsqlConnection.GlobalTypeMapper.MapEnum<PollStatus>();
        NpgsqlConnection.GlobalTypeMapper.MapEnum<QuestionType>();
    }

    public static void RegisterEnums(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<PollStatus>();
        modelBuilder.HasPostgresEnum<QuestionType>();
    }
}