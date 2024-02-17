using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RootRevise.Models.ViewModels {
   public class IssueVM {
      public Issue Issue { get; set; }
      [ValidateNever]
      public IEnumerable<SelectListItem> ProjectList { get; set; }
      [ValidateNever]
      public IEnumerable<SelectListItem> StatusList { get; set; }
      [ValidateNever]
      public IEnumerable<SelectListItem> PriorityList { get; set; }
   }
}
