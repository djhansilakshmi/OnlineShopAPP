using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopAPI.Models
{ 
    /// <summary>
  /// This model contains Attribute Details.
  /// </summary>
    public class Attributes
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttributeId { get; set; }

        [ForeignKey("product")]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
