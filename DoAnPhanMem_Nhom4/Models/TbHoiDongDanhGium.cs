using System;
using System.Collections.Generic;

namespace DoAnPhanMem_Nhom4.Models;

public partial class TbHoiDongDanhGium
{
    public string Id { get; set; } = null!;

    public string? Ten { get; set; }

    public virtual ICollection<TbThanhVienHoiDong> TbThanhVienHoiDongs { get; set; } = new List<TbThanhVienHoiDong>();
}
