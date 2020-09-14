using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PracticaPruba1.Models
{
    public class DataContext:DbContext
    {
        public DataContext() : base("DefaultConnection")
        { 
        
        }

        public System.Data.Entity.DbSet<PracticaPruba1.Models.Pruba1> Pruba1 { get; set; }
    }
}