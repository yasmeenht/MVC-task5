using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using sql_task5_code_first_.Models;

namespace sql_task5_code_first_.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<PurchaseOrders> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItems> PurchaseOrderItems { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // ONE category has MANY products.
            builder.Entity<Products>()
                .HasOne(product => product.Category)
                .WithMany(category => category.Products)
                .HasForeignKey(product => product.CategoryID);

            // ONE supplier has MANY products.
            builder.Entity<Products>()
                .HasOne(product => product.Supplier)
                .WithMany(supplier => supplier.Products)
                .HasForeignKey(product => product.SupplierID);

            // ONE supplier has MANY purchase orders.
            builder.Entity<PurchaseOrders>()
                .HasOne(order => order.supplier)
                .WithMany(supplier => supplier.PurchaseOrders)
                .HasForeignKey(order => order.SupplierID);

            // ONE purchase order has MANY purchase order items.
            builder.Entity<PurchaseOrderItems>()
                .HasOne(item => item.PurchaseOrder)
                .WithMany(order => order.PurchaseOrderItems)
                .HasForeignKey(item => item.PurchaseOrderID);

            // ONE product appears in MANY purchase order items.
            builder.Entity<PurchaseOrderItems>()
                .HasOne(item => item.Product)
                .WithMany(product => product.PurchaseOrderItems)
                .HasForeignKey(item => item.ProductID)
                .OnDelete(DeleteBehavior.NoAction);

            // Store prices with two decimal places.
            builder.Entity<Products>()
                .Property(product => product.Price)
                .HasPrecision(18, 2);

            builder.Entity<PurchaseOrderItems>()
                .Property(item => item.UnitPrice)
                .HasPrecision(18, 2);
        }


    }

}
