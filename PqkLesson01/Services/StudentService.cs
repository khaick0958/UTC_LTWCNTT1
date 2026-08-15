namespace PqkLesson01
{
    public class StudentService
    {
        private List<Student> students = [];

        private bool IsListEmpty(List<Student> students)
        {
            if (students.Count == 0) return true;
            return false;
        }

        //Thêm sinh viên
        public void ThemSinhVien()
        {
            int gioitinh = 0;
            int trangthai = 0;
            Student student = new Student();
            Console.Write("Nhập mã sinh viên: ");
            student.masv = Console.ReadLine();

            if (!StudentValidator.ValidateMaSV(student.masv, out string errorMasv))
            {
                Console.WriteLine(errorMasv);
                return;
            }

            if (!IsListEmpty(students))
            {
                Student? isExist = CheckSinhVien(students, student.masv);
                if (isExist is not null)
                {
                    Console.WriteLine("Mã sinh viên đã tồn tại!");
                    return;
                }
            }


            Console.Write("Nhập họ và tên: ");
            student.hoTen = Console.ReadLine();

            if (!StudentValidator.ValidateHoTen(student.hoTen, out string errorHoTen))
            {
                Console.WriteLine(errorHoTen);
                return;
            }

            Console.Write("Nhập ngày sinh (dd/MM/yyyy): ");
            if (!StudentValidator.ValidateNgaySinh(
                Console.ReadLine()!,
                out DateTime ngaySinh,
                out string error))
            {
                Console.WriteLine(error);
                return;
            }

            student.ngaySinh = ngaySinh;

            Console.WriteLine("----Giới tính----\n1 - Nam\n2 - Nữ");
            Console.Write("Nhập giới tính (Note: Nhập số): ");
            gioitinh = int.Parse(Console.ReadLine()!);
            switch (gioitinh)
            {
                case 1:
                    student.gioiTinh = true;
                    break;

                case 2:
                    student.gioiTinh = false;
                    break;

                default:
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    return;
            }

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

            Console.WriteLine("----Trạng thái----\n1 - Đang học\n2 - Đã nghỉ/Đã tốt nghiệp");
            Console.Write("Nhập trạng thái học tập (Note: Nhập số): ");
            trangthai = int.Parse(Console.ReadLine()!);
            switch (trangthai)
            {
                case 1:
                    student.trangThai = true;
                    break;

                case 2:
                    student.trangThai = false;
                    break;

                default:
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    return;
            }

            students.Add(student);
        }

        //Format hiển thị 1 sinh viên
        private void ShowSinhVien(Student student)
        {
            Console.WriteLine($"Mã sinh viên: {student.masv}, Họ tên: {student.hoTen}, Ngày sinh: {student.ngaySinh.ToString("dd/MM/yyyy")}, Giới tính: {(student.gioiTinh ? "Nam" : "Nữ")}, Email: {student.email}, Số điện thoại: {student.soDienThoai}, Ngành học: {student.nghanhHoc}, Điểm trung bình: {student.diemTrungBinh}, Trạng thái: {(student.trangThai ? "Đang học" : "Nghỉ học")}");
        }

        //Hiển thị danh sách
        public void HienThiDanhSach()
        {
            Console.WriteLine("Danh sách sinh viên:");
            foreach (var student in students)
            {
                ShowSinhVien(student);
            }
        }

        //Kiểm tra xem sinh viên có tồn tại trong danh sách không?
        private Student? CheckSinhVien(List<Student> students, string maSV)
        {
            return students.FirstOrDefault(student => student.masv == maSV);
        }

        //Tìm sinh viên theo mã
        public void TimSinhVienTheoMaSV()
        {
            if (IsListEmpty(students))
            {
                Console.WriteLine("Không có sinh viên nào trong danh sach!");
                return;
            }

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
        public Student? CheckSinhVien2(List<Student> students, string HoTen)
        {
            return students.FirstOrDefault(student => student.hoTen == HoTen);
        }

        //Tìm gần đúng theo họ tên
        public void TimSinhVienTheoHoTen()
        {
            if (IsListEmpty(students))
            {
                Console.WriteLine("Không có sinh viên nào trong danh sach!");
                return;
            }

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
        public void CapNhatSinhVien()
        {
            if (IsListEmpty(students))
            {
                Console.WriteLine("Không có sinh viên nào trong danh sach!");
                return;
            }

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

                switch (choice)
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
                        if (isExist is not null)
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
                        Console.Write("Nhập ngày sinh mới: ");
                        if (!StudentValidator.ValidateNgaySinh(
                            Console.ReadLine()!,
                            out DateTime ngaySinh,
                            out string error))
                        {
                            Console.WriteLine(error);
                            return;
                        }
                        student.ngaySinh = ngaySinh;
                        Console.WriteLine("Cập nhật thành công!");
                        break;
                    case 4:
                        int content4 = 0;
                        Console.WriteLine("----Giới tính----\n1 - Nam\n2 - Nữ");
                        Console.Write("Nhập giới tính mới (Note: Nhập số): ");
                        content4 = int.Parse(Console.ReadLine());
                        switch (content4)
                        {
                            case 1:
                                student.gioiTinh = true;
                                break;

                            case 2:
                                student.gioiTinh = false;
                                break;

                            default:
                                Console.WriteLine("Lựa chọn không hợp lệ!");
                                return;
                        }
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
                        int content9;
                        Console.WriteLine("----Trạng thái----\n1 - Đang học\n2 - Đã nghỉ/Đã tốt nghiệp");
                        Console.Write("Nhập trạng thái học mới (Note: Nhập số): ");
                        content9 = int.Parse(Console.ReadLine()!);
                        switch (content9)
                        {
                            case 1:
                                student.trangThai = true;
                                break;

                            case 2:
                                student.trangThai = false;
                                break;

                            default:
                                Console.WriteLine("Lựa chọn không hợp lệ!");
                                return;
                        }
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
        public void XoaSinhVien()
        {
            if (IsListEmpty(students))
            {
                Console.WriteLine("Không có sinh viên nào trong danh sach!");
                return;
            }

            string masv;
            Console.Write("Nhập mã sinh viên cần xóa: ");
            masv = Console.ReadLine();
            Console.Write("Kết quả: ");

            Student? student = CheckSinhVien(students, masv);

            if (student is not null)
            {
                students.Remove(student);
                Console.WriteLine("Xóa thành công!");
            }
            else
            {
                Console.WriteLine("Không tìm thấy kết quả!");
            }
        }

        //Sắp xếp theo họ tên
        public void SapXepDanhSachTheoHoTen()
        {
            if (IsListEmpty(students))
            {
                Console.WriteLine("Không có sinh viên nào trong danh sach!");
                return;
            }

            List<Student> sortedByName = students.OrderBy(student => student.hoTen).ToList();

            foreach (var student in sortedByName)
            {
                ShowSinhVien(student);
            }
        }

        //Sắp xếp theo điểm trung bình
        public void SapXepDanhSachTheoDiemTrungBinh()
        {
            if (IsListEmpty(students))
            {
                Console.WriteLine("Không có sinh viên nào trong danh sach!");
                return;
            }

            List<Student> sortedByAveragePoints = students.OrderBy(student => student.diemTrungBinh).ToList();

            foreach (var student in sortedByAveragePoints)
            {
                ShowSinhVien(student);
            }
        }

        //Hiển thị sinh viên có điểm từ 8 trở lên
        public void HienThiSinhVienCoDiemTrungBinhCaoHon8()
        {
            if (IsListEmpty(students))
            {
                Console.WriteLine("Không có sinh viên nào trong danh sach!");
                return;
            }

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
        private float GetHighestDiemTrungBinh(List<Student> students)
        {
            float highestDiemTrungBinh = 0;

            foreach (var student in students)
            {
                if (highestDiemTrungBinh < student.diemTrungBinh) highestDiemTrungBinh = student.diemTrungBinh;
            }

            return highestDiemTrungBinh;
        }

        //Hiển thị sinh viên có điểm cao nhất
        public void HienThiSinhVienTop1()
        {
            if (IsListEmpty(students))
            {
                Console.WriteLine("Không có sinh viên nào trong danh sach!");
                return;
            }

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
        private float AverageDiemTrungBinh(List<Student> students)
        {
            float sum = 0;

            foreach (var student in students)
            {
                sum += student.diemTrungBinh;
            }

            return sum / students.Count;
        }

        //In ra điểm trung bình toàn bộ sinh viên
        public void DiemTrungBinhCuaToanBoSinhVien()
        {
            if (IsListEmpty(students))
            {
                Console.WriteLine("Không có sinh viên nào trong danh sach!");
                return;
            }

            Console.WriteLine($"Điểm trung bình của toàn bộ sinh viên: {AverageDiemTrungBinh(students)}");
        }

        //Thống kê sinh viên theo nghành học
        public void ThongKeSinhVienTheoNghanhHoc()
        {
            if (IsListEmpty(students))
            {
                Console.WriteLine("Không có sinh viên nào trong danh sach!");
                return;
            }

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
        public void ThongKeSinhVienTheoTrangThaiHoc()
        {
            if (IsListEmpty(students))
            {
                Console.WriteLine("Không có sinh viên nào trong danh sach!");
                return;
            }

            int dangHoc = 0, nghiHoc = 0;

            foreach (var student in students)
            {
                if (student.trangThai) dangHoc++;
                else nghiHoc++;
            }

            Console.WriteLine($"Số sinh viên vẫn đang học: {dangHoc}");
            Console.WriteLine($"Số sinh viên đã nghỉ học/tốt nghiệp: {nghiHoc}");
        }

        public void TestSeed()
        {
            Student test1 = new Student()
            {
                masv = "001",
                hoTen = "A",
                ngaySinh = new DateTime(2006, 2, 7),
                gioiTinh = true,
                email = "AAA@gmail.com",
                soDienThoai = "1111",
                nghanhHoc = "CNTT",
                diemTrungBinh = 9.6f,
                trangThai = true
            };

            Student test2 = new Student()
            {
                masv = "002",
                hoTen = "B",
                ngaySinh = new DateTime(2006, 5, 15),
                gioiTinh = false,
                email = "BBB@gmail.com",
                soDienThoai = "2222",
                nghanhHoc = "KHMT",
                diemTrungBinh = 7.2f,
                trangThai = true
            };

            Student test3 = new Student()
            {
                masv = "003",
                hoTen = "C",
                ngaySinh = new DateTime(2000, 1, 1),
                gioiTinh = true,
                email = "CCC@gmail.com",
                soDienThoai = "3333",
                nghanhHoc = "CNTT",
                diemTrungBinh = 8.7f,
                trangThai = false
            };

            students.Add(test1);
            students.Add(test2);
            students.Add(test3);
        }
    }
}