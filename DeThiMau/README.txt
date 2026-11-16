DU AN ASP.NET CORE MVC - DE THI MAU 2023

1. DU AN BAM THEO BO KHUNG GOC
- Giao dien goc: Template/index.html trong DeThi_Mau_2023.rar.
- CSS, JavaScript, font va toan bo anh goc duoc giu trong wwwroot.
- Giao dien index.html duoc tach thanh Views/Shared/_Layout.cshtml, _Header.cshtml, _Footer.cshtml va Views/Home/Index.cshtml.
- Danh sach san pham duoc render bang Partial View _DanhSachHangHoa.cshtml.

2. CHUAN BI DATABASE
- Mo SQL Server Management Studio, ket noi (local)\SQLEXPRESS.
- Mo va Execute file Database/QLHangHoa_Create.sql.
- Script tao database QLHangHoa va cac bang LoaiHang, HangHoa, tblAccount theo du lieu mau goc.
- LUU Y: script nay xoa va tao lai cac bang HangHoa, LoaiHang, tblAccount. Hay chi chay khi ban chap nhan khoi tao lai du lieu mau.

3. CAU HINH TEN SINH VIEN
- Mo appsettings.json, sua Student:FullName thanh ho ten day du cua ban.

4. CHUOI KET NOI
- Mac dinh: Server=(local)\SQLEXPRESS;Database=QLHangHoa;Trusted_Connection=True;TrustServerCertificate=True.
- Neu SQL Server cua ban co ten instance khac, sua DefaultConnection trong appsettings.json.
- Kiem tra dich vu SQL Server (SQLEXPRESS) dang Running.

5. CHAY DU AN
- Cai .NET 10 SDK va Visual Studio 2026 co workload ASP.NET and web development.
- Mo QLHangHoaMVC.csproj.
- Cho Visual Studio restore NuGet packages.
- Chon profile https hoac http va nhan F5.

6. CAC YEU CAU DA LAM
- Entity Framework Core ket noi SQL Server.
- Hien thi LoaiHang tren menu.
- Hien thi HangHoa co Gia >= 100.
- Bam loai hang de loc danh sach bang AJAX.
- Them HangHoa; Data Annotations kiem tra Gia 100..5000 va duoi ten anh jpg/png/gif/tiff.

Neu muon hien thi anh san pham khac, dat file anh trong wwwroot/images va nhap dung ten file vao truong Anh.
