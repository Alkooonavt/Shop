using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
namespace Shop.Domain.Models
{
    public class ShopingCartItem
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