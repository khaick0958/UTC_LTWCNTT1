# Bài thực hành 4 - Data Access với Entity Framework Core

Project ASP.NET Core MVC cho Visual Studio 2026, target .NET 10.

## Chức năng
- Code First: Entity Framework Core tạo database SQL Server.
- Các model: `Major`, `Learner`, `Course`, `Enrollment`.
- `SchoolContext` kế thừa `DbContext`.
- `DbInitializer` tạo database và dữ liệu mẫu.
- CRUD cho Learner: danh sách/tìm kiếm, thêm, sửa, xóa có xác nhận.
- Giao diện Management System với menu trái và bảng danh sách.

## Chạy project
1. Cài .NET 10 SDK và workload ASP.NET/Web development nếu cần.
2. Mở `Lab4_MVC_EFCore.csproj` bằng Visual Studio 2026.
3. Kiểm tra SQL Server/LocalDB đã được cài và chạy.
4. Nếu cần, sửa `ConnectionStrings:SchoolContext` trong `appsettings.json`.
   Mặc định dùng SQL Server LocalDB:
   `Server=(localdb)\MSSQLLocalDB;Database=SchoolContext;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True`
5. Chạy bằng Ctrl+F5.

## Nếu dùng SQL Server Express
Đổi connection string thành ví dụ:
`Server=.\SQLEXPRESS;Database=SchoolContext;Trusted_Connection=True;TrustServerCertificate=True`

Lưu ý: project dùng `EnsureCreated()` để tạo database cho bài thực hành. Nếu đã có database cùng tên với schema cũ, hãy xóa database đó trước khi chạy lại hoặc đổi tên database trong connection string.
