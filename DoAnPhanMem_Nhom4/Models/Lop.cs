using System;
using System.Collections.Generic;

namespace DoAnPhanMem_Nhom4.Models;

public partial class Lop
{
    public string IdLop { get; set; } = null!;

    public string? TenLop { get; set; }

    public string? IdKhoa { get; set; }

    public virtual ICollection<Gvcn> Gvcns { get; set; } = new List<Gvcn>();

    public virtual Khoa? IdKhoaNavigation { get; set; }

    public virtual ICollection<SinhVien> SinhViens { get; set; } = new List<SinhVien>();
}
