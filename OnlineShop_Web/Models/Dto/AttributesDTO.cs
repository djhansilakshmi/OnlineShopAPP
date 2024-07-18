﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop_Web.Models.Dto
{ 
    /// <summary>
  /// This model contains Attribute Details.
  /// </summary>
    public class AttributesDTO
    {       
        public int AttributeId { get; set; }

        //[ForeignKey("product")]
        public int ProductID { get; set; }
        //public Product product { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
