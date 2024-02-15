using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace RootRevise.Models {
   public enum IssueStatus {
      Open,
      InProgress,
      Closed
   }

   public enum PriorityLevel {
      Low,
      Medium,
      High
   }
   public class Issue {
      public int IssueId { get; set; }
      public string Title { get; set; }
      public string Description { get; set; }
      public IssueStatus Status { get; set; }
      public PriorityLevel Priority { get; set; }
      public DateTime DateReported { get; set; }
      public DateTime? DueDate { get; set; }
      public int ReporterId { get; set; }
      public int AssigneeId { get; set; }
      [DisplayName("Project")]
      public int ProjectId { get; set; }
      [ForeignKey("ProjectId")]
      [ValidateNever]
      public Project Project { get; set; }
   }
}
