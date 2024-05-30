using System;
using System.Collections.Generic;

namespace DoAnPhanMem_Nhom4.Models;

public partial class TbGvcn
{
    public string IdGv { get; set; } = null!;

    public string? IdLop { get; set; }

    public string? TenGv { get; set; }

    public string? TenDangNhap { get; set; }

    public string? MatKhau { get; set; }

    public virtual TbLop? IdLopNavigation { get; set; }
}
