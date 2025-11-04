using E_Commerce.Domain.Contract;
using E_Commerce.Persistence.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace E_Commerce_Web.Extensions
{
    public static class WebApplicationRegisterantion
    {
        public static WebApplication MigrateDatabase(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var DbContextServes = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
            if (DbContextServes.Database.GetPendingMigrations().Any())
                DbContextServes.Database.Migrate();

            return app;
        }

        public static WebApplication SeedDatabase(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var DataIntializerserves = scope.ServiceProvider.GetRequiredService<IDataIntializer>();
            DataIntializerserves.Intialize();
            return app;
        }
    }
}
