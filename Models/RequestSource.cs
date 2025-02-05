using System.ComponentModel.DataAnnotations;

namespace SupplierManagementSystem2.Models
{
    public class RequestSource
    {
        [Key]
        public int RequestSourceID { get; set; }
        public string? SourceName { get; set; }
        public string? UniqueCode { get; set; }
        public string? ContactPerson { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactPhone { get; set; }
        public string? CompanyName { get; set; }
        public string? Address { get; set; }
        public DateTime DateAdded { get; set; }
    }
}