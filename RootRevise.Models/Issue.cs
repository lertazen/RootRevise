using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace RootRevise.Models {
   public class Issue {
      public int IssueId { get; set; }
      public string Title { get; set; }
      public string Description { get; set; }
      public DateTime DateReported { get; set; }
      public DateTime? DueDate { get; set; }

      [DisplayName("Status")]
      public int StatusId { get; set; }
      [ForeignKey("StatusId")]
      [ValidateNever]
      public Status Status { get; set; }

      [DisplayName("Priority")]
      public int PriorityId { get; set; }
      [ForeignKey("PriorityId")]
      [ValidateNever]
      public Priority Priority { get; set; }

      [DisplayName("Project")]
      public int ProjectId { get; set; }
      [ForeignKey("ProjectId")]
      [ValidateNever]
      public Project Project { get; set; }

      public string ReporterId { get; set; }
      [ForeignKey("ReporterId")]
      [ValidateNever]
      public ApplicationUser Reporter { get; set; }

      [DisplayName("Assignee")]
      public string AssigneeId { get; set; }
      [ForeignKey("AssigneeId")]
      [ValidateNever]
      public ApplicationUser Assignee { get; set; }
   }
}
