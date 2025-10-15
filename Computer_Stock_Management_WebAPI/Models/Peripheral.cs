using System.ComponentModel.DataAnnotations;

namespace Computer_Stock_Management_WebAPI.Models
{
    public class Peripheral
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; } // e.g., Keyboard, Mouse, Monitor

        [Range(0, int.MaxValue)]
        public int QuantityInStock { get; set; }

        [Range(0.0, 1_000_000.0)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        public DateTime AddedDate { get; set; } = DateTime.UtcNow;
    }
}
