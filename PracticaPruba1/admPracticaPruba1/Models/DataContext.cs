using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace admPracticaPruba1.Models
{
    public class DataContext: DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<admPracticaPruba1.Models.Pruba1> Pruba1 { get; set; }
    }
}