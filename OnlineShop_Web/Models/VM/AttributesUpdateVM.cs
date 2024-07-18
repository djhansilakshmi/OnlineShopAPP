using OnlineShop_Web.Models.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineShop_Web.Models.VM
{
    public class AttributesUpdateVM
    {
        public AttributesUpdateVM()
        {
            Attributes = new AttributesUpdateDTO();
        }
        public AttributesUpdateDTO Attributes { get; set; }
    }
}
