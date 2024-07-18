using OnlineShop_Utility;
using OnlineShop_Web.Models;
using OnlineShop_Web.Models.Dto;
using OnlineShop_Web.Services.IServices;
using Newtonsoft.Json.Linq;

namespace OnlineShop_Web.Services
{
    public class AttributesService : BaseService, IAttributesService
	{
        private readonly IHttpClientFactory _clientFactory;
        private string onlineShopUrl;

        public AttributesService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            onlineShopUrl = configuration.GetValue<string>("ServiceUrls:OnlineShopAPI");

        }

        public Task<T> CreateAsync<T>(AttributesCreateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = onlineShopUrl + "/api/AttributesAPI",
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = onlineShopUrl + "/api/AttributesAPI/" + id,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(int productId, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = onlineShopUrl + "/api/AttributesAPI?productId=" + productId,
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = onlineShopUrl + "/api/AttributesAPI/" + id,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(AttributesUpdateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = onlineShopUrl + "/api/ProductAPI/" + dto.AttributeId,
                Token = token
            }) ;
        }
    }
}
