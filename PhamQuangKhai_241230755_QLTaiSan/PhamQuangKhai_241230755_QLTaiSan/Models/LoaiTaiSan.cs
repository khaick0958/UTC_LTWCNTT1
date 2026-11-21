using System;
using System.Collections.Generic;

namespace PhamQuangKhai_241230755_QLTaiSan.Models;

public partial class LoaiTaiSan
{
    public int MaLoai { get; set; }

    public string TenLoai { get; set; } = null!;

    public virtual ICollection<TaiSan> TaiSans { get; set; } = new List<TaiSan>();
}
