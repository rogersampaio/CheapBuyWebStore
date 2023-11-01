using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheapBuyDB.Models
{
    [Table("Brand")]
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public virtual List<Product>? Products { get; set; }
    }
}
