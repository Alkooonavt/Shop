using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.Models
{
    public class ProductType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Size { get; set; }

    }
}