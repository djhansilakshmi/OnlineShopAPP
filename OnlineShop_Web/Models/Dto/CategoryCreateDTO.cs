using System.ComponentModel.DataAnnotations;

namespace OnlineShop_Web.Models.Dto
{
    public class CategoryCreateDTO
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
