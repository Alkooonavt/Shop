using System.ComponentModel.DataAnnotations;
using Shop.Domain.Models;
namespace Shop.Domain.DataAccess.DTO
{
    public class PhotoDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public string Alt { get; set; }
    }
}