using System;
using System.Collections.Generic;

namespace DoAnPhanMem_Nhom4.Models;

public partial class NoiDungTieuChi
{
    public string IdNoiDung { get; set; } = null!;

    public string? IdMuc { get; set; }

    public string? TenNoiDung { get; set; }

    public decimal? DiemToiDa { get; set; }

    public virtual ICollection<DiemRenLuyen> DiemRenLuyens { get; set; } = new List<DiemRenLuyen>();

    public virtual MucTieuChi? IdMucNavigation { get; set; }
}
