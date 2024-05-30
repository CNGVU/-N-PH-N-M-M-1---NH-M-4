using System;
using System.Collections.Generic;

namespace DoAnPhanMem_Nhom4.Models;

public partial class TbPctsv
{
    public string IdCb { get; set; } = null!;

    public string? TenCb { get; set; }

    public string? Sdt { get; set; }

    public string? Email { get; set; }

    public string? ChucVu { get; set; }

    public string? TenDangNhap { get; set; }

    public string? MatKhau { get; set; }

    public virtual ICollection<TbDiemRenLuyen> IdDrls { get; set; } = new List<TbDiemRenLuyen>();
}
