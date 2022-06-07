using System;
using System.ComponentModel.DataAnnotations;

namespace Zad1.Models
{
    public class ProductWarehouse
    {
        [Required]
        public int IdProduct { get; set; }
        [Required]
        public int IdWarehouse { get; set; }
        [Required]
        [Range(0.0, Int32.MaxValue)]
        public int Amount { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
