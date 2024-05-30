using System;
using System.Collections.Generic;

namespace DoAnPhanMem_Nhom4.Models;

public partial class TbTvhdDrl
{
    public string IdTvhd { get; set; } = null!;

    public string IdDrl { get; set; } = null!;

    public decimal? SoLan { get; set; }

    public virtual TbDiemRenLuyen IdDrlNavigation { get; set; } = null!;

    public virtual TbThanhVienHoiDong IdTvhdNavigation { get; set; } = null!;
}
