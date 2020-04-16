using System;
using AutoYahtzee.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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

        public virtual DbSet<Experiment> Experiments { get; set; }
        public virtual DbSet<Throw> Throws { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Experiment>(entity =>
            {
                entity.ToTable("Experiments");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateStarted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Throw>(entity =>
            {
                entity.ToTable("Throws");
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.ImageUrl).IsUnicode(false);

                entity.Property(e => e.Result)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ResultProcessedDate).HasColumnType("datetime");

                entity.Property(e => e.VideoUrl).IsUnicode(false);

                entity.Property(e => e.ThrowNumber).HasColumnType("INT");

                entity.HasOne(d => d.Experiment)
                    .WithMany(p => p.Throws)
                    .HasForeignKey(d => d.ExperimentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Throws_ToTableExperiments");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
