using OnlineShopAPI.Data;
using OnlineShopAPI.Models;
using OnlineShopAPI.Repository.IRepostiory;

namespace OnlineShopAPI.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Category> UpdateAsync(Category entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.categories.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
