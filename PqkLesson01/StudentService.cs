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

        //Hiển thị danh sách
        static void HienThiDanhSach(List<Student> students)
        {
            Console.WriteLine("Danh sách sinh viên:");
            foreach (var student in students)
            {
                Console.WriteLine($"Mã sinh viên: {student.masv}, Họ tên: {student.hoTen}, Ngày sinh: {student.ngaySinh.ToString("dd/MM/yyyy")}, Giới tính: {(student.gioiTinh ? "Nam" : "Nữ")}, Email: {student.email}, Số điện thoại: {student.soDienThoai}, Ngành học: {student.nghanhHoc}, Điểm trung bình: {student.diemTrungBinh}, Trạng thái: {(student.trangThai ? "Đang học" : "Nghỉ học")}});
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
                    Console.WriteLine($"Mã sinh viên: {student.masv}, Họ tên: {student.hoTen}, Ngày sinh: {student.ngaySinh.ToString("dd/MM/yyyy")}, Giới tính: {(student.gioiTinh ? "Nam" : "Nữ")}, Email: {student.email}, Số điện thoại: {student.soDienThoai}, Ngành học: {student.nghanhHoc}, Điểm trung bình: {student.diemTrungBinh}, Trạng thái: {(student.trangThai ? "Đang học" : "Nghỉ học")}});
                    trangThai = true;
                    break;
                }
            }

            if (!trangThai) Console.WriteLine("Không tìm thấy kết quả!");
        }
    }
}