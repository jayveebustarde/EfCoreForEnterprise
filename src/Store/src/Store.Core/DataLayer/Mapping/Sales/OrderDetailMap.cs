using System.Composition;
using Microsoft.EntityFrameworkCore;
using Store.Core.EntityLayer.Sales;

namespace Store.Core.DataLayer.Mapping.Sales
{
    [Export(typeof(IEntityMap))]
    public class OrderDetailMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>(entity =>
            {

                
                
                
                
                

                // Mapping for table
                entity.ToTable("OrderDetail", "Sales");

                // Set key for entity
                entity.HasKey(p => p.OrderDetailID);

                // Set identity for entity (auto increment)
                entity.Property(p => p.OrderDetailID).UseSqlServerIdentityColumn();

                // Set mapping for columns
                entity.Property(p => p.OrderID).HasColumnType("int").IsRequired();
                entity.Property(p => p.ProductID).HasColumnType("int").IsRequired();
                entity.Property(p => p.ProductName).HasColumnType("varchar(255)").IsRequired();
                entity.Property(p => p.UnitPrice).HasColumnType("decimal(8, 4)").IsRequired();
                entity.Property(p => p.Quantity).HasColumnType("int").IsRequired();
                entity.Property(p => p.Total).HasColumnType("decimal(8, 4)").IsRequired();
                entity.Property(p => p.CreationUser).HasColumnType("varchar(25)").IsRequired();
                entity.Property(p => p.CreationDateTime).HasColumnType("datetime").IsRequired();
                entity.Property(p => p.LastUpdateUser).HasColumnType("varchar(25)");
                entity.Property(p => p.LastUpdateDateTime).HasColumnType("datetime");

                // Set concurrency token for entity
                entity.Property(p => p.Timestamp).ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();

                // Add configuration for foreign keys
                entity
                    .HasOne(p => p.OrderFk)
                    .WithMany(b => b.OrderDetails)
                    .HasForeignKey(p => p.OrderID);

                entity
                    .HasOne(p => p.ProductFk)
                    .WithMany(b => b.OrderDetails)
                    .HasForeignKey(p => p.ProductID);
            });
        }
    }
}
