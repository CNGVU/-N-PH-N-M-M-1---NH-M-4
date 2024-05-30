using System;
using System.Collections.Generic;

namespace DoAnPhanMem_Nhom4.Models;

public partial class TbDiemRenLuyen
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

    public virtual TbHocKy? IdHocKyNavigation { get; set; }

    public virtual TbMinhChung? IdMinhChungNavigation { get; set; }

    public virtual TbNoiDungTieuChi? IdNoiDungNavigation { get; set; }

    public virtual TbSinhVien? IdSvNavigation { get; set; }

    public virtual ICollection<TbTvhdDrl> TbTvhdDrls { get; set; } = new List<TbTvhdDrl>();

    public virtual ICollection<TbPctsv> IdCbs { get; set; } = new List<TbPctsv>();
}
