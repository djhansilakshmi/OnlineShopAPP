using OnlineShop_Utility;
using OnlineShop_Web.Models;
using OnlineShop_Web.Models.Dto;
using OnlineShop_Web.Services.IServices;

namespace OnlineShop_Web.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string onlineShopUrl;

        public CategoryService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            onlineShopUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");

        }

        public Task<T> CreateAsync<T>(CategoryCreateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = onlineShopUrl + "/api/CategoryAPI",
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = onlineShopUrl + "/api/CategoryAPI/" + id,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = onlineShopUrl + "/api/CategoryAPI",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = onlineShopUrl + "/api/CategoryAPI/" + id,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(CategoryUpdateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = onlineShopUrl + "/api/CategoryAPI/" + dto.Id,
                Token = token
            }) ;
        }
    }
}
