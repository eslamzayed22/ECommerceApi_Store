using ECommerce.Domin.Contracts;
using ECommerce.Persistence.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Extensions
{
    public static class WebAppRegisteration
    {
        public static async Task<WebApplication> MigrateDbAsync(this WebApplication app)
        {
            await using var scope = app.Services.CreateAsyncScope();
            var dbContextService = scope.ServiceProvider.GetRequiredService<StoreDbContext>();

            var pendingMigrations = await dbContextService.Database.GetPendingMigrationsAsync();

            if (pendingMigrations.Any())
                await dbContextService.Database.MigrateAsync();
            return app;    
        }

        public static async Task<WebApplication> SeedDbAsync(this WebApplication app)
        {
            await using var scope = app.Services.CreateAsyncScope();
            var DataInitilizerService = scope.ServiceProvider.GetRequiredService<IDataInitilizer>();
            await DataInitilizerService.InitilizeAsync();
            return app;
        }


    }
}
