using Microsoft.EntityFrameworkCore;
using Savills.Data;
using System;

namespace Savills.DB
{
    public class SavillsDbContext : DbContext
    {
        public DbSet<S1> S1 { get; set; } 
        public DbSet<S2> S2 { get; set; }
        public DbSet<Match> Matches { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\;Database=Savills;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
