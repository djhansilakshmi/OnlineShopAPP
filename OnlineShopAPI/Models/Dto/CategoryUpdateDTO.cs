using System.ComponentModel.DataAnnotations;

namespace OnlineShopAPI.Models.Dto
{
    public class CategoryUpdateDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
