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
   public class ApplicationDbContext : IdentityDbContext<IdentityUser>{
      public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

      public DbSet<Issue> Issues { get; set; }
      public DbSet<Project> Projects { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder) {
         base.OnModelCreating(modelBuilder);

         modelBuilder.Entity<Issue>().HasData(
            new Issue {
               IssueId = 1,
               Title = "Test",
               Description = "This is a test issue",
               Status = IssueStatus.Open,
               Priority = PriorityLevel.High,
               DateReported = DateTime.Now,
               DueDate = DateTime.Now.AddDays(10),
               ReporterId = 1,
               AssigneeId = 1,
               ProjectId = 1,
            }
         );

         modelBuilder.Entity<Project>().HasData(
            new Project {
               ProjectId = 1,
               Name = "Testing Project",
            }
         );
      }
   }
}
