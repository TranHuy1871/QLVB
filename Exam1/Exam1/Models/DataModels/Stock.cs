using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam1.Models.DataModels
{
    [Table("tb_Stock")]
    public class Stock
    {
        [Key]
        public String Ma { get; set; }
        public Double TC { get; set; }
        public Double Tran { get; set; }
        public Double San { get; set; }
        public Double? MuaG3 { get; set; }
        public int? MuaKL3 { get; set; }
        public Double? MuaG2 { get; set; }
        public int? MuaKL2 { get; set; }
        public Double? MuaG1 { get; set; }
        public int? MuaKL1 { get; set; }
        public Double? KhopLenhGia { get; set; }
        public int? KhopLenhKL { get; set; }
        public Double? TileTangGiam { get; set; }
        public Double? BanG1 { get; set; }
        public int? BanKL1 { get; set; }
        public Double? BanG2 { get; set; }
        public int? BanKL2 { get; set; }
        public Double? BanG3 { get; set; }
        public int? BanKL3 { get; set; }
        public int? TongKL { get; set; }
        public Double? MoCua { get; set; }
        public Double? CaoNhat { get; set; }
        public Double? ThapNhat { get; set; }
        public int? NNMua { get; set; }
        public int? NNBan { get; set; }
        public int? Room { get; set; }

        public Stock(string ma, double tC, double tran, double san, double? muaG3, int? muaKL3, double? muaG2, int? muaKL2, double? muaG1, int? muaKL1, double? khopLenhGia, int? khopLenhKL, double? tileTangGiam, double? banG1, int? banKL1, double? banG2, int? banKL2, double? banG3, int? banKL3, int? tongKL, double? moCua, double? caoNhat, double? thapNhat, int? nNMua, int? nNBan, int? room)
        {
            Ma = ma;
            TC = tC;
            Tran = tran;
            San = san;
            MuaG3 = muaG3;
            MuaKL3 = muaKL3;
            MuaG2 = muaG2;
            MuaKL2 = muaKL2;
            MuaG1 = muaG1;
            MuaKL1 = muaKL1;
            KhopLenhGia = khopLenhGia;
            KhopLenhKL = khopLenhKL;
            TileTangGiam = tileTangGiam;
            BanG1 = banG1;
            BanKL1 = banKL1;
            BanG2 = banG2;
            BanKL2 = banKL2;
            BanG3 = banG3;
            BanKL3 = banKL3;
            TongKL = tongKL;
            MoCua = moCua;
            CaoNhat = caoNhat;
            ThapNhat = thapNhat;
            NNMua = nNMua;
            NNBan = nNBan;
            Room = room;
        }

        public Stock()
        {
        }

    }
}
