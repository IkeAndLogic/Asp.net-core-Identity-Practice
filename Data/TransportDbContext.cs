    using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class TransportDbContext : IdentityDbContext<ApplicationUser, Role, int>
    {

        public TransportDbContext(DbContextOptions<TransportDbContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contact { get; set; }
        public DbSet<ApplicationUser> User{get;set;}

        //this DbSet will be used to interact with Order table
        public DbSet<Order> Orders { get; set; }

        //this DbSet will be used to interact with Customer table
        public DbSet<Customer> Customers { get; set; }

        ////this DbSet will be used to interact with Employee table
        //public DbSet<Employee> Employees { get; set; }


        //this DbSet will store used to the history of Tractor table and Employee table 
        public DbSet<DriverTractorAssignmentHistory> DriverTractorsAssignmentHistory { get; set; }

        //this DbSet will be used to interact with Tractor table
        public DbSet<Tractor> Tractors { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // this is needed inorder to keep all the default setting of the remaining entity framework
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DriverTractorAssignmentHistory>().HasKey(co => new { co.ApplicationUserId, co.TractorId, co.DateTimeAssigned });

            modelBuilder.Entity<DriverTractorAssignmentHistory>()
            .HasOne(e => e.ApplicationUser)
            .WithMany(c => c.DriverTractorAssignmentHistories)
            .HasForeignKey(trac => trac.TractorId);

            modelBuilder.Entity<DriverTractorAssignmentHistory>()
            .HasOne(trac => trac.Tractor)
            .WithMany(c => c.DriverTractorAssignmentHistories)
            .HasForeignKey(e => e.ApplicationUserId);


        }

    }
}
