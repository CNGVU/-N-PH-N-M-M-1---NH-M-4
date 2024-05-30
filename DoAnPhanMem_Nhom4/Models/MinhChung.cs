using System;
using System.Collections.Generic;

namespace DoAnPhanMem_Nhom4.Models;

public partial class MinhChung
{
    public string Id { get; set; } = null!;

    public string? Ten { get; set; }

    public string? HinhAnh { get; set; }

    public virtual ICollection<DiemRenLuyen> DiemRenLuyens { get; set; } = new List<DiemRenLuyen>();
}
