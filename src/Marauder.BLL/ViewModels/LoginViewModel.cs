using System.ComponentModel.DataAnnotations;

namespace Marauder.BLL.ViewModels
{
    public class LoginViewModel
    {
        public int AdministratorID { get; set; }

        [StringLength(20, MinimumLength = 2, ErrorMessage = "{0}長度{2}-{1}")]
        [Display(Name = "帳號")]
        [Required]
        public string Account { get; set; }

        [StringLength(256, ErrorMessage = "{0}長度{2}-{1}")]
        [Display(Name = "密碼")]
        [Required]
        public string Password { get; set; }
    }
}
