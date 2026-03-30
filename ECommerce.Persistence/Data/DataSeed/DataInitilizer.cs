using ECommerce.Domin.Contracts;
using ECommerce.Domin.Entities;
using ECommerce.Domin.Entities.ProductModule;
using ECommerce.Persistence.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Data.DataSeed
{
    public class DataInitilizer : IDataInitilizer
    {
        private readonly StoreDbContext _dbContext;

        public DataInitilizer(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task InitilizeAsync()
        {
            try
            {
                var HasProducts   = await _dbContext.Products.AnyAsync();
                var HasBrands     = await _dbContext.ProductBrands.AnyAsync();
                var HasCategories = await _dbContext.ProductCategories.AnyAsync();

                if (HasProducts && HasBrands && HasCategories) return;
                
                if (!HasBrands)
                   await SeedDataFromJsonAsync<ProductBrand, int>("brands.json", _dbContext.ProductBrands);
                
                if (!HasCategories)
                   await SeedDataFromJsonAsync<ProductCategory, int>("categories.json", _dbContext.ProductCategories);

                _dbContext.SaveChanges();

                if (!HasProducts)
                   await SeedDataFromJsonAsync<Product, int>("products.json", _dbContext.Products);
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Data Seeding Failed : {ex}");
            }
        }

        private async Task SeedDataFromJsonAsync<T, TKey>(string fileName, DbSet<T> dbSet) where T : BaseEntity<TKey>
        {
            var filePath = @"..\ECommerce.Persistence\Data\DataSeed\JSONFiles\" + fileName;

            if (!File.Exists(filePath)) throw new FileNotFoundException($"File {fileName} Not Found !");

            try
            {
                using var DataStream = File.OpenRead(filePath);
                var Data = JsonSerializer.Deserialize<List<T>>(DataStream, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });

                if (Data is not null )
                {
                   await dbSet.AddRangeAsync(Data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to Read Data From JSON : {ex} !");
            }
        }
    }
}
