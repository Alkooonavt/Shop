using System.ComponentModel.DataAnnotations;

namespace Shop.App.Models
{
    public class OrderViewModel
    {
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