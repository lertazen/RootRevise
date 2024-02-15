using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RootRevise.Models;

namespace RootRevise.DataAccess.Repository.IRepository {
   public interface IIssueRepository : IRepository<Issue> {
      void Update(Issue issue);
   }
}
