using System;
using System.Collections.Generic;

namespace DoAnPhanMem_Nhom4.Models;

public partial class HoiDongDanhGium
{
    public string Id { get; set; } = null!;

    public string? Ten { get; set; }

    public virtual ICollection<ThanhVienHoiDong> ThanhVienHoiDongs { get; set; } = new List<ThanhVienHoiDong>();
}
