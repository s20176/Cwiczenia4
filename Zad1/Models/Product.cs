using System;
using System.ComponentModel.DataAnnotations;

namespace Zad1.Models
{
    public class Product
    {
        public int IdProduct { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }
        
        public string Description { get; set; }
        [Required]
        [Range(0.0, Double.MaxValue)]
        public double Price { get; set; }
    }
}
