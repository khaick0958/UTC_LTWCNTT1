using System;
using System.Collections.Generic;

namespace PhamQuangKhai_241230755_QLTaiSan.Models;

public partial class TaiSan
{
    public int MaTs { get; set; }

    public int MaLoai { get; set; }

    public string TenTs { get; set; } = null!;

    public decimal? NguyenGia { get; set; }

    public string? Anh { get; set; }

    public virtual LoaiTaiSan MaLoaiNavigation { get; set; } = null!;
}
