using OnlineShopAPI.Models;

namespace OnlineShopAPI.Repository.IRepostiory
{
    public interface IAttributeRepository : IRepository<Attributes>
    {
        Task<Attributes> UpdateAsync(Attributes entity);
    }
}
