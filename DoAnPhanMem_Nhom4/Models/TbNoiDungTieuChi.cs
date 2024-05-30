using System;
using System.Collections.Generic;

namespace DoAnPhanMem_Nhom4.Models;

public partial class TbNoiDungTieuChi
{
    public string IdNoiDung { get; set; } = null!;

    public string? TenNoiDung { get; set; }

    public decimal? DiemToiDa { get; set; }

    public virtual ICollection<TbDiemRenLuyen> TbDiemRenLuyens { get; set; } = new List<TbDiemRenLuyen>();
}
