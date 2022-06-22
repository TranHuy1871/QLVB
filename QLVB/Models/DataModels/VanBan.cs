using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace QLVB.Models.DataModels
{
    [Table("tb_VanBan")]
    public class VanBan
    {
        [Key]
        public int MaVB { get; set; }
        public string TenVB { get; set; }
        public string TrichYeu { get; set; }
        [DataType(DataType.Date)]
        public DateTime NgayNhan { get; set; } = DateTime.Now;
        public string MaLoai { get; set; }
        public string MaDV { get; set; }
        [DataType(DataType.Date)]
        public DateTime NgayKy { get; set; }
        public string NguoiKy { get; set; }
        public string TrangThai { get; set; }
        public string Kieu { get; set; }
    }
}
