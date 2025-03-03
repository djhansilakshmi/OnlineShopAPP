﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopAPI.Models
{
    /// <summary>
    /// This model contains Product Details.
    /// </summary>
    public class Product
    {        

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public  string Description { get; set; }

        [ForeignKey("category")]
        public int CategoryID { get; set; }
        // Check if this is needed or not 
        public Category category { get; set; }
        public string Currency { get; set; }
        public double Amount { get; set; }       

        public int InventoryTotal { get; set; }
        public int InventoryAvailable { get; set; }
        public int InventoryReserved { get; set; }

        //[Required]
        public List<Attributes> Attributes { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }

    


}
