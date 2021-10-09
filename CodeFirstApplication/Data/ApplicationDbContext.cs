using CodeFirstApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CategoryModel> Categories { set; get; }
        public DbSet<ProductModel> Products { set; get; }

        public ApplicationDbContext() {  }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Data Source=(localdb)\\LAPTOP-VBJJ1N26;Initial Catalog=CodeFirstBooks;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                optionsBuilder.UseSqlServer("server=LAPTOP-VBJJ1N26;database=CodeFirstBooks;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryModel>().HasData(
                new CategoryModel() { IdCategory = 1, NameCategory = "Smartphone" },
                new CategoryModel() { IdCategory = 2, NameCategory = "Consoles" },
                new CategoryModel() { IdCategory = 3, NameCategory = "Laptops" });
        }

    }
}
