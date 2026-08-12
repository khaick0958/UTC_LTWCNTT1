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
                new Student { masv = "SV001", hoTen = "Nguyen Van A", ngaySinh = new DateTime(2000, 1, 1), gioiTinh = true, email = "nguyenvana@example.com", soDienThoai = "0123456789", nganhHoc = "CNTT", diemTrungBinh = 8.5f, trangThai = true } ,
                new Student { masv = "SV002", hoTen = "Tran Thi B", ngaySinh = new DateTime(2001, 2, 2), gioiTinh = false, email = "Chungtrinhj@gmaii.com", soDienThoai = "0987654321", nganhHoc = "Kinh te", diemTrungBinh = 7.2f, trangThai = true }
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
            student.ngaySinh = Console.ReadLine();
            Console.Write("Nhập giới tính: ");
            student.gioiTinh = Console.ReadLine();
            Console.Write("Nhập email: ");
            student.email = Console.ReadLine();
            Console.Write("Nhập số điện thoại: ");
            student.soDienThoai = Console.ReadLine();
            Console.Write("Nhập nghành học: ");
            student.nghanhHoc = Console.ReadLine();
            Console.Write("Nhập điểm trung bình: ");
            student.diemTrungBinh = Console.ReadLine();
            Console.Write("Nhập trạng thái học tập: ");
            student.trangThai = Console.ReadLine();
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

        //Tìm sinh viên theo mã
        static void TimSinhVienTheoMaSV(List<Student> students)
        {
            bool trangThai = false;
            string masv;
            Console.Write("Nhập mã sinh viên cần tìm: ");
            masv = Console.ReadLine();
            Console.Write("Kết quả: ");

            foreach (var student in students)
            {
                if (student.masv == masv)
                {
                    ShowSinhVien(student);
                    trangThai = true;
                    break;
                }
            }

            if (!trangThai) Console.WriteLine("Không tìm thấy kết quả!");
        }

        //Tìm gần đúng theo họ tên
        
        //Cập nhật sinh viên

        //Xóa sinh viên

        //Sắp xếp theo họ tên

        //Sắp xếp theo điểm trung bình

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
    }
}