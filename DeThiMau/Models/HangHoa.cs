using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLHangHoaMVC.Models;

[Table("HangHoa")]
public class HangHoa
{
    [Key]
    public int MaHang { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn loại hàng") ]
    [Display(Name = "Loại hàng")]
    public int MaLoai { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập tên hàng") ]
    [StringLength(50, ErrorMessage = "Tên hàng tối đa 50 ký tự")]
    [Display(Name = "Tên hàng")]
    public string TenHang { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập giá") ]
    [Range(typeof(decimal), "100", "5000", ErrorMessage = "Giá phải là số từ 100 đến 5000") ]
    [Column(TypeName = "numeric(18,0)")]
    [Display(Name = "Giá")]
    public decimal? Gia { get; set; }

    [StringLength(100)]
    [RegularExpression(@"(?i)^.+\.(jpg|png|gif|tiff)$", ErrorMessage = "Tên ảnh phải có đuôi .jpg, .png, .gif hoặc .tiff") ]
    [Display(Name = "Tên ảnh")]
    public string? Anh { get; set; }

    [ForeignKey(nameof(MaLoai))]
    public LoaiHang? LoaiHang { get; set; }
}
