using OnlineShopAPI.Models;
using OnlineShopAPI.Models.Dto;

namespace OnlineShopAPI.Repository.IRepostiory
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> UpdateAsync(Product entity);        
     }
}
