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
        public void Initilize()
        {
            try
            {
                var HasProducts   = _dbContext.Products.Any();
                var HasBrands     = _dbContext.ProductBrands.Any();
                var HasCategories = _dbContext.ProductCategories.Any();

                if (HasProducts && HasBrands && HasCategories) return;
                
                if (!HasBrands)
                    SeedDataFromJson<ProductBrand, int>("brands.json", _dbContext.ProductBrands);
                
                if (!HasCategories)
                    SeedDataFromJson<ProductCategory, int>("categories.json", _dbContext.ProductCategories);

                _dbContext.SaveChanges();

                if (!HasProducts)
                    SeedDataFromJson<Product, int>("products.json", _dbContext.Products);
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Data Seeding Failed : {ex}");
            }
        }

        private void SeedDataFromJson<T, TKey>(string fileName, DbSet<T> dbSet) where T : BaseEntity<TKey>
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
                    dbSet.AddRange(Data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to Read Data From JSON : {ex} !");
            }
        }
    }
}
