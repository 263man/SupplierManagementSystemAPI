using System.ComponentModel.DataAnnotations;

namespace SupplierManagementSystem2.Models
{
    public class EmailNotifications
    {
        [Key]
        public int EmailID { get; set; }
        public int RequestDetailID { get; set; }
        public RequestDetails? RequestDetails { get; set; }
        public string? Status { get; set; }
        public DateTime EmailSentDate { get; set; }
        public string? RecipientEmail { get; set; }
    }
}