using OnlineShop_Web.Models.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineShop_Web.Models.VM
{
    public class AttributesCreateVM
    {
        public AttributesCreateVM()
        {
            Attributes = new AttributesCreateDTO();
        }
        public AttributesCreateDTO Attributes { get; set; }
    }
}
