using OnlineShop_Web.Models.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineShop_Web.Models.VM
{
    public class AttributesDeleteVM
    {
        public AttributesDeleteVM()
        {
            attribute = new AttributesDTO();
        }
        public AttributesDTO attribute { get; set; }
    }
}
