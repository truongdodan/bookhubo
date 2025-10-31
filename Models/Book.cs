using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookHub.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public int SellerId { get; set; }

        [Required(ErrorMessage = "Tiêu đề sách là bắt buộc")]
        [StringLength(500)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tác giả là bắt buộc")]
        [StringLength(255)]
        public string Author { get; set; } = string.Empty;

        [StringLength(50)]
        public string? ISBN { get; set; }

        [Required(ErrorMessage = "Mô tả là bắt buộc")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Giá là bắt buộc")]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, 999999999, ErrorMessage = "Giá phải lớn hơn 0")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Danh mục là bắt buộc")]
        [StringLength(100)]
        public string Category { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tình trạng là bắt buộc")]
        [StringLength(50)]
        public string Condition { get; set; } = string.Empty;

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn hoặc bằng 0")]
        public int StockQuantity { get; set; } = 1;

        [Required(ErrorMessage = "Hình ảnh là bắt buộc")]
        public string ImagePath { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("SellerId")]
        public virtual User? Seller { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
