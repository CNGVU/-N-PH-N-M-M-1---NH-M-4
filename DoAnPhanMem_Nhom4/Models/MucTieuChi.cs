using System;
using System.Collections.Generic;

namespace DoAnPhanMem_Nhom4.Models;

public partial class MucTieuChi
{
    public string IdMuc { get; set; } = null!;

    public string? TenMuc { get; set; }

    public decimal? DiemToiDa { get; set; }

    public virtual ICollection<NoiDungTieuChi> NoiDungTieuChis { get; set; } = new List<NoiDungTieuChi>();
}
