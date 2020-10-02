using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public string Alt { get; set; }
    }
}