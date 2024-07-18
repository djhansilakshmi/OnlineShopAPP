using System.ComponentModel.DataAnnotations;

namespace OnlineShopAPI.Models.Dto
{
    public class CategoryCreateDTO
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
