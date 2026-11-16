using lab13huamanialex_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace lab13huamanialex_api.Infrastructure.Persistence;

public sealed class LinQExampleDbContext(DbContextOptions<LinQExampleDbContext> options) : DbContext(options)
{
    public DbSet<Cliente> Clients => Set<Cliente>();
    public DbSet<Producto> Products => Set<Producto>();
    public DbSet<Pedido> Orders => Set<Pedido>();
    public DbSet<DetallePedido> OrderDetails => Set<DetallePedido>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("Clients");
            entity.HasKey(x => x.ClientId);
            entity.Property(x => x.Name).HasMaxLength(100).IsRequired();
            entity.Property(x => x.Email).HasMaxLength(100).IsRequired();
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.ToTable("Products");
            entity.HasKey(x => x.ProductId);
            entity.Property(x => x.Name).HasMaxLength(100).IsRequired();
            entity.Property(x => x.Description).HasMaxLength(100);
            entity.Property(x => x.Price).HasPrecision(10, 2);
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.ToTable("Orders");
            entity.HasKey(x => x.OrderId);
            entity.Property(x => x.OrderDate).HasColumnType("datetime");
            entity.HasOne(x => x.Client).WithMany(x => x.Orders)
                .HasForeignKey(x => x.ClientId);
        });

        modelBuilder.Entity<DetallePedido>(entity =>
        {
            entity.ToTable("OrderDetails");
            entity.HasKey(x => x.OrderDetailId);
            entity.HasOne(x => x.Order).WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.OrderId);
            entity.HasOne(x => x.Product).WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.ProductId);
        });
    }
}
