using System;
using System.Collections.Generic;

namespace DoAnPhanMem_Nhom4.Models;

public partial class HocKy
{
    public string IdHocKy { get; set; } = null!;

    public string? TenHocKy { get; set; }

    public virtual ICollection<DiemRenLuyen> DiemRenLuyens { get; set; } = new List<DiemRenLuyen>();
}
