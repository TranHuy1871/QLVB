using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLVB.Models.DataModels
{
    [Table("tb_Admin")]
    public class Admin
    {
        [Key]		
		public int MaNV { get; set; }
        [Required]
        public string TenNV { get; set; }
        public string DiaChi { get; set; }
        public string GioiTinh { get; set; }
        public string MaDV { get; set; }
        public string DT { get; set; }
        public string ChucVu { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
