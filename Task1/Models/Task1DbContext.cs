using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Task1.Models
{
    public class Task1DbContext :DbContext
    {
        
        public DbSet<ChangeRequestForm> ChangeRequestForms { get; set; }
       
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Task01;Trusted_Connection=True;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChangeRequestForm>(entity =>
            {
                entity.HasIndex(e => e.id)
                    .IsUnique();
            });
        }
    }
}
