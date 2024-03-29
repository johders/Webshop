using Microsoft.EntityFrameworkCore;
using PE1.Webshop.Core;

namespace PE1.Webshop.Web.Data
{
    public class CoffeeShopContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Coffee> Coffees { get; set; }

        public CoffeeShopContext(DbContextOptions<CoffeeShopContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Coffee>()
                .HasOne(c => c.Category)
                .WithMany(cat => cat.Coffees)
                .OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(modelBuilder);
        }
    }
}
