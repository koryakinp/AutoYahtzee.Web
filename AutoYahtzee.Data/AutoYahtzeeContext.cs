using AutoYahtzee.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoYahtzee.Data
{
    public partial class AutoYahtzeeContext : DbContext
    {
        public AutoYahtzeeContext()
        {
        }

        public AutoYahtzeeContext(DbContextOptions<AutoYahtzeeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Predictions> Predictions { get; set; }
        public virtual DbSet<Throws> Throws { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Predictions>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Throw)
                    .WithMany(p => p.Predictions)
                    .HasForeignKey(d => d.ThrowId)
                    .HasConstraintName("FK_Predictions_ToTableThrows");
            });

            modelBuilder.Entity<Throws>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.ThrowNumber).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<YahtzeeResult>().HasNoKey().ToView(null);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
