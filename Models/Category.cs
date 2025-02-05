using System.ComponentModel.DataAnnotations;

namespace SupplierManagementSystem2.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public DateTime DateAdded { get; set; }
    }
}