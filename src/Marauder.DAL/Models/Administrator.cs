using Marauder.Help.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marauder.DAL.Models
{
    public class Administrator
    {
        [Key]
        public int AdministratorID { get; set; }

        [Required(ErrorMessage = "必須輸入{0}")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{0}長度{2}-{1}")]
        [Display(Name = "帳號")]
        public string Account { get; set; }

        [Display(Name = "管理員名稱")]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "必須輸入{0}")]
        [StringLength(256, ErrorMessage = "{0}長度{2}-{1}")]
        [Display(Name = "密碼")]
        public string Password { get; set; }

        public DateTime? CreateDate { get; set; }

        public string LoginIp { get; set; }

        public Nullable<DateTime> LoginTime { get; set; }
    }
}
