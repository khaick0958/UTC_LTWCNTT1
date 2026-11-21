using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PhamQuangKhai_241230755_QLTaiSan.Models;

public partial class QltaiSanContext : DbContext
{
    public QltaiSanContext()
    {
    }

    public QltaiSanContext(DbContextOptions<QltaiSanContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LoaiTaiSan> LoaiTaiSans { get; set; }

    public virtual DbSet<TaiSan> TaiSans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server =localhost\\SQLEXPRESS; Database =QLTaiSan; Trusted_Connection=True; TrustServerCertificate=True; MultipleActiveResultSets=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LoaiTaiSan>(entity =>
        {
            entity.HasKey(e => e.MaLoai);

            entity.ToTable("LoaiTaiSan");

            entity.Property(e => e.TenLoai).HasMaxLength(50);
        });

        modelBuilder.Entity<TaiSan>(entity =>
        {
            entity.HasKey(e => e.MaTs);

            entity.ToTable("TaiSan");

            entity.Property(e => e.MaTs).HasColumnName("MaTS");
            entity.Property(e => e.Anh).HasMaxLength(100);
            entity.Property(e => e.NguyenGia).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.TenTs)
                .HasMaxLength(100)
                .HasColumnName("TenTS");

            entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.TaiSans)
                .HasForeignKey(d => d.MaLoai)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaiSan_LoaiTaiSan");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
