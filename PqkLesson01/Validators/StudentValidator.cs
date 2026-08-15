using System.Text.RegularExpressions;

namespace PqkLesson01
{
    public static class StudentValidator
    {
        public static bool ValidateMaSV(string masv, out string error)
        {
            if (string.IsNullOrWhiteSpace(masv))
            {
                error = "Mã sinh viên không được để trống.";
                return false;
            }

            error = "";
            return true;
        }

        public static bool ValidateHoTen(string hoTen, out string error)
        {
            if (string.IsNullOrWhiteSpace(hoTen))
            {
                error = "Họ tên không được để trống.";
                return false;
            }

            error = "";
            return true;
        }

        public static bool ValidateNgaySinh(string input, out DateTime ngaySinh, out string error)
        {
            ngaySinh = default;
            error = "";

            if (!DateTime.TryParseExact(
                input,
                "dd/MM/yyyy",
                null,
                System.Globalization.DateTimeStyles.None,
                out ngaySinh))
            {
                error = "Ngày sinh không hợp lệ! Vui lòng nhập theo định dạng dd/MM/yyyy.";
                return false;
            }

            if (ngaySinh > DateTime.Today)
            {
                error = "Ngày sinh không thể lớn hơn ngày hiện tại.";
                return false;
            }

            return true;
        }


        public static bool ValidateDiemTrungBinh(
            double diemTrungBinh,
            out string error)
        {
            if (diemTrungBinh < 0 || diemTrungBinh > 10)
            {
                error = "Điểm trung bình phải nằm trong khoảng từ 0 đến 10.";
                return false;
            }

            error = "";
            return true;
        }

        public static bool ValidateEmail(string email, out string error)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                error = "Email không được để trống.";
                return false;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                error = "Email không đúng định dạng.";
                return false;
            }

            error = "";
            return true;
        }
    }
}