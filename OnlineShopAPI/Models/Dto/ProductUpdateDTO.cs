using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopAPI.Models.Dto
{
    public class ProductUpdateDTO
    {
        public int ProductId { get; set; }
        //[Required]
        public string Name { get; set; }
        //[Required]
        public string Brand { get; set; }
        //[Required]
        public string Description { get; set; }

        [ForeignKey("category")]
        public int CategoryID { get; set; }
       
        //public Category category { get; set; }
        public string Currency { get; set; }
        public double Amount { get; set; }

        public int InventoryTotal { get; set; }
        public int InventoryAvailable { get; set; }
        public int InventoryReserved { get; set; }        
        public List<AttributesUpdateDTO>? Attributes { get; set; }
    }
}
