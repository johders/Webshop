using Microsoft.EntityFrameworkCore;
using PE1.Webshop.Core;

namespace PE1.Webshop.Web.Data
{
    public class CoffeeShopContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Coffee> Coffees { get; set; }
        //public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
		public DbSet<VolunteerApplication> VolunteerApplications { get; set; }
		//public DbSet<Order> Orders { get; set; }

        public DbSet<WebOrder> WebOrders { get; set; }

		public CoffeeShopContext(DbContextOptions<CoffeeShopContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coffee>()
                .HasOne(c => c.Category)
                .WithMany(cat => cat.Coffees)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Coffee>()
                .Property(c => c.Price)
                .HasColumnType("decimal")
                .HasPrecision(6, 2);

            modelBuilder.Entity<WebOrderCoffee>()
                .ToTable("WebOrderCoffee")
                .HasKey(pt => new { pt.WebOrderId, pt.CoffeeId });

            modelBuilder.Entity<WebOrderCoffee>()
                .HasOne(pt => pt.WebOrder)
                .WithMany(t => t.WebOrderCoffees)
                .HasForeignKey(pt => pt.WebOrderId);

            modelBuilder.Entity<WebOrderCoffee>()
                .HasOne(pt => pt.Coffee)
                .WithMany(t => t.WebOrderCoffees)
                .HasForeignKey(pt => pt.CoffeeId);

            DataSeeder.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
