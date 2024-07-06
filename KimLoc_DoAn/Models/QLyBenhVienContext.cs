using Microsoft.EntityFrameworkCore;

namespace KimLoc_DoAn.Models
{
    public partial class QLyBenhVienContext : DbContext
    {
        public QLyBenhVienContext(DbContextOptions<QLyBenhVienContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<BacSi> BacSis { get; set; }
        public virtual DbSet<BenhNhan> BenhNhans { get; set; }
        public virtual DbSet<Khoa> Khoas { get; set; }
        public virtual DbSet<DatLich> DatLichs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Admin");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<BenhNhan>(entity =>
            {
                entity.ToTable("BenhNhan");

                entity.Property(e => e.Id)
                    .HasColumnName("IdBenhNhan")
                    .ValueGeneratedNever();

                entity.Property(e => e.HoTenBenhNhan)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.TenBenh)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.NgaySinh)
                    .HasColumnType("date")
                    .IsRequired();

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(20)
                    .IsRequired();

                entity.Property(e => e.DiaChi)
                    .HasMaxLength(200)
                    .IsRequired();

                entity.HasMany(e => e.DatLichs)
                    .WithOne(d => d.BenhNhan)
                    .HasForeignKey(d => d.BenhNhanId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<BacSi>(entity =>
            {
                entity.ToTable("BacSi");

                entity.Property(e => e.Id)
                    .HasColumnName("IdBacSi")
                    .ValueGeneratedNever();

                entity.Property(e => e.TenBacSi)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.NamKinhNghiem)
                    .IsRequired();

                entity.Property(e => e.HinhAnh)
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.MoTaBacSi)
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.KhoaId)
                    .IsRequired();

                entity.HasOne(b => b.Khoa)
                    .WithMany(k => k.BacSis)
                    .HasForeignKey(b => b.KhoaId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(e => e.DatLichs)
                    .WithOne(d => d.BacSi)
                    .HasForeignKey(d => d.BacSiId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Khoa>(entity =>
            {
                entity.ToTable("Khoa");

                entity.Property(e => e.Id)
                    .HasColumnName("IdKhoa")
                    .ValueGeneratedNever();

                entity.Property(e => e.TenKhoa)
                    .HasMaxLength(100)
                    .IsRequired();
            });

            modelBuilder.Entity<DatLich>(entity =>
            {
                entity.ToTable("DatLich");

                entity.Property(e => e.Id)
                    .HasColumnName("IdDatLich")
                    .ValueGeneratedNever();

                entity.Property(e => e.NgayDatLich)
                    .HasColumnType("date")
                    .IsRequired();

                entity.Property(e => e.NgayHenKham) 
                    .IsRequired();

                entity.Property(e => e.GhiChu)
                    .HasMaxLength(500);

                entity.Property(e => e.TrangThai)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.HasOne(d => d.BenhNhan)
                    .WithMany(p => p.DatLichs)
                    .HasForeignKey(d => d.BenhNhanId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.BacSi)
                    .WithMany(p => p.DatLichs)
                    .HasForeignKey(d => d.BacSiId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
