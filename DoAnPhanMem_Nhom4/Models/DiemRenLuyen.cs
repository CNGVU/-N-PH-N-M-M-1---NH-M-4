using System;
using System.Collections.Generic;

namespace DoAnPhanMem_Nhom4.Models;

public partial class DiemRenLuyen
{
    public string Id { get; set; } = null!;

    public string? IdSv { get; set; }

    public string? IdHocKy { get; set; }

    public string? IdNoiDung { get; set; }

    public string? IdMinhChung { get; set; }

    public decimal? DiemSv { get; set; }

    public decimal? DiemGv { get; set; }

    public decimal? DiemBcs { get; set; }

    public decimal? DiemKhoa { get; set; }

    public decimal? DiemHoiDongDanhGia { get; set; }

    public virtual HocKy? IdHocKyNavigation { get; set; }

    public virtual MinhChung? IdMinhChungNavigation { get; set; }

    public virtual NoiDungTieuChi? IdNoiDungNavigation { get; set; }

    public virtual SinhVien? IdSvNavigation { get; set; }

    public virtual ICollection<TvhdDrl> TvhdDrls { get; set; } = new List<TvhdDrl>();

    public virtual ICollection<Pctsv> IdCbs { get; set; } = new List<Pctsv>();
}
