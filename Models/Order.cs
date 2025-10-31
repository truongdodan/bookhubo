using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookHub.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public int BuyerId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        [Required]
        public string ShippingAddress { get; set; } = string.Empty;

        [StringLength(50)]
        public string Status { get; set; } = "Pending";

        public DateTime OrderDate { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("BuyerId")]
        public virtual User? Buyer { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
