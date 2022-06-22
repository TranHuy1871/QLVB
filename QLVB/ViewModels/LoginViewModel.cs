using System.ComponentModel.DataAnnotations;

namespace QLVB.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Vui lòng nhập email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Vui lòng nhập password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
