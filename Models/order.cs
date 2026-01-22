using System.ComponentModel.DataAnnotations;

namespace KarimaCollection.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string CustomerName { get; set; }

        [Required, StringLength(150)]
        public string CustomerEmail { get; set; }

        [StringLength(250)]
        public string ShippingAddress { get; set; }

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        public decimal TotalAmount { get; set; } 
    }
}
