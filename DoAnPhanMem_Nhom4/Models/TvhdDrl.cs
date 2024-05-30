using System;
using System.Collections.Generic;

namespace DoAnPhanMem_Nhom4.Models;

public partial class TvhdDrl
{
    public string IdTvhd { get; set; } = null!;

    public string IdDrl { get; set; } = null!;

    public decimal? SoLan { get; set; }

    public virtual DiemRenLuyen IdDrlNavigation { get; set; } = null!;

    public virtual ThanhVienHoiDong IdTvhdNavigation { get; set; } = null!;
}
