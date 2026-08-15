using System;

namespace PqkLesson01
{
    public class MenuManager
    {
        private StudentService service;

        public MenuManager(StudentService service)
        {
            this.service = service;
        }

        public void ShowMenu()
        {
            service.TestSeed();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("========== QUẢN LÝ SINH VIÊN ==========");
                Console.WriteLine("1.  Thêm sinh viên");
                Console.WriteLine("2.  Hiển thị danh sách");
                Console.WriteLine("3.  Tìm sinh viên theo mã");
                Console.WriteLine("4.  Tìm gần đúng theo họ tên");
                Console.WriteLine("5.  Cập nhật sinh viên");
                Console.WriteLine("6.  Xóa sinh viên");
                Console.WriteLine("7.  Sắp xếp theo họ tên");
                Console.WriteLine("8.  Sắp xếp theo điểm trung bình");
                Console.WriteLine("9.  Hiển thị sinh viên có điểm từ 8 trở lên");
                Console.WriteLine("10. Hiển thị sinh viên có điểm cao nhất");
                Console.WriteLine("11. Tính điểm trung bình toàn bộ sinh viên");
                Console.WriteLine("12. Thống kê sinh viên theo ngành");
                Console.WriteLine("13. Thống kê sinh viên theo trạng thái");
                Console.WriteLine("0.  Thoát");
                Console.WriteLine("========================================");

                Console.Write("Nhập lựa chọn: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    Pause();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        service.ThemSinhVien();
                        break;

                    case 2:
                        service.HienThiDanhSach();
                        break;

                    case 3:
                        service.TimSinhVienTheoMaSV();
                        break;

                    case 4:
                        service.TimSinhVienTheoHoTen();
                        break;

                    case 5:
                        service.CapNhatSinhVien();
                        break;

                    case 6:
                        service.XoaSinhVien();
                        break;

                    case 7:
                        service.SapXepDanhSachTheoHoTen();
                        break;

                    case 8:
                        service.SapXepDanhSachTheoDiemTrungBinh();
                        break;

                    case 9:
                        service.HienThiSinhVienCoDiemTrungBinhCaoHon8();
                        break;

                    case 10:
                        service.HienThiSinhVienTop1();
                        break;

                    case 11:
                        service.DiemTrungBinhCuaToanBoSinhVien();
                        break;

                    case 12:
                        service.ThongKeSinhVienTheoNghanhHoc();
                        break;

                    case 13:
                        service.ThongKeSinhVienTheoTrangThaiHoc();
                        break;

                    case 0:
                        Console.WriteLine("Đã thoát chương trình.");
                        return;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }

                Pause();
            }
        }

        private void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Nhấn Enter để tiếp tục...");
            Console.ReadLine();
        }
    }
}
