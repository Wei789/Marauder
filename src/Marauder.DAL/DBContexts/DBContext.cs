namespace Marauder.DAL.DBContexts
{
    using Marauder.DAL.Models;
    using System.Data.Entity;

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
