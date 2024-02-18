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

      public IStatusRepository StatusRepository { get; private set; }

      public IPriorityRepository PriorityRepository { get; private set; }
      public ICommentRepository CommentRepository { get; private set; }

      public UnitOfWork(ApplicationDbContext appDb) {
         _appDb = appDb;
         IssueRepository = new IssueRepository(_appDb);
         ProjectRepository = new ProjectRepository(_appDb);
         StatusRepository = new StatusRepository(_appDb);
         PriorityRepository = new PriorityRepository(_appDb);
         CommentRepository = new CommentRepository(_appDb);
      }

      public void Save() {
         _appDb.SaveChanges();
      }
   }
}
