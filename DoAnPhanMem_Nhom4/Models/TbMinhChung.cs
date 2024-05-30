using System;
using System.Collections.Generic;

namespace DoAnPhanMem_Nhom4.Models;

public partial class TbMinhChung
{
    public string Id { get; set; } = null!;

    public string? Ten { get; set; }

    public string? HinhAnh { get; set; }

    public virtual ICollection<TbDiemRenLuyen> TbDiemRenLuyens { get; set; } = new List<TbDiemRenLuyen>();
}
