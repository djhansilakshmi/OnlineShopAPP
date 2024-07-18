using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop_Web.Models.Dto
{ 
    /// <summary>
  /// This model contains Attribute Details.
  /// </summary>
    public class AttributesCreateDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
