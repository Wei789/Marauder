namespace Marauder.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sys_lang_key
    {
        [Key]
        public int sys_lang_key_id { get; set; }

        [Required]
        [StringLength(20)]
        public string locale { get; set; }

        [Required]
        [StringLength(100)]
        public string key_major { get; set; }

        [StringLength(100)]
        public string key_minor { get; set; }

        [Required]
        [StringLength(2000)]
        public string text { get; set; }

        public DateTime date_created { get; set; }

        public DateTime? date_modified { get; set; }
    }
}
