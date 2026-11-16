using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLHangHoaMVC.Models;

[Table("LoaiHang")]
public class LoaiHang
{
    [Key]
    public int MaLoai { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập tên loại hàng") ]
    [StringLength(50)]
    public string TenLoai { get; set; } = string.Empty;

    public ICollection<HangHoa> HangHoas { get; set; } = new List<HangHoa>();
}
