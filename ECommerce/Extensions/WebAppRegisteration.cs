using ECommerce.Domin.Contracts;
using ECommerce.Persistence.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Extensions
{
    public static class WebAppRegisteration
    {
        public static WebApplication MigrateDb(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContextService = scope.ServiceProvider.GetRequiredService<StoreDbContext>();

            if (dbContextService.Database.GetPendingMigrations().Any())
                dbContextService.Database.Migrate();
            return app;    
        }

        public static WebApplication SeedDb(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var DataInitilizerService = scope.ServiceProvider.GetRequiredService<IDataInitilizer>();
            DataInitilizerService.Initilize();
            return app;
        }


    }
}
