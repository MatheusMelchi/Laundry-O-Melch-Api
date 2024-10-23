using Laundry_O_Melch_Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace Laundry_O_Melch_Api
{
    public partial class LaundryOMelchDBContext : DbContext
    {
        public LaundryOMelchDBContext(DbContextOptions <LaundryOMelchDBContext> options) : base(options)
        {

        }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity => {
                entity.HasKey(x => x.Id);
            });

            modelBuilder.Entity<Pedido>(entity => {
                entity.HasKey(x => x.Id);

                entity.HasOne(x => x.Cliente)
                      .WithMany()
                      .HasForeignKey(x => x.ClienteId)
                      .IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
