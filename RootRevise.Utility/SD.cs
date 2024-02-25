using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootRevise.Utility {
   public class SD {
      public const string Role_Admin = "Admin";
      public const string Role_Developer = "Developer";
      public const string Role_Reporter = "Reporter";

      public enum IssueStatus {
         Open = 1,
         InProgress = 2,
         Closed = 3
      }

      public enum PriorityLevel {
         Low = 1,
         Medium = 2,
         High = 3
      }
   }
}
