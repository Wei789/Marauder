using System.ComponentModel.DataAnnotations;

namespace Marauder.BLL.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage="必填")]
        [StringLength(20, MinimumLength = 4, ErrorMessage="{2}到{1} 長度")]
        [Display(Name="帳號")]
        public string Account { get; set; }

        [Required(ErrorMessage = "必填")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "{2}到{1} 長度")]
        [Display(Name = "使用者名稱")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "必填")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{2}到{1} 長度")]
        [Display(Name = "使用者密碼")]
        public string Password { get; set; }

        [Required(ErrorMessage = "必填")]
        [Compare("Password", ErrorMessage = "輸入密碼不一致")]
        [Display(Name = "確認密碼")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "必填")]
        [Display(Name = "電子郵件")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email格式不正確")]
        public string Email { get; set; }

        [Required(ErrorMessage = "必填")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "驗證碼不正確")]
        [Display(Name = "驗證碼")]
        public string VerificationCode { get; set; }
    }
}
