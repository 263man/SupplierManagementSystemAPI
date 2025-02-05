using System.ComponentModel.DataAnnotations;

namespace SupplierManagementSystem2.Models
{
    public class StockRequests
    {
        [Key]
        public int StockRequestID { get; set; }
        public int RequestDetailID { get; set; }
        public RequestDetails? RequestDetails { get; set; }
        public int StockID { get; set; }
        public Stock? Stock { get; set; }
        public int QuantityRequested { get; set; }
        public int? QuantityApproved { get; set; }
        public string? Status { get; set; }
    }
}