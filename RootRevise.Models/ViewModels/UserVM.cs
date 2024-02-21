using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RootRevise.Models.ViewModels {
   public class UserVM {
      [ValidateNever]
      public ApplicationUser ApplicationUser { get; set; }
      [ValidateNever]
      public IEnumerable<SelectListItem> RoleList { get; set; }
   }
}
