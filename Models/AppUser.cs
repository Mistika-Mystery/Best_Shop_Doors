using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Best_Shop_Doors.Models
{
    public class AppUser:IdentityUser
    {
        
        public string? Name { get; set; }
        public string? Lastname { get; set; }
       
  
    }
}
