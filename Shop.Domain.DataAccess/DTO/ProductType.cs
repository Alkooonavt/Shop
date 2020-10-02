using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.DataAccess.DTO
{
    public class ProductTypeDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Size { get; set; }
    }
}