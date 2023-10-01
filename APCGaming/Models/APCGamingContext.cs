using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace APCGaming.Models
{
    public partial class APCGamingContext : DbContext
    {
        public APCGamingContext()
        {
        }

        public APCGamingContext(DbContextOptions<APCGamingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<TinTuc> TinTucs { get; set; }
        public virtual DbSet<Trang> Trangs { get; set; }
        public virtual DbSet<TrangThaiDonHang> TrangThaiDonHangs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOPASUS\\LTCSDL;Database=APCGaming;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ChiTietDonHang>(entity =>
            {
                entity.HasKey(e => new { e.DonHangId, e.SanPhamId });

                entity.ToTable("ChiTietDonHang");

                entity.Property(e => e.DonHangId).HasColumnName("DonHangID");

                entity.Property(e => e.SanPhamId).HasColumnName("SanPhamID");

                entity.HasOne(d => d.DonHang)
                    .WithMany(p => p.ChiTietDonHangs)
                    .HasForeignKey(d => d.DonHangId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietDonHang_DonHang");

                entity.HasOne(d => d.SanPham)
                    .WithMany(p => p.ChiTietDonHangs)
                    .HasForeignKey(d => d.SanPhamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietDonHang_SanPham");
            });

            modelBuilder.Entity<ChucVu>(entity =>
            {
                entity.ToTable("ChucVu");

                entity.Property(e => e.ChucVuId).HasColumnName("ChucVuID");

                entity.Property(e => e.MoTa).HasMaxLength(50);

                entity.Property(e => e.TenChucVu)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<DanhMuc>(entity =>
            {
                entity.ToTable("DanhMuc");

                entity.Property(e => e.DanhMucId).HasColumnName("DanhMucID");

                entity.Property(e => e.TenDanhMuc)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.ToTable("DonHang");

                entity.Property(e => e.DonHangId).HasColumnName("DonHangID");

                entity.Property(e => e.DiaChi).HasMaxLength(255);

                entity.Property(e => e.GhiChu).HasMaxLength(50);

                entity.Property(e => e.KhachHangId).HasColumnName("KhachHangID");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.NgayThanhToan).HasColumnType("datetime");

                entity.Property(e => e.TrangThaiDonHangId).HasColumnName("TrangThaiDonHangID");

                entity.HasOne(d => d.KhachHang)
                    .WithMany(p => p.DonHangs)
                    .HasForeignKey(d => d.KhachHangId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DonHang_KhachHang");

                entity.HasOne(d => d.TrangThaiDonHang)
                    .WithMany(p => p.DonHangs)
                    .HasForeignKey(d => d.TrangThaiDonHangId)
                    .HasConstraintName("FK_DonHang_TrangThaiDonHang");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.ToTable("KhachHang");

                entity.Property(e => e.KhachHangId).HasColumnName("KhachHangID");

                entity.Property(e => e.Avatar).HasMaxLength(255);

                entity.Property(e => e.ChuoiMaHoaMk)
                    .HasMaxLength(100)
                    .HasColumnName("ChuoiMaHoaMK");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.HoKh)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("HoKH");

                entity.Property(e => e.MatKhau).IsRequired();

                entity.Property(e => e.Sđt).HasColumnName("SĐT");

                entity.Property(e => e.TenDangNhap)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TenKh)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TenKH");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.TaiKhoanId);

                entity.ToTable("NhanVien");

                entity.Property(e => e.TaiKhoanId).HasColumnName("TaiKhoanID");

                entity.Property(e => e.ChucVuId).HasColumnName("ChucVuID");

                entity.Property(e => e.ChuoiMaHoaMk)
                    .HasMaxLength(5)
                    .HasColumnName("ChuoiMaHoaMK")
                    .IsFixedLength(true);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.HoNv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("HoNV");

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NgayVaoLam).HasColumnType("datetime");

                entity.Property(e => e.Sđt).HasColumnName("SĐT");

                entity.Property(e => e.TenNv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TenNV");

                entity.HasOne(d => d.ChucVu)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.ChucVuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NhanVien_ChucVu");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.ToTable("SanPham");

                entity.Property(e => e.SanPhamId).HasColumnName("SanPhamID");

                entity.Property(e => e.Avatar).HasMaxLength(255);

                entity.Property(e => e.DanhMucId).HasColumnName("DanhMucID");

                entity.Property(e => e.NgayCapNhat).HasColumnType("datetime");

                entity.Property(e => e.NgayTao).HasColumnType("date");

                entity.Property(e => e.TenSp)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TenSP");

                entity.Property(e => e.The).HasMaxLength(255);

                entity.HasOne(d => d.DanhMuc)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.DanhMucId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SanPham_DanhMuc");
            });

            modelBuilder.Entity<TinTuc>(entity =>
            {
                entity.ToTable("TinTuc");

                entity.Property(e => e.TinTucId)
                    .ValueGeneratedNever()
                    .HasColumnName("TinTucID");

                entity.Property(e => e.DanhMucId).HasColumnName("DanhMucID");

                entity.Property(e => e.HinhAnh).HasMaxLength(255);

                entity.Property(e => e.IsHot).HasColumnName("isHot");

                entity.Property(e => e.IsNewfeed).HasColumnName("isNewfeed");

                entity.Property(e => e.MoTaNgan).HasMaxLength(255);

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.TacGia).HasMaxLength(255);

                entity.Property(e => e.TieuDe).HasMaxLength(255);

                entity.HasOne(d => d.DanhMuc)
                    .WithMany(p => p.TinTucs)
                    .HasForeignKey(d => d.DanhMucId)
                    .HasConstraintName("FK_DanhMuc_TinTuc");
            });

            modelBuilder.Entity<Trang>(entity =>
            {
                entity.ToTable("Trang");

                entity.Property(e => e.TrangId).HasColumnName("TrangID");

                entity.Property(e => e.HinhAnh)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.NoiDung).HasMaxLength(250);

                entity.Property(e => e.TenTrang).HasMaxLength(250);

                entity.Property(e => e.TieuDe).HasMaxLength(250);
            });

            modelBuilder.Entity<TrangThaiDonHang>(entity =>
            {
                entity.ToTable("TrangThaiDonHang");

                entity.Property(e => e.TrangThaiDonHangId).HasColumnName("TrangThaiDonHangID");

                entity.Property(e => e.MoTa).HasMaxLength(50);

                entity.Property(e => e.Ten).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
