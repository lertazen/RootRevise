using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RootRevise.DataAccess.Data;
using RootRevise.DataAccess.Repository.IRepository;
using RootRevise.Models;

namespace RootRevise.DataAccess.Repository {
   public class IssueRepository : Repository<Issue>, IIssueRepository {
      private ApplicationDbContext _appDb;
      public IssueRepository(ApplicationDbContext appDb) : base(appDb){
         _appDb = appDb;
      }
      public void Update(Issue issue) {
         _appDb.Issues.Update(issue);
      }
   }
}
