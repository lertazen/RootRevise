using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace RootRevise.Models {
   public class Comment {
      public int CommentId { get; set; }
      public string CommentText { get; set; }
      public DateTime DateCreated { get; set; } = DateTime.Now;
      public DateTime? DateUpdated { get; set; }

      public string AuthorId { get; set; }
      [ForeignKey("AuthorId")]
      public IdentityUser Author { get; set; }

      public int IssueId { get; set; }
      [ForeignKey("IssueId")]
      public Issue Issue { get; set; }
   }
}
