using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RootRevise.DataAccess.Data;
using RootRevise.DataAccess.Repository.IRepository;

namespace RootRevise.DataAccess.Repository {
   public class UnitOfWork : IUnitOfWork {
      private ApplicationDbContext _appDb;
      public IIssueRepository IssueRepository { get; private set; }
      public IProjectRepository ProjectRepository { get; private set; }

      public UnitOfWork(ApplicationDbContext appDb) {
         _appDb = appDb;
         IssueRepository = new IssueRepository(_appDb);
         ProjectRepository = new ProjectRepository(_appDb);
      }

      public void Save() {
         _appDb.SaveChanges();
      }
   }
}
