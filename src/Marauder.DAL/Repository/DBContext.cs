namespace Marauder.DAL.Repository
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Marauder.DAL.Models;

    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<acct_company> acct_company { get; set; }
        public virtual DbSet<sys_lang_key> sys_lang_key { get; set; }
        public virtual DbSet<sys_setting> sys_setting { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
