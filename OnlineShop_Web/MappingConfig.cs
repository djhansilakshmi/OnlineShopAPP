using AutoMapper;
using OnlineShop_Web.Models;
using OnlineShop_Web.Models.Dto;

namespace OnlineShop_Web
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
           
            CreateMap<CategoryDTO, CategoryCreateDTO>().ReverseMap();
            CreateMap<CategoryDTO, CategoryUpdateDTO>().ReverseMap();

          
            CreateMap<ProductDTO, ProductCreateDTO>().ReverseMap();
            CreateMap<ProductDTO, ProductUpdateDTO>().ReverseMap();
            
            CreateMap<AttributesDTO, AttributesCreateDTO>().ReverseMap();
            CreateMap<AttributesDTO, AttributesUpdateDTO>().ReverseMap();

            //CreateMap<VillaNumber, VillaNumberDTO>().ReverseMap();
            //CreateMap<VillaNumber, VillaNumberCreateDTO>().ReverseMap();
            //CreateMap<VillaNumber, VillaNumberUpdateDTO>().ReverseMap();
            //CreateMap<ApplicationUser, UserDTO>().ReverseMap();
        }
    }
}
