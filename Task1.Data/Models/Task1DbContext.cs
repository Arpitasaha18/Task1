using Microsoft.EntityFrameworkCore;

namespace Task1.Data.Models
{
    public class Task1DbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<ChangeRequestForm> ChangeRequestForms { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Task01;Trusted_Connection=True;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Unique index setup for ChangeRequestForm
            // modelBuilder.Entity<ChangeRequestForm>(entity =>
            //{
            //   entity.HasIndex(e => e.id).IsUnique();
            // });

            // Ensure that Employee has a foreign key relationship with Department
            modelBuilder.Entity<Employee>(e =>
            {
                e.HasIndex(e => e.Id).IsUnique();
                e.HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ChangeRequestForm>(e =>
            {
                e.HasIndex(e => e.Id).IsUnique();
                e.HasOne(e => e.Employee)
                .WithMany(d => d.ChangeRequestForms)
                .HasForeignKey(e => e.EmpId)
                .OnDelete(DeleteBehavior.Cascade);
            });


        }

    }
}
