using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RootRevise.Models.ViewModels {
   public class IssueDetailsVM {
      public Issue Issue { get; set; }
      [ValidateNever]
      public string ReturnUrl { get; set; }
   }
}
