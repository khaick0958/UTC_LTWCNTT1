using System;

namespace PqkLesson01
{
    public class Student
    {
        public string masv { get; set; } = string.Empty;
        public string hoTen{ get; set; } = string.Empty;
        public DateTime ngaySinh { get; set; }
        public bool gioiTinh { get; set; }
        public string email { get; set; } = string.Empty;
        public string soDienThoai { get; set; } = string.Empty;
        public string nghanhHoc { get; set; } = string.Empty;
        public float diemTrungBinh { get; set;}
        public bool trangThai { get; set; }
    }
}