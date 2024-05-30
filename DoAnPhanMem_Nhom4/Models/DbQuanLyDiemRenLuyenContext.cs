using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DoAnPhanMem_Nhom4.Models;

public partial class DbQuanLyDiemRenLuyenContext : DbContext
{
    public DbQuanLyDiemRenLuyenContext()
    {
    }

    public DbQuanLyDiemRenLuyenContext(DbContextOptions<DbQuanLyDiemRenLuyenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DiemRenLuyen> DiemRenLuyens { get; set; }

    public virtual DbSet<Gvcn> Gvcns { get; set; }

    public virtual DbSet<HocKy> HocKies { get; set; }

    public virtual DbSet<HoiDongDanhGium> HoiDongDanhGia { get; set; }

    public virtual DbSet<Khoa> Khoas { get; set; }

    public virtual DbSet<Lop> Lops { get; set; }

    public virtual DbSet<MinhChung> MinhChungs { get; set; }

    public virtual DbSet<MucTieuChi> MucTieuChis { get; set; }

    public virtual DbSet<NoiDungTieuChi> NoiDungTieuChis { get; set; }

    public virtual DbSet<Pctsv> Pctsvs { get; set; }

    public virtual DbSet<SinhVien> SinhViens { get; set; }

    public virtual DbSet<ThanhVienHoiDong> ThanhVienHoiDongs { get; set; }

    public virtual DbSet<TvhdDrl> TvhdDrls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=dbQuanLyDiemRenLuyen;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DiemRenLuyen>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DiemRenL__3213E83FE1BB8512");

            entity.ToTable("DiemRenLuyen");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.DiemBcs)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("diemBCS");
            entity.Property(e => e.DiemGv)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("diemGV");
            entity.Property(e => e.DiemHoiDongDanhGia)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("diemHoiDongDanhGia");
            entity.Property(e => e.DiemKhoa)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("diemKhoa");
            entity.Property(e => e.DiemSv)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("diemSV");
            entity.Property(e => e.IdHocKy)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idHocKy");
            entity.Property(e => e.IdMinhChung)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idMinhChung");
            entity.Property(e => e.IdNoiDung)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idNoiDung");
            entity.Property(e => e.IdSv)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idSV");

            entity.HasOne(d => d.IdHocKyNavigation).WithMany(p => p.DiemRenLuyens)
                .HasForeignKey(d => d.IdHocKy)
                .HasConstraintName("FK__DiemRenLu__idHoc__3F466844");

            entity.HasOne(d => d.IdMinhChungNavigation).WithMany(p => p.DiemRenLuyens)
                .HasForeignKey(d => d.IdMinhChung)
                .HasConstraintName("FK__DiemRenLu__idMin__412EB0B6");

            entity.HasOne(d => d.IdNoiDungNavigation).WithMany(p => p.DiemRenLuyens)
                .HasForeignKey(d => d.IdNoiDung)
                .HasConstraintName("FK__DiemRenLu__idNoi__403A8C7D");

            entity.HasOne(d => d.IdSvNavigation).WithMany(p => p.DiemRenLuyens)
                .HasForeignKey(d => d.IdSv)
                .HasConstraintName("FK__DiemRenLuy__idSV__3E52440B");
        });

        modelBuilder.Entity<Gvcn>(entity =>
        {
            entity.HasKey(e => e.IdGv).HasName("PK__GVCN__9DB891C9A937B3B4");

            entity.ToTable("GVCN");

            entity.Property(e => e.IdGv)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idGV");
            entity.Property(e => e.IdLop)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idLop");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("matKhau");
            entity.Property(e => e.TenDangNhap)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tenDangNhap");
            entity.Property(e => e.TenGv)
                .HasMaxLength(250)
                .HasColumnName("tenGV");

            entity.HasOne(d => d.IdLopNavigation).WithMany(p => p.Gvcns)
                .HasForeignKey(d => d.IdLop)
                .HasConstraintName("FK__GVCN__idLop__29572725");
        });

        modelBuilder.Entity<HocKy>(entity =>
        {
            entity.HasKey(e => e.IdHocKy).HasName("PK__HocKy__4C0483645561C370");

            entity.ToTable("HocKy");

            entity.Property(e => e.IdHocKy)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idHocKy");
            entity.Property(e => e.TenHocKy)
                .HasMaxLength(50)
                .HasColumnName("tenHocKy");
        });

        modelBuilder.Entity<HoiDongDanhGium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HoiDongD__3213E83FCE6226FE");

            entity.Property(e => e.Id)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.Ten)
                .HasMaxLength(250)
                .HasColumnName("ten");
        });

        modelBuilder.Entity<Khoa>(entity =>
        {
            entity.HasKey(e => e.IdKhoa).HasName("PK__Khoa__C30A683DF1CD78F1");

            entity.ToTable("Khoa");

            entity.Property(e => e.IdKhoa)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idKhoa");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("matKhau");
            entity.Property(e => e.TaiKhoan)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("taiKhoan");
            entity.Property(e => e.TenKhoa)
                .HasMaxLength(250)
                .HasColumnName("tenKhoa");
        });

        modelBuilder.Entity<Lop>(entity =>
        {
            entity.HasKey(e => e.IdLop).HasName("PK__Lop__3C7153C34CB07512");

            entity.ToTable("Lop");

            entity.Property(e => e.IdLop)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idLop");
            entity.Property(e => e.IdKhoa)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idKhoa");
            entity.Property(e => e.TenLop)
                .HasMaxLength(250)
                .HasColumnName("tenLop");

            entity.HasOne(d => d.IdKhoaNavigation).WithMany(p => p.Lops)
                .HasForeignKey(d => d.IdKhoa)
                .HasConstraintName("FK__Lop__idKhoa__267ABA7A");
        });

        modelBuilder.Entity<MinhChung>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MinhChun__3213E83F51D2158A");

            entity.ToTable("MinhChung");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.HinhAnh)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("hinhAnh");
            entity.Property(e => e.Ten)
                .HasMaxLength(250)
                .HasColumnName("ten");
        });

        modelBuilder.Entity<MucTieuChi>(entity =>
        {
            entity.HasKey(e => e.IdMuc).HasName("PK__MucTieuC__3DC76D9457A8FFD8");

            entity.ToTable("MucTieuChi");

            entity.Property(e => e.IdMuc)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idMuc");
            entity.Property(e => e.DiemToiDa)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("diemToiDa");
            entity.Property(e => e.TenMuc)
                .HasMaxLength(250)
                .HasColumnName("tenMuc");
        });

        modelBuilder.Entity<NoiDungTieuChi>(entity =>
        {
            entity.HasKey(e => e.IdNoiDung).HasName("PK__NoiDungT__DB341D4C1272AD81");

            entity.ToTable("NoiDungTieuChi");

            entity.Property(e => e.IdNoiDung)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idNoiDung");
            entity.Property(e => e.DiemToiDa)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("diemToiDa");
            entity.Property(e => e.IdMuc)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idMuc");
            entity.Property(e => e.TenNoiDung)
                .HasMaxLength(250)
                .HasColumnName("tenNoiDung");

            entity.HasOne(d => d.IdMucNavigation).WithMany(p => p.NoiDungTieuChis)
                .HasForeignKey(d => d.IdMuc)
                .HasConstraintName("FK__NoiDungTi__idMuc__2E1BDC42");
        });

        modelBuilder.Entity<Pctsv>(entity =>
        {
            entity.HasKey(e => e.IdCb).HasName("PK__PCTSV__9DB8B660564FDAAA");

            entity.ToTable("PCTSV");

            entity.Property(e => e.IdCb)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idCB");
            entity.Property(e => e.ChucVu)
                .HasMaxLength(50)
                .HasColumnName("chucVu");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("matKhau");
            entity.Property(e => e.Sdt)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("sdt");
            entity.Property(e => e.TenCb)
                .HasMaxLength(250)
                .HasColumnName("tenCB");
            entity.Property(e => e.TenDangNhap)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tenDangNhap");

            entity.HasMany(d => d.IdDrls).WithMany(p => p.IdCbs)
                .UsingEntity<Dictionary<string, object>>(
                    "PctsvDrl",
                    r => r.HasOne<DiemRenLuyen>().WithMany()
                        .HasForeignKey("IdDrl")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PCTSV_DRL__idDRL__44FF419A"),
                    l => l.HasOne<Pctsv>().WithMany()
                        .HasForeignKey("IdCb")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PCTSV_DRL__idCB__440B1D61"),
                    j =>
                    {
                        j.HasKey("IdCb", "IdDrl").HasName("PK__PCTSV_DR__9E5C5BDB444696A1");
                        j.ToTable("PCTSV_DRL");
                        j.IndexerProperty<string>("IdCb")
                            .HasMaxLength(10)
                            .IsUnicode(false)
                            .IsFixedLength()
                            .HasColumnName("idCB");
                        j.IndexerProperty<string>("IdDrl")
                            .HasMaxLength(10)
                            .IsUnicode(false)
                            .IsFixedLength()
                            .HasColumnName("idDRL");
                    });
        });

        modelBuilder.Entity<SinhVien>(entity =>
        {
            entity.HasKey(e => e.IdSv).HasName("PK__SinhVien__9DB830408876C8BF");

            entity.ToTable("SinhVien");

            entity.Property(e => e.IdSv)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idSV");
            entity.Property(e => e.BanCanSu)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("banCanSu");
            entity.Property(e => e.IdLop)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idLop");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("matKhau");
            entity.Property(e => e.TenDangNhap)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tenDangNhap");
            entity.Property(e => e.TenSv)
                .HasMaxLength(250)
                .HasColumnName("tenSV");

            entity.HasOne(d => d.IdLopNavigation).WithMany(p => p.SinhViens)
                .HasForeignKey(d => d.IdLop)
                .HasConstraintName("FK__SinhVien__idLop__34C8D9D1");
        });

        modelBuilder.Entity<ThanhVienHoiDong>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ThanhVie__3213E83FFFCCD792");

            entity.ToTable("ThanhVienHoiDong");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.IdHoiDong)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idHoiDong");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("matKhau");
            entity.Property(e => e.Ten)
                .HasMaxLength(250)
                .HasColumnName("ten");
            entity.Property(e => e.TenDangNhap)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tenDangNhap");

            entity.HasOne(d => d.IdHoiDongNavigation).WithMany(p => p.ThanhVienHoiDongs)
                .HasForeignKey(d => d.IdHoiDong)
                .HasConstraintName("FK__ThanhVien__idHoi__3B75D760");
        });

        modelBuilder.Entity<TvhdDrl>(entity =>
        {
            entity.HasKey(e => new { e.IdTvhd, e.IdDrl }).HasName("PK__TVHD_DRL__B5D19C7E95815FA3");

            entity.ToTable("TVHD_DRL");

            entity.Property(e => e.IdTvhd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idTVHD");
            entity.Property(e => e.IdDrl)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idDRL");
            entity.Property(e => e.SoLan)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("soLan");

            entity.HasOne(d => d.IdDrlNavigation).WithMany(p => p.TvhdDrls)
                .HasForeignKey(d => d.IdDrl)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TVHD_DRL__idDRL__48CFD27E");

            entity.HasOne(d => d.IdTvhdNavigation).WithMany(p => p.TvhdDrls)
                .HasForeignKey(d => d.IdTvhd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TVHD_DRL__idTVHD__47DBAE45");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
