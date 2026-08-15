namespace PqkLesson01
{
    internal class StudentService
    {
        private List<Student> students;

        //Thêm sinh viên
        static void ThemSinhVien(List<Student> students)
        {
            Student student = new Student();
            Console.Write("Nhập mã sinh viên: ");
            student.masv = Console.ReadLine();

            if (!StudentValidator.ValidateMaSV(student.masv, out string errorMasv))
            {
                Console.WriteLine(errorMasv);
                return;
            }

            Student? isExist = CheckSinhVien(students, student.masv);
            if (isExist is null)
            {
                Console.WriteLine("Mã sinh viên đã tồn tại!");
                return;
            }

            Console.Write("Nhập họ và tên: ");
            student.hoTen = Console.ReadLine();

            if (!StudentValidator.ValidateHoTen(student.hoTen, out string errorHoTen))
            {
                Console.WriteLine(errorHoTen);
                return;
            }

            Console.Write("Nhập ngày sinh: ");
            student.ngaySinh = DateTime.Parse(Console.ReadLine()!);

            Console.Write("Nhập giới tính: ");
            student.gioiTinh = bool.Parse(Console.ReadLine()!);

            Console.Write("Nhập email: ");
            student.email = Console.ReadLine();

            if (!StudentValidator.ValidateEmail(student.email, out string errorEmail))
            {
                Console.WriteLine(errorEmail);
                return;
            }

            Console.Write("Nhập số điện thoại: ");
            student.soDienThoai = Console.ReadLine();

            Console.Write("Nhập nghành học: ");
            student.nghanhHoc = Console.ReadLine();

            Console.Write("Nhập điểm trung bình: ");
            student.diemTrungBinh = float.Parse(Console.ReadLine()!);

            if (!StudentValidator.ValidateDiemTrungBinh(student.diemTrungBinh, out string errorDiemTB))
            {
                Console.WriteLine(errorDiemTB);
                return;
            }

            Console.Write("Nhập trạng thái học tập: ");
            student.trangThai = bool.Parse(Console.ReadLine());
            
            

            students.Add(student);
        }

        //Format hiển thị 1 sinh viên
        private static void ShowSinhVien(Student student)
        {
            Console.WriteLine($"Mã sinh viên: {student.masv}, Họ tên: {student.hoTen}, Ngày sinh: {student.ngaySinh.ToString("dd/MM/yyyy")}, Giới tính: {(student.gioiTinh ? "Nam" : "Nữ")}, Email: {student.email}, Số điện thoại: {student.soDienThoai}, Ngành học: {student.nghanhHoc}, Điểm trung bình: {student.diemTrungBinh}, Trạng thái: {(student.trangThai ? "Đang học" : "Nghỉ học")}");
        }

        //Hiển thị danh sách
        static void HienThiDanhSach(List<Student> students)
        {
            Console.WriteLine("Danh sách sinh viên:");
            foreach (var student in students)
            {
                ShowSinhVien(student);
            }
        }

        //Kiểm tra xem sinh viên có tồn tại trong danh sách không?
        private static Student? CheckSinhVien(List<Student> students, string maSV)
        {
            return students.FirstOrDefault(student => student.masv == maSV);
        }

        //Tìm sinh viên theo mã
        static void TimSinhVienTheoMaSV(List<Student> students)
        {
            string masv;
            Console.Write("Nhập mã sinh viên cần tìm: ");
            masv = Console.ReadLine();
            Console.Write("Kết quả: ");

            Student? student = CheckSinhVien(students, masv);

            if (student is not null)
            {
                ShowSinhVien(student);
            }
            else
            {
                Console.WriteLine("Không tìm thấy kết quả!");
            }
        }

        //Kiểm tra xem sinh viên có họ tên có tồn tại không
        static Student? CheckSinhVien2(List<Student> students, string HoTen)
        {
            return students.FirstOrDefault(student => student.hoTen == HoTen);
        }

        //Tìm gần đúng theo họ tên
        static void TimSinhVienTheoHoTen(List<Student> students)
        {
            string hoTen;
            Console.Write("Nhập họ và tên sinh viên cần tìm: ");
            hoTen = Console.ReadLine();

            Student? student = CheckSinhVien2(students, hoTen);

            if (student is not null)
            {
                ShowSinhVien(student);
            }
            else
            {
                Console.WriteLine("Không tìm thấy kết quả!");
            }
        }
        
        //Cập nhật sinh viên
        static void CapNhatSinhVien(List<Student> students)
        {
            int choice;
            string masv;
            Console.Write("Nhập mã sinh viên cần thay đổi: ");
            masv = Console.ReadLine();
            Console.Write("Kết quả: ");

            Student? student = CheckSinhVien(students, masv);

            if (student is not null)
            {
                ShowSinhVien(student);
                Console.WriteLine("1- Mã sinh viên\n2- Họ và tên\n3- Ngày sinh\n4- Giới tính\n5- Email\n6- Số điện thoại\n7- Ngành học\n8- Điểm trung bình\n9- Trạng thái học");
                Console.Write("Nhập số thứ tự của thuộc tính cần thay đổi: ");
                choice = int.Parse(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        string content1;
                        Console.Write("Nhập mã sinh viên mới: ");
                        content1 = Console.ReadLine();

                        if (!StudentValidator.ValidateMaSV(content1, out string errorMasv))
                        {
                            Console.WriteLine(errorMasv);
                            return;
                        }

                        Student? isExist = CheckSinhVien(students, student.masv);
                        if (isExist is null)
                        {
                            Console.WriteLine("Mã sinh viên đã tồn tại!");
                            return;
                        }

                        student.masv = content1;
                        Console.WriteLine("Cập nhật thành công!");
                        break;
                    case 2:
                        string content2;
                        Console.Write("Nhập họ và tên mới: ");
                        content2 = Console.ReadLine();

                        if (!StudentValidator.ValidateHoTen(student.hoTen, out string errorHoTen))
                        {
                            Console.WriteLine(errorHoTen);
                            return;
                        }

                        student.hoTen = content2;
                        Console.WriteLine("Cập nhật thành công!");
                        break;
                    case 3:
                        DateTime content3;
                        Console.Write("Nhập ngày sinh mới: ");
                        content3 = DateTime.Parse(Console.ReadLine());
                        student.ngaySinh = content3;
                        Console.WriteLine("Cập nhật thành công!");
                        break;
                    case 4:
                        bool content4;
                        Console.Write("Nhập giới tính mới: ");
                        content4 = bool.Parse(Console.ReadLine());
                        student.gioiTinh = content4;
                        Console.WriteLine("Cập nhật thành công!");
                        break;
                    case 5:
                        string content5;
                        Console.Write("Nhập email mới: ");
                        content5 = Console.ReadLine();

                        if (!StudentValidator.ValidateEmail(student.email, out string errorEmail))
                        {
                            Console.WriteLine(errorEmail);
                            return;
                        }

                        student.email = content5;
                        Console.WriteLine("Cập nhật thành công!");
                        break;
                    case 6:
                        string content6;
                        Console.Write("Nhập số điện thoại mới: ");
                        content6 = Console.ReadLine();
                        student.soDienThoai = content6;
                        Console.WriteLine("Cập nhật thành công!");
                        break;
                    case 7:
                        string content7;
                        Console.Write("Nhập nghành học mới: ");
                        content7 = Console.ReadLine();
                        student.nghanhHoc = content7;
                        Console.WriteLine("Cập nhật thành công!");
                        break;
                    case 8:
                        float content8;
                        Console.Write("Nhập điểm trung bình mới: ");
                        content8 = float.Parse(Console.ReadLine());

                        if (!StudentValidator.ValidateDiemTrungBinh(student.diemTrungBinh, out string errorDiemTB))
                        {
                            Console.WriteLine(errorDiemTB);
                            return;
                        }

                        student.diemTrungBinh = content8;
                        Console.WriteLine("Cập nhật thành công!");
                        break;
                    case 9:
                        bool content9;
                        Console.Write("Nhập trạng thái học mới: ");
                        content9 = bool.Parse(Console.ReadLine());
                        student.trangThai = content9;
                        Console.WriteLine("Cập nhật thành công!");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Không tìm thấy kết quả!");
            }
        }

        //Xóa sinh viên
        static void XoaSinhVien(List<Student> students)
        {
            string masv;
            Console.Write("Nhập mã sinh viên cần xóa: ");
            masv = Console.ReadLine();
            Console.Write("Kết quả: ");

            Student? student = CheckSinhVien(students, masv);

            if (student is not null)
            {
                students.Remove(student);
            }
            else
            {
                Console.WriteLine("Không tìm thấy kết quả!");
            }
        }

        //Sắp xếp theo họ tên
        static void SapXepDanhSachTheoHoTen(List<Student> students)
        {
            List<Student> sortedByName = students.OrderBy(student => student.hoTen).ToList();

            foreach(var student in sortedByName)
            {
                ShowSinhVien(student);
            }
        }

        //Sắp xếp theo điểm trung bình
        static void SapXepDanhSachTheoDiemTrungBinh(List<Student> students)
        {
            List<Student> sortedByAveragePoints = students.OrderBy(student => student.diemTrungBinh).ToList();

            foreach(var student in sortedByAveragePoints)
            {
                ShowSinhVien(student);
            }
        }

        //Hiển thị sinh viên có điểm từ 8 trở lên
        static void HienThiSinhVienCoDiemTrungBinhCaoHon8(List<Student> students)
        {
            int counter = 0;

            foreach (var student in students)
            {
                if (student.diemTrungBinh >= 8)
                {
                    ShowSinhVien(student);
                    counter++;
                }
            }

            if (counter == 0) Console.WriteLine("Không tìm thấy kết quả!");
        }

        //Lấy điểm trung bình cao nhất
        static float GetHighestDiemTrungBinh(List<Student> students)
        {
            float highestDiemTrungBinh = 0;

            foreach (var student in students)
            {
                if (highestDiemTrungBinh < student.diemTrungBinh) highestDiemTrungBinh = student.diemTrungBinh;
            }

            return highestDiemTrungBinh;
        }

        //Hiển thị sinh viên có điểm cao nhất
        static void HienThiSinhVienTop1(List<Student> students)
        {
            float highestDiemTrungBinh = GetHighestDiemTrungBinh(students);

            foreach (var student in students)
            {
                if (student.diemTrungBinh == highestDiemTrungBinh)
                {
                    ShowSinhVien(student);
                }
            }
        }

        //Tính điểm trung bình của toàn bộ sinh viên
        private static float AverageDiemTrungBinh(List<Student> students)
        {
            float sum = 0;
            
            foreach (var student in students)
            {
                sum += student.diemTrungBinh;
            }

            return sum / students.Count;
        }

        //In ra điểm trung bình toàn bộ sinh viên
        static void DiemTrungBinhCuaToanBoSinhVien(List<Student> students)
        {
            Console.WriteLine($"Điểm trung bình của toàn bộ sinh viên: {AverageDiemTrungBinh(students)}");
        }

        //Thống kê sinh viên theo nghành học
        static void ThongKeSinhVienTheoNghanhHoc(List<Student> students)
        {
            var thongke = students
                .GroupBy(s => s.nghanhHoc)
                .Select(g => new
                {
                    Nganh = g.Key,
                    SoLuong = g.Count()
                });

            foreach (var item in thongke)
            {
                Console.WriteLine($"Ngành: {item.Nganh} - Số lượng: {item.SoLuong}");
            }
        }

        //Thống kê sinh viên theo trạng thái
        static void ThongKeSinhVienTheoTrangThaiHoc(List<Student> students)
        {
            int dangHoc = 0, nghiHoc = 0;

            foreach(var student in students)
            {
                if (student.trangThai) dangHoc++;
                else nghiHoc++;
            }

            Console.WriteLine($"Số sinh viên vẫn đang học: {dangHoc}");
            Console.WriteLine($"Số sinh viên đã nghỉ học: {nghiHoc}");
        }
    }
}