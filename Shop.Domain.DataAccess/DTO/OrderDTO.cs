using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Shop.Domain.Models;

namespace Shop.Domain.DataAccess.DTO
{
    public class OrderDTO
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public IList<OrderItem> Orders { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Display(Name = "Адрес")]
        [Required]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Город")]
        public string City { get; set; }
        [Required]
        [Display(Name = "Полное имя")]
        public string FIO { get; set; }

        [Required]
        [CreditCard]
        public string CreditCard { get; set; }
        [Required]
        public string CardHoldersName { get; set; }
        [Required]
        public string CardExpMonth { get; set; }
        [Required]
        public string Ccv { get; set; }
    }
}