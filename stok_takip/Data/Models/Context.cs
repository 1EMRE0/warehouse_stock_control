using Microsoft.EntityFrameworkCore;
using System;


namespace stok_takip.Data.Models
{
    public class Context: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost; database=DbCoreFood; integrated security=true; Encrypt=True; TrustServerCertificate=true");

        }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Admin> Admins { get; set; }
    }
}
