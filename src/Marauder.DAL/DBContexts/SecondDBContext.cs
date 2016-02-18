namespace Marauder.DAL.DBContexts
{
    using Marauder.DAL.Models;
    using System.Data.Entity;

    public partial class SecondDBContext : DbContext
    {
        public SecondDBContext()
            : base("name=SecondDBContext")
        {
        }

        public virtual DbSet<SecondDbA> secondDbA { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
