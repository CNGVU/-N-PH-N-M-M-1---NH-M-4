using System;
using System.Collections.Generic;

namespace DoAnPhanMem_Nhom4.Models;

public partial class TbKhoa
{
    public string IdKhoa { get; set; } = null!;

    public string? TenKhoa { get; set; }

    public string? TaiKhoan { get; set; }

    public string? MatKhau { get; set; }

    public virtual ICollection<TbLop> TbLops { get; set; } = new List<TbLop>();
}
