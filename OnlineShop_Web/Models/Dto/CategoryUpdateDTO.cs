using System.ComponentModel.DataAnnotations;

namespace OnlineShop_Web.Models.Dto
{
    public class CategoryUpdateDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
