using E_Commerce.Domain.Contract;
using E_Commerce.Domain.Entites;
using E_Commerce.Domain.Entites.ProductModule;
using E_Commerce.Persistence.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.Data.DataSeeding
{
    public class DataIntializer : IDataIntializer
    {
        private readonly StoreDbContext _dbContext;

        public DataIntializer(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Intialize()
        {
            try 
            {
                var HasProduct = _dbContext.Product.Any();
                var HasBrands = _dbContext.ProductBrands.Any();
                var HasTypes = _dbContext.ProductTypes.Any();

                if (HasProduct &&HasTypes &&HasBrands) return;

                if (!HasBrands) 
                {
                    SeedDataFromJson<ProductBrand,int>("brands.json",_dbContext.ProductBrands);
                }
                if (!HasTypes) {
                    SeedDataFromJson<ProductType,int>("types.json", _dbContext.ProductTypes);
                }
                _dbContext.SaveChanges();
                if (!HasProduct) {
                    SeedDataFromJson<Product,int>("products.json", _dbContext.Product);
                }
                _dbContext.SaveChanges();

            }
            catch (Exception ex )
            {
                Console.WriteLine($"data seed is faild{ex}" );
            }
        }

        private void  SeedDataFromJson<T, Tkey>(string FileName,DbSet<T>dbset)where T:BaseEntity<Tkey> 
        {
            //D:\API\Project\E Commerce,Web Solution\E_Commerce.Persistence\Data\DataSeeding\JSONFile\

            var FilePath = @"..\E_Commerce.Persistence\Data\DataSeeding\JSONFile\" + FileName;
            if (!File.Exists(FilePath)) throw new Exception($"{FileName} is not exist");

            try 
            {
               using var datastream = File.OpenRead(FilePath);
               
                var data  = JsonSerializer.Deserialize<List<T>>(datastream,new JsonSerializerOptions()
                { PropertyNameCaseInsensitive=true});

                if(data is not null) dbset.AddRange(data) ;
            } 
            catch(Exception ex) 
            { 
                Console.WriteLine($"error where u reading jsonfile : {ex} ");
                return;
            }
        }
    }
}
