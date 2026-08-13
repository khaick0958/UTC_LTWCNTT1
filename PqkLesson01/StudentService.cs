namespace PqkLesson01
{
    internal class StudentService
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pqk Lesson01");
            string choice;
            List<Student> students = new List<Student>()
            {
                new Student { masv = "SV001", hoTen = "Nguyen Van A", ngaySinh = new DateTime(2000, 1, 1), gioiTinh = true, email = "nguyenvana@example.com", soDienThoai = "0123456789", nghanhHoc = "CNTT", diemTrungBinh = 8.5f, trangThai = true } ,
                new Student { masv = "SV002", hoTen = "Tran Thi B", ngaySinh = new DateTime(2001, 2, 2), gioiTinh = false, email = "Chungtrinhj@gmaii.com", soDienThoai = "0987654321", nghanhHoc = "Kinh te", diemTrungBinh = 7.2f, trangThai = true }
            };
        }

        //Thêm sinh viên
        static void ThemSinhVien(List<Student> students)
        {
            Student student = new Student();
            Console.Write("Nhập mã sinh viên: ");
            student.masv = Console.ReadLine();
            Console.Write("Nhập họ và tên: ");
            student.hoTen = Console.ReadLine();
            Console.Write("Nhập ngày sinh: ");
            student.ngaySinh = DateTime.Parse(Console.ReadLine()!);
            Console.Write("Nhập giới tính: ");
            student.gioiTinh = bool.Parse(Console.ReadLine()!);
            Console.Write("Nhập email: ");
            student.email = Console.ReadLine();
            Console.Write("Nhập số điện thoại: ");
            student.soDienThoai = Console.ReadLine();
            Console.Write("Nhập nghành học: ");
            student.nghanhHoc = Console.ReadLine();
            Console.Write("Nhập điểm trung bình: ");
            student.diemTrungBinh = float.Parse(Console.ReadLine()!);
            Console.Write("Nhập trạng thái học tập: ");
            student.trangThai = bool.Parse(Console.ReadLine());
            students.Add(student);
        }

        //Format hiển thị 1 sinh viên
        static void ShowSinhVien(Student student)
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
        static Student? CheckSinhVien(List<Student> students, string maSV)
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

        //Tìm gần đúng theo họ tên
        
        //Cập nhật sinh viên

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
        static float AverageDiemTrungBinh(List<Student> students)
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