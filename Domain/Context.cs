using Microsoft.EntityFrameworkCore;

namespace DeleteActionOnEntityFramework.Domain;

public class Context: DbContext
{
    public Context()
    {
    }

    public Context(DbContextOptions<Context> options) : base(options)
    {
    }
    
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Cascade delete: When a Customer is deleted, all related Orders are also deleted.
        // modelBuilder.Entity<Order>()
        //     .HasOne(o => o.Customer)
        //     .WithMany(c => c.Orders)
        //     .HasForeignKey(o => o.CustomerId)
        //     .OnDelete(DeleteBehavior.Cascade);
        

        // Client Cascade delete: Similar to Cascade, but the cascade delete is handled by the client (EF Core) rather than the database.
        // modelBuilder.Entity<Order>()
        //     .HasOne(o => o.Customer)
        //     .WithMany(c => c.Orders)
        //     .HasForeignKey(o => o.CustomerId)
        //     .OnDelete(DeleteBehavior.ClientCascade);
        
        // Set Null: When a Customer is deleted, the CustomerId in related Orders is set to null.
        // modelBuilder.Entity<Order>()
        //     .HasOne(o => o.Customer)
        //     .WithMany(c => c.Orders)
        //     .HasForeignKey(o => o.CustomerId)
        //     .OnDelete(DeleteBehavior.SetNull);
        
        // Set Null: When a Customer is deleted, the CustomerId in related Orders is set to null.
        // modelBuilder.Entity<Order>()
        //     .HasOne(o => o.Customer)
        //     .WithMany(c => c.Orders)
        //     .HasForeignKey(o => o.CustomerId)
        //     .OnDelete(DeleteBehavior.ClientSetNull);
        
        // No Action: Prevents the deletion of a Customer if there are related Orders.
         // This requires manual handling of the relationship before deletion.
         // If you try to delete a Customer with related Orders, it will throw an exception.
         // Uncomment the following lines to use NoAction behavior.
        // modelBuilder.Entity<Order>()
        //     .HasOne(o => o.Customer)
        //     .WithMany(c => c.Orders)
        //     .HasForeignKey(o => o.CustomerId)
        //     .OnDelete(DeleteBehavior.NoAction);
        
        // Client No Action: Similar to NoAction, but the check is performed by the client (EF Core) rather than the database.
        // modelBuilder.Entity<Order>()
        //     .HasOne(o => o.Customer)
        //     .WithMany(c => c.Orders)
        //     .HasForeignKey(o => o.CustomerId)
        //     .OnDelete(DeleteBehavior.ClientNoAction);
        
        // Restrict: Prevents the deletion of a Customer if there are related Orders.
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}