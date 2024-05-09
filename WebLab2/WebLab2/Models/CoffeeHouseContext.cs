using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebLab2.Models
{
    public partial class CoffeeHouseContext: IdentityDbContext<User, Role, int>
    {

        protected readonly IConfiguration Configuration;
        public CoffeeHouseContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderLine> OrderLines { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(d => d.User)
               .WithMany(p => p.Orders)
               .HasForeignKey(d => d.UserId);
                entity.Property(e => e.Date).IsRequired();
            });
            modelBuilder.Entity<OrderLine>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(d => d.Order)
                .WithMany(p => p.OrderLines)
                .HasForeignKey(d => d.OrderId);
                entity.HasOne(d => d.Product).WithMany(p => p.OrderLines).HasForeignKey(d => d.ProductId);
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
            
        }
    }
}
