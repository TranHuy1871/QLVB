create database ChungKhoan
go

use ChungKhoan
go

create table tb_Users(
	Id int primary key identity,
	Name nvarchar(200),
	Email nvarchar(250),
	[Password] nvarchar(30),
	Temppass nvarchar(30)
)
go

insert into tb_Users values
('tqhuy','demo1@gmail.com','12345678','87654321'),
('abc','demo2@gmail.com','abcdefgh','hgfedcba')
go

create table tb_Stock(
	Ma varchar(10) primary key,
	TC float not null,
	[Tran] float not null,
	San float not null,
	MuaG3 float,
	MuaKL3 int,
	MuaG2 float,
	MuaKL2 int,
	MuaG1 float,
	MuaKL1 int,
	KhopLenhGia float,
	KhopLenhKL int,
	TileTangGiam float,
	BanG1 float,
	BanKL1 int,
	BanG2 float,
	BanKL2 int,
	BanG3 float,
	BanKL3 int,
	TongKL int,
	MoCua float,
	CaoNhat float,
	ThapNhat float,
	NNMua int,
	NNBan int,
	Room int
)
go

--Insert dữ liệu demo
insert into tb_Stock values
('BBT',18.2,21.9,15.5,17.7,2200,18,1500,18.2,6900,18.2,1000,null,18.3,700,18.4,400,18.5,100,1000,18.2,18.2,18.2,null,null,4718200),
('AAA',12.2,22.9,15.5,17.7,200,18.55,1500,18.2,6900,18.2,1000,null,18.3,700,18.4,400,18.5,100,1000,18.2,18.2,18.2,null,null,4718200),
('AAC',8.2,9.9,15.5,17.7,3300,8.95,1500,18.2,6900,18.2,1000,null,18.3,700,18.4,400,18.5,100,1000,18.2,18.2,18.2,null,null,4718200),
('AME',19.2,20.9,15.5,17.7,1230,18.5,1500,18.2,6900,18.2,1000,null,18.3,700,18.4,400,18.5,100,1000,18.2,18.2,18.2,null,null,4718200),
('HPG',17.2,20.9,15.5,17.7,9990,22.15,1500,18.2,6900,18.2,1000,null,18.3,700,18.4,400,18.5,100,1000,18.2,18.2,18.2,null,null,4718200),
('FTS',16.2,16.9,15.5,17.7,2340,15.35,1500,18.2,6900,18.2,1000,null,18.3,700,18.4,400,18.5,100,1000,18.2,18.2,18.2,null,null,4718200),
('ACE',30.2,31.9,15.5,17.7,5230,17.3,1500,18.2,6900,18.2,1000,null,18.3,700,18.4,400,18.5,100,1000,18.2,18.2,18.2,null,null,4718200),
('AAM',11.2,11.9,15.5,17.7,1000,9.6,1500,18.2,6900,18.2,1000,null,18.3,700,18.4,400,18.5,100,1000,18.2,18.2,18.2,null,null,4718200),
('ACM',3.2,5.9,15.5,17.7,220,5.6,1500,18.2,6900,18.2,1000,null,18.3,700,18.4,400,18.5,100,1000,18.2,18.2,18.2,null,null,4718200),
('API',8.2,10.9,15.5,17.7,2205,23.4,1500,18.2,6900,18.2,1000,null,18.3,700,18.4,400,18.5,100,1000,18.2,18.2,18.2,null,null,4718200),
('FDG',29.2,30.1,15.5,17.7,1900,18,1500,18.2,6900,18.2,1000,null,18.3,700,18.4,400,18.5,100,1000,18.2,18.2,18.2,null,null,4718200)
go

update tb_Stock set TileTangGiam = -1.9 where Ma in ('AAA','FDG','AAM')
go 
update tb_Stock set TileTangGiam = 2.9 where Ma in ('ACE','ACM','API')
go
update tb_Stock set NNBan = 18200, NNMua = 1200 where Ma in ('FTS','HPG','AME')
go
delete from tb_Stock where Ma = 'FDG'
go


--Procedure  tb_Users

--Get All
create proc SP_Get_All_User
as
Select Id,Name,Email,Password,Temppass from tb_Users
go

--Get by id
create proc SP_Get_User_By_Id
	(@Id int)
as
Select Id,Name,Email,Password,Temppass from tb_Users where Id = @Id
go

--Insert
create proc SP_Insert_User
	(
	@Name nvarchar(200),
	@Email nvarchar(250),
	@Password nvarchar(30),
	@Temppass nvarchar(30)
	)
as
Insert into tb_Users(Name,Email,Password,Temppass) values
	(@Name,@Email,@Password,@Temppass)
go

--Update
create proc SP_Update_User
	(
	@Id int,
	@Name nvarchar(200),
	@Email nvarchar(250),
	@Password nvarchar(30),
	@Temppass nvarchar(30)
	)
as
Update tb_Users set Name = @Name, Email = @Email, Password = @Password, Temppass = @Temppass where Id = @Id
go

--Delete
create proc SP_Delete_User
	(@Id int)
as
delete tb_Users where Id = @Id
go

--Thủ tục cho bảng tb_Stock 

--Get all
create proc SP_GET_STOCK
as
begin
	select Ma ,TC ,[Tran] ,San ,MuaG3 ,MuaKL3 ,MuaG2 ,MuaKL2 ,MuaG1 ,MuaKL1 ,
	KhopLenhGia ,KhopLenhKL ,TileTangGiam ,BanG1 ,BanKL1 ,BanG2 ,BanKL2 ,BanG3 ,BanKL3 ,
	TongKL ,MoCua ,CaoNhat ,ThapNhat ,NNMua ,NNBan ,Room from tb_Stock 
end
go 

--Get by Mã
create proc SP_GET_DETAILS_tb_Stock_By_Ma
	(@Id varchar(10) )
as
begin
select Ma ,TC ,[Tran] ,San ,MuaG3 ,MuaKL3 ,MuaG2 ,MuaKL2 ,MuaG1 ,MuaKL1 ,
	KhopLenhGia ,KhopLenhKL ,TileTangGiam ,BanG1 ,BanKL1 ,BanG2 ,BanKL2 ,BanG3 ,BanKL3 ,
	TongKL ,MoCua ,CaoNhat ,ThapNhat ,NNMua ,NNBan ,Room from tb_Stock where Ma = @Id
end
go 

--Insert
create proc SP_CREATE_STOCK
	(
	@Ma varchar(10),
	@TC float,
	@Tran float,
	@San float,
	@MuaG3 float,
	@MuaKL3 int,
	@MuaG2 float,
	@MuaKL2 int,
	@MuaG1 float,
	@MuaKL1 int,
	@KhopLenhGia float,
	@KhopLenhKL int,
	@TileTangGiam float,
	@BanG1 float,
	@BanKL1 int,
	@BanG2 float,
	@BanKL2 int,
	@BanG3 float,
	@BanKL3 int,
	@TongKL int,
	@MoCua float,
	@CaoNhat float,
	@ThapNhat float,
	@NNMua int,
	@NNBan int,
	@Room int
	)
	as
	begin 
		insert into tb_Stock values (@Ma,@TC,@Tran,@San,@MuaG3,@MuaKL3,@MuaG2,
		@MuaKL2,@MuaG1,@MuaKL1,@KhopLenhGia,@KhopLenhKL,@TileTangGiam,@BanG1,@BanKL1,
		@BanG2,@BanKL2,@BanG3,@BanKL3,@TongKL,@MoCua,@CaoNhat,@ThapNhat,@NNMua,@NNBan,@Room)
end
go

--Update
create proc SP_UPDATE_STOCK
	(
	@MaCu varchar(10),
	@Ma varchar(10),
    @TC float,
    @Tran float,
    @San float,
    @MuaG3 float,
    @MuaKL3 int,
    @MuaG2 float,
    @MuaKL2 int,
    @MuaG1 float,
    @MuaKL1 int,
    @KhopLenhGia float,
    @KhopLenhKL int,
    @TileTangGiam float,
    @BanG1 float,
    @BanKL1 int,
    @BanG2 float,
    @BanKL2 int,
    @BanG3 float,
    @BanKL3 int,
    @TongKL int,
    @MoCua float,
    @CaoNhat float,
    @ThapNhat float,
    @NNMua int,
    @NNBan int,
    @Room int
	)
	as
	begin
		UPDATE tb_Stock 
		SET 
		Ma = @Ma, 
		TC = @TC, 
		[Tran] = @Tran,
		San = @San,
		MuaG3 = @MuaG3,
		MuaKL3 = @MuaKL3,
		MuaG2 = @MuaG2,
		MuaKL2 = @MuaKL2,
		MuaG1 = @MuaG1,
		MuaKL1 = @MuaKL1,
		KhopLenhGia = @KhopLenhGia,
		KhopLenhKL = @KhopLenhKL,
		TileTangGiam = @TileTangGiam,
		BanG1 = @BanG1,
		BanKL1 = @BanKL1, 
		BanG2 = @BanG2, 
		BanKL2 = @BanKL2, 
		BanG3 = @BanG3, 
		BanKL3 = @BanKL3,
		TongKL = @TongKL,
		MoCua = @MoCua,
		CaoNhat = @CaoNhat,
		ThapNhat = @ThapNhat,
		NNMua = @NNMua,
		NNBan = @NNBan,
		Room = @Room
		WHERE Ma = @MaCu
	end
go

--Delete
create proc SP_DELETE_STOCK
	(@Ma varchar(10))
as
delete tb_Stock where Ma = @Ma
go

--View
create view viewBangDienTu
as
select Ma,TC,[Tran],San from tb_Stock 
go

create view viewUser
as
select Name,Email from tb_Users
go

select *from [viewBangDienTu]