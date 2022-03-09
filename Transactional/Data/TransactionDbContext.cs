using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Transactional.Models;

#nullable disable

namespace Transactional.Data
{
    public partial class TransactionDbContext : DbContext
    {
        public TransactionDbContext()
        {
        }

        public TransactionDbContext(DbContextOptions<TransactionDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
              optionsBuilder.UseSqlServer("Data Source=(local)\\SQLEXPRESS;Initial Catalog=MoneyTransactionDB;Integrated Security=True ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.IdNo).IsUnicode(false);

                entity.Property(e => e.TransactionType).IsUnicode(false);

                entity.HasOne(d => d.IdNoNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.IdNo)
                    .HasConstraintName("FK__transacti__id_no__29572725");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdNo)
                    .HasName("PK__user___0148B384636632D8");

                entity.Property(e => e.IdNo).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
