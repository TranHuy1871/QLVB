create database QLVB
go

use QLVB
go 

create table tb_Admin(
	MaNV int primary key identity,
	TenNV nvarchar(30),
	DiaChi nvarchar(50),
	GioiTinh nvarchar(10),
	MaDV nvarchar(10),
	DT varchar(11),
	ChucVu nvarchar(15),
	Email nvarchar(50),
	Password nvarchar(50)
)
go

insert into tb_Admin 
values ('Admin', 'Bắc Ninh', 'Nam', '9', '0987654321', 'Quản lý', 'admin@gmail.com', '12345678')
go

create table tb_VanBan(
	ID int primary key identity,
	MaVB nvarchar(50),
	TenVB nvarchar (50),
	TrichYeu nvarchar (255),
	NgayNhan datetime,
	MaLoai nvarchar (10),
	MaDV nvarchar (10),
	NgayKy datetime,
	NguoiKy nvarchar(50),

	TrangThai nvarchar(19),
	Kieu nvarchar(19),
)
go


insert into tb_VanBan values
('Văn bản thực hiện','A','7/7/2001','A','BGD','8/8/2001','Trần Văn A','Van ban di', 'Bao cao'),
('Văn bản A','Bb','9/9/2001','Bb','BGD','10/10/2001','Nguyễn Thị Bb','Van ban den', 'Chi thi'),
('Văn bản C','A','7/3/2002','C','BGD','4/5/2002','Lê Văn C','Van ban den', 'Cong van'),
('Văn bản D','I','7/17/2003','P','BGD','8/2/2003','Nguyễn Văn D','Van ban di', 'Cong van'),
('Văn bản H','A','8/17/2004','U','BGD','8/18/2004','Đàm Đức E','Van ban den', 'Chi thi'),
('Văn bản P','A','2/27/2005','U','BGD','5/8/2005','Ngô Thị F','Van ban di', 'Cong van'),
('Văn bản E','A','1/2/2006','E','BGD','9/8/2006','Trần Quang Huy','Van ban di', 'Bao cao')
go

drop table tb_VanBan