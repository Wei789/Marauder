using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Marauder.DAL.Repository;

namespace Marauder.DAL.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<DBContext>
    {
        protected override void Seed(DBContext context)
        {
            
        }
    }
}