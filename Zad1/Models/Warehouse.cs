using System.ComponentModel.DataAnnotations;

namespace Zad1.Models
{
    public class Warehouse
    {
        public int IdWarehouse { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Address { get; set; }
    }
}
