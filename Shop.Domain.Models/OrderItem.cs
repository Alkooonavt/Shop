using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.Models
{
    public class OrderItem
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
        public string UserId { get; set; }


    }
}