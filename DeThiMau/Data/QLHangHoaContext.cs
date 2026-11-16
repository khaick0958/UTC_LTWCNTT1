using Microsoft.EntityFrameworkCore;
using QLHangHoaMVC.Models;

namespace QLHangHoaMVC.Data;

public class QLHangHoaContext(DbContextOptions<QLHangHoaContext> options) : DbContext(options)
{
    public DbSet<HangHoa> HangHoas => Set<HangHoa>();
    public DbSet<LoaiHang> LoaiHangs => Set<LoaiHang>();
}
