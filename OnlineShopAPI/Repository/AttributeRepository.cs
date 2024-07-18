using OnlineShopAPI.Data;
using OnlineShopAPI.Models;
using OnlineShopAPI.Repository.IRepostiory;

namespace OnlineShopAPI.Repository
{
    public class AttributeRepository : Repository<Attributes>, IAttributeRepository
    {
        private readonly ApplicationDbContext _db;
        public AttributeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Attributes> UpdateAsync(Attributes entity)
        {
            _db.attributes.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
