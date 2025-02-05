using System.ComponentModel.DataAnnotations;

namespace SupplierManagementSystem2.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }
        public string? Name { get; set; }
        public int CityID { get; set; }
        public string? Status { get; set; }
    }
}
