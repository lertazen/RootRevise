using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RootRevise.Models;

namespace RootRevise.DataAccess.Data {
   public class ApplicationDbContext : IdentityDbContext<IdentityUser> {
      public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

      public DbSet<Issue> Issues { get; set; }
      public DbSet<Project> Projects { get; set; }
      public DbSet<Status> Statuss { get; set; }
      public DbSet<Priority> Prioritys { get; set; }
      public DbSet<Comment> Comments { get; set; }
      public DbSet<ApplicationUser> ApplicationUsers { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder) {
         base.OnModelCreating(modelBuilder);

         modelBuilder.Entity<Project>().HasData(
            new Project {
               ProjectId = 1,
               Name = "Testing Project",
               Description = "This is a testing project"
            }
         );

         modelBuilder.Entity<Status>().HasData(
            new Status {
               StatusId = 1,
               Name = "Open",
            }, 
            new Status {
               StatusId = 2,
               Name = "InProgress",
            },
            new Status {
               StatusId= 3,
               Name = "Closed",
            }
         );

         modelBuilder.Entity<Priority>().HasData(
            new Priority {
               PriorityId = 1,
               Name = "Low",
            },
            new Priority {
               PriorityId = 2,
               Name = "Medium",
            },
            new Priority {
               PriorityId = 3,
               Name = "High",
            }
         );
      }
   }
}
