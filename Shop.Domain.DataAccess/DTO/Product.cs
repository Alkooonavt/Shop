using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using Shop.Domain.Models;

namespace Shop.Domain.DataAccess.DTO
{
    public class ProductDTO
    {
        [Key]
        public int Id { get; set; }
        public Category Category { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        [MaxLength(400)]
        [Required]
        public string Description { get; set; }
        public double Price { get; set; }
        public virtual IList<Photo> Photos { get; set; }

        public virtual IList<ProductType> ProductTypes { get; set; }
        public virtual IList<Comment> Comments { get; set; }
        public int Count { get; set; }
    }
}