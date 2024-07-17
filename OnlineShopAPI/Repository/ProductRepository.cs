using Microsoft.EntityFrameworkCore;
using OnlineShopAPI.Data;
using OnlineShopAPI.Models;
using OnlineShopAPI.Models.Dto;
using OnlineShopAPI.Repository.IRepostiory;

namespace OnlineShopAPI.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Product> UpdateAsync(Product entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.products.Update(entity);      
            await _db.SaveChangesAsync();
            return entity;
        }       
    }
}
