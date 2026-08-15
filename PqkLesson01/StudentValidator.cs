using System.Text.RegularExpressions;

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