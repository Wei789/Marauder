namespace Marauder.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sys_setting
    {
        [Key]
        public int sys_setting_id { get; set; }

        public int? acct_company_id { get; set; }

        public int? acct_user_id { get; set; }

        [Required]
        [StringLength(100)]
        public string key { get; set; }

        [Required]
        [StringLength(200)]
        public string value { get; set; }

        public DateTime date_created { get; set; }

        public DateTime? date_modified { get; set; }

        public virtual acct_company acct_company { get; set; }
    }
}
