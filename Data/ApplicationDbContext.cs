using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SupplierManagementSystem2.Models;

namespace SupplierManagementSystem2.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Supplier> Suppliers { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Stock> Stocks { get; set; } = null!;
        public DbSet<RequestSource> RequestSources { get; set; } = null!;
        public DbSet<RequestDetails> RequestDetails { get; set; } = null!;
        public DbSet<StockRequests> StockRequests { get; set; } = null!;
        public DbSet<EmailNotifications> EmailNotifications { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Call the base method for Identity configurations

            // Configure relationships and keys here
            modelBuilder.Entity<Stock>()
                .Property(s => s.UnitPrice)
                .HasPrecision(10, 2); // Precision of 10 digits with 2 decimal places

            modelBuilder.Entity<Stock>()
                .HasOne(s => s.Supplier)
                .WithMany()
                .HasForeignKey(s => s.SupplierID);

            modelBuilder.Entity<RequestDetails>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserID);

            modelBuilder.Entity<RequestDetails>()
                .HasOne(r => r.Supplier)
                .WithMany()
                .HasForeignKey(r => r.SupplierID);

            modelBuilder.Entity<RequestDetails>()
                .HasOne(r => r.RequestSource)
                .WithMany()
                .HasForeignKey(r => r.RequestSourceID);

            modelBuilder.Entity<StockRequests>()
                .HasOne(s => s.RequestDetails)
                .WithMany()
                .HasForeignKey(s => s.RequestDetailID);

            modelBuilder.Entity<StockRequests>()
                .HasOne(sr => sr.Stock)
                .WithMany()
                .HasForeignKey(sr => sr.StockID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EmailNotifications>()
                .HasOne(e => e.RequestDetails)
                .WithMany()
                .HasForeignKey(e => e.RequestDetailID);
        }
    }
}