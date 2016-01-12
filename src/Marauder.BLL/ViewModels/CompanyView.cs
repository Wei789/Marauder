namespace Marauder.BLL.ViewModels
{
    using Marauder.DAL.Models;
    using System;
    using System.Collections.Generic;

    public partial class CompanyView
    {
        public CompanyView()
        {
            sys_setting = new HashSet<sys_setting>();
        }

        public int acct_company_id { get; set; }

        public string name { get; set; }

        public string code { get; set; }

        public string display_name { get; set; }

        public string contact { get; set; }

        public string title { get; set; }

        public string note { get; set; }

        public DateTime date_created { get; set; }

        public virtual ICollection<sys_setting> sys_setting { get; set; }
    }
}
