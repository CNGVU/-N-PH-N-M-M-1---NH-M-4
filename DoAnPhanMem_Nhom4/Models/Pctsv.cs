using System;
using System.Collections.Generic;

namespace DoAnPhanMem_Nhom4.Models;

public partial class Pctsv
{
    public string IdCb { get; set; } = null!;

    public string? TenCb { get; set; }

    public string? Sdt { get; set; }

    public string? Email { get; set; }

    public string? ChucVu { get; set; }

    public string? TenDangNhap { get; set; }

    public string? MatKhau { get; set; }

    public virtual ICollection<DiemRenLuyen> IdDrls { get; set; } = new List<DiemRenLuyen>();
}
