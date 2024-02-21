using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootRevise.DataAccess.Repository.IRepository {
   public interface IUnitOfWork {
      IIssueRepository IssueRepository { get; }
      IProjectRepository ProjectRepository { get; }
      IStatusRepository StatusRepository { get; }
      IPriorityRepository PriorityRepository { get; }
      ICommentRepository CommentRepository { get; }
      IApplicationUserRepository ApplicationUserRepository { get; }
      void Save();
   }
}
