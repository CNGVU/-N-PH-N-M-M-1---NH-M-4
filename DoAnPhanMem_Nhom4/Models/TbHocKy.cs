using System;
using System.Collections.Generic;

namespace DoAnPhanMem_Nhom4.Models;

public partial class TbHocKy
{
    public string IdHocKy { get; set; } = null!;

    public string? TenHocKy { get; set; }

    public virtual ICollection<TbDiemRenLuyen> TbDiemRenLuyens { get; set; } = new List<TbDiemRenLuyen>();
}
