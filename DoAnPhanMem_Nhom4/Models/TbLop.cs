using System;
using System.Collections.Generic;

namespace DoAnPhanMem_Nhom4.Models;

public partial class TbLop
{
    public string IdLop { get; set; } = null!;

    public string? TenLop { get; set; }

    public string? IdKhoa { get; set; }

    public virtual TbKhoa? IdKhoaNavigation { get; set; }

    public virtual ICollection<TbGvcn> TbGvcns { get; set; } = new List<TbGvcn>();

    public virtual ICollection<TbSinhVien> TbSinhViens { get; set; } = new List<TbSinhVien>();
}
