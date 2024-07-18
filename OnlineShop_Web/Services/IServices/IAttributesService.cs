using OnlineShop_Web.Models.Dto;

namespace OnlineShop_Web.Services.IServices
{
    public interface IAttributesService
    {
        Task<T> GetAllAsync<T>(int productId, string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(AttributesCreateDTO dto, string token);
        Task<T> UpdateAsync<T>(AttributesUpdateDTO dto, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}
