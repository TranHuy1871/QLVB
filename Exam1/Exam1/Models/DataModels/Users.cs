using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam1.Models.DataModels
{
    [Table("tb_Users")]
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Temppass { get; set; }
    }
}
