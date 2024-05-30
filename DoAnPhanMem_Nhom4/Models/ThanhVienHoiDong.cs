using System;
using System.Collections.Generic;

namespace DoAnPhanMem_Nhom4.Models;

public partial class ThanhVienHoiDong
{
    public string Id { get; set; } = null!;

    public string? IdHoiDong { get; set; }

    public string? Ten { get; set; }

    public string? TenDangNhap { get; set; }

    public string? MatKhau { get; set; }

    public virtual HoiDongDanhGium? IdHoiDongNavigation { get; set; }

    public virtual ICollection<TvhdDrl> TvhdDrls { get; set; } = new List<TvhdDrl>();
}
