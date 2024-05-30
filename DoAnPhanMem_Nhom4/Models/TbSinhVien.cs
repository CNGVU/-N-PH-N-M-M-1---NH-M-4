using System;
using System.Collections.Generic;

namespace DoAnPhanMem_Nhom4.Models;

public partial class TbSinhVien
{
    public string IdSv { get; set; } = null!;

    public string? IdLop { get; set; }

    public string? TenSv { get; set; }

    public string? TenDangNhap { get; set; }

    public string? MatKhau { get; set; }

    public string? BanCanSu { get; set; }

    public virtual TbLop? IdLopNavigation { get; set; }

    public virtual ICollection<TbDiemRenLuyen> TbDiemRenLuyens { get; set; } = new List<TbDiemRenLuyen>();
}
