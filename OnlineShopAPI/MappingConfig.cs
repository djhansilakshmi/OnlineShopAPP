using AutoMapper;
using OnlineShopAPI.Models;
using OnlineShopAPI.Models.Dto;

namespace OnlineShopAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap(); 
            CreateMap<Category, CategoryCreateDTO>().ReverseMap();
            CreateMap<Category, CategoryUpdateDTO>().ReverseMap();

            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, ProductCreateDTO>().ReverseMap();
            CreateMap<Product, ProductUpdateDTO>().ReverseMap();

            CreateMap<Attributes, AttributesDTO>().ReverseMap();
            CreateMap<Attributes, AttributesCreateDTO>().ReverseMap();
            CreateMap<Attributes, AttributesUpdateDTO>().ReverseMap();

            CreateMap<ApplicationUser, UserDTO>().ReverseMap();
        }
    }
}
