using InvoiceApp.Commons.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApp.Server.DbContexts
{
    internal class InvoiceContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<MeasureUnit> MeasureUnits { get; set; }

        public InvoiceContext(DbContextOptions<InvoiceContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(x => x.AddressId);
                entity.Property(x => x.City)
                .IsRequired();
                entity.Property(x => x.Country)
                .IsRequired();
                entity.Property(x => x.Street)
                .IsRequired();
                entity.Property(x => x.Number)
                .IsRequired();
                entity.Property(x => x.FlatNumber)
                .IsRequired();
                entity.Property(x => x.PostCode)
                .IsRequired();
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.HasKey(_ => _.TypeId);
                entity.Property(_ => _.TypeId)
                .IsRequired();
                entity.Property(_ => _.Name)
                .IsRequired();
                entity.Property(_ => _.Shortcut)
                .IsRequired();
            });

            modelBuilder.Entity<MeasureUnit>(entity =>
            {
                entity.HasKey(_ => _.MeasureUnitId);
                entity.Property(_ => _.Name)
                .IsRequired();
                entity.Property(_ => _.Shortcut)
                .IsRequired();
            });
        }
    }
}
