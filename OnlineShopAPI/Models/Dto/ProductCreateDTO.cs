using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopAPI.Models.Dto
{
    public class ProductCreateDTO
    {
       
        [Required]
        public string Name { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Description { get; set; }

        [ForeignKey("category")]
        public int CategoryID { get; set; }
        public string Currency { get; set; }
        public double Amount { get; set; }

        public int InventoryTotal { get; set; }
        public int InventoryAvailable { get; set; }
        public int InventoryReserved { get; set; }

        //[Required]
        public List<AttributesCreateDTO> Attributes { get; set; }
    }
}
