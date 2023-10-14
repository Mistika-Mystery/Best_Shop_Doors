using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Best_Shop_Doors.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Best_Shop_Doors.Data
{
    public class Best_Shop_DoorsContext : IdentityDbContext
    {
        public Best_Shop_DoorsContext (DbContextOptions<Best_Shop_DoorsContext> options)
            : base(options)
        {
        }

        public DbSet<Best_Shop_Doors.Models.Color> Color { get; set; } = default!;

        public DbSet<Best_Shop_Doors.Models.Door>? Door { get; set; }

        public DbSet<Best_Shop_Doors.Models.Material>? Material { get; set; }

        public DbSet<Best_Shop_Doors.Models.Proizvoditel>? Proizvoditel { get; set; }

        public DbSet<Best_Shop_Doors.Models.Tip>? Tip { get; set; }

        public DbSet<Best_Shop_Doors.Models.OZakaze>? OZakaze { get; set; }

        public DbSet<Best_Shop_Doors.Models.Zakaz>? Zakaz { get; set; }
        public DbSet<Best_Shop_Doors.Models.AppUser> AppUsers { get; set; }
    }
}
