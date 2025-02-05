using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SupplierManagementSystem2.Models
{
    
        public class User: IdentityUser
        {
            [Key]
            public int UserID { get; set; }
            public required string MyUsername { get; set; } //The AspNetUsers table, which is part of the Identity system, already has a column named UserName (inherited from IdentityUser)
        public required string Role { get; set; }
            public DateTime DateCreated { get; set; }
        }
    
}
