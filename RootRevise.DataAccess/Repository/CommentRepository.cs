using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RootRevise.DataAccess.Data;
using RootRevise.DataAccess.Repository.IRepository;
using RootRevise.Models;

namespace RootRevise.DataAccess.Repository {
   public class CommentRepository : Repository<Comment>, ICommentRepository {
      private ApplicationDbContext _appDb;
      public CommentRepository(ApplicationDbContext appDb) : base(appDb) {
         _appDb = appDb;
      }

      public void Update(Comment comment) {
         _appDb.Comments.Update(comment);
      }
   }
}
