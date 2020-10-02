using System.ComponentModel.DataAnnotations;
using Shop.Domain.Models;

namespace Shop.Domain.DataAccess.DTO
{
    public class OrderItemDTO
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public int ProductId { get; set; }

        public virtual ProductType ChooseType { get; set; }

    }
}