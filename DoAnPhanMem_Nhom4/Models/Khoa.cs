using System;
using System.Collections.Generic;

namespace DoAnPhanMem_Nhom4.Models;

public partial class Khoa
{
    public string IdKhoa { get; set; } = null!;

    public string? TenKhoa { get; set; }

    public string? TaiKhoan { get; set; }

    public string? MatKhau { get; set; }

    public virtual ICollection<Lop> Lops { get; set; } = new List<Lop>();
}
