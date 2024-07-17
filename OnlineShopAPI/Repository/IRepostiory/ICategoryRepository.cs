using OnlineShopAPI.Models;

namespace OnlineShopAPI.Repository.IRepostiory
{
    public interface ICategoryRepository : IRepository<Category>
    {

        Task<Category> UpdateAsync(Category entity);
    }
}
