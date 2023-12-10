using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viv.Dal.Entities;

namespace Viv.Dal.Context
{
    public class VivDbContext : DbContext
    {
        public VivDbContext() : base("VivDbContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<VivDbContext>());
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasKey(e => new { e.EmployeeNumber, e.Company_Id });

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeNumber)
                .IsRequired();

            //REQUIRE PROPERTIES
        }
    }
}
