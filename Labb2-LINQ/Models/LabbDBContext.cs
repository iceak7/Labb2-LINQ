using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labb2_LINQ.Models
{
    public class LabbDBContext : DbContext
    {
        public DbSet<Elev> Elever { get; set; }
        public DbSet<Kurs> Kurser { get; set; }
        public DbSet<Lärare> Lärare { get; set; }
        public DbSet<Ämne> Ämnen { get; set; }
        public DbSet<ElevKurs> ElevKurs { get; set; }
        public DbSet<LärareKurs> LärareKurs { get; set; }
        public DbSet<ÄmneKurs> ÄmneKurs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-JCAKF9L;Initial Catalog = Labb2LINQ;Integrated Security = True;");
        }

    }
}
