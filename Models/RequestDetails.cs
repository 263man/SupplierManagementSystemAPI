using System.ComponentModel.DataAnnotations;

namespace SupplierManagementSystem2.Models
{
    public class RequestDetails
    {
        [Key]
        public int RequestDetailID { get; set; }
        public string? RequestNumber { get; set; }
        public string? UserID { get; set; }
        public User? User { get; set; }
        public int SupplierID { get; set; }
        public Supplier? Supplier { get; set; }
        public int RequestSourceID { get; set; }
        public RequestSource? RequestSource { get; set; }
        public DateTime RequestDate { get; set; }
        public string? Status { get; set; }
    }
}