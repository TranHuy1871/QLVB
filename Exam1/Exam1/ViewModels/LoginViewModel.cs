using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam1.ViewModels
{
    [Table("tb_Users")]
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Vui lòng nhập mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        public bool IsRememberMe { get; set; }
    }
}
