using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootRevise.DataAccess.Repository.IRepository {
   public interface IUnitOfWork {
      IIssueRepository IssueRepository { get; }
      IProjectRepository ProjectRepository { get; }

      void Save();
   }
}
