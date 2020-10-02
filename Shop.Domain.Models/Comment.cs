using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Domain.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreationPost { get; set; }=DateTime.Now;
        public string Name { get; set; }

        public string Body { get; set; }
    }
}