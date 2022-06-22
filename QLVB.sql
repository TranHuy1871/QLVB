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
	MaVB int primary key identity,
	TenVB nvarchar (50),
	TrichYeu nvarchar (50),
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
('A','A','7/7/2001','A','A','8/8/2001','A','Van ban di', 'Bao cao'),
('Bb','Bb','9/9/2001','Bb','Bb','10/10/2001','Bb','Van ban den', 'Chi thi'),
('C','A','7/3/2002','C','D','4/5/2002','A','Van ban den', 'Cong van'),
('D','I','7/17/2003','P','A','8/2/2003','A','Van ban di', 'Cong van'),
('H','A','8/17/2004','U','G','8/18/2004','A','Van ban den', 'Chi thi'),
('P','A','2/27/2005','U','H','5/8/2005','A','Van ban di', 'Cong van'),
('E','A','1/2/2006','E','J','9/8/2006','A','Van ban di', 'Bao cao')
go

drop table tb_VanBan