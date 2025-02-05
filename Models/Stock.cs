using System.ComponentModel.DataAnnotations;

namespace SupplierManagementSystem2.Models
{
    public class Stock
    {
        [Key]
        public int StockID { get; set; }
        public int SupplierID { get; set; }
        public Supplier? Supplier { get; set; } // Navigation property
        public string? ItemName { get; set; }
        public int CategoryID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime DateAdded { get; set; }
    }
}