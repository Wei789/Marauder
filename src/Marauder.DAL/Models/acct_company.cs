namespace Marauder.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class acct_company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public acct_company()
        {
            sys_setting = new HashSet<sys_setting>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int acct_company_id { get; set; }

        [Required]
        [StringLength(300)]
        public string name { get; set; }

        [Required]
        [StringLength(200)]
        public string code { get; set; }

        [Required]
        [StringLength(300)]
        public string display_name { get; set; }

        [StringLength(300)]
        public string contact { get; set; }

        [StringLength(300)]
        public string title { get; set; }

        [StringLength(1000)]
        public string note { get; set; }

        public DateTime date_created { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sys_setting> sys_setting { get; set; }
    }
}
