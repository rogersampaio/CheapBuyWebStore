using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheapBuyDB.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public required string Id { get; set; }
        public required string Name { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public required decimal Price { get; set; }

        public int BrandId { get; set; }
        public virtual Brand? Brand { get; set; }
    }
}
