using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.DataAccess.DTO
{
    public class CategoryDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}