using Microsoft.EntityFrameworkCore;
using Npgsql;
using QuickChecks.Persistence.Infrastructure.Interface;
using System;

namespace QuickChecks.Persistence.Infrastructure;

public class DatabaseMigrationApplier : IDatabaseMigrationApplier
{
    private readonly DbContext context;

    public DatabaseMigrationApplier(DbContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void ApplyMigrations()
    {
        context.Database.Migrate();

        //NOTE: If you are using context.Database.Migrate() to create your enums,
        //you need to instruct Npgsql to reload all types after applying your migrations:
        //https://www.npgsql.org/efcore/mapping/enum.html?tabs=tabid-1
        using (var connection = (NpgsqlConnection)context.Database.GetDbConnection())
        {
            connection.Open();
            connection.ReloadTypes();
        }
    }
}