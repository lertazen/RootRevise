using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RootRevise.DataAccess.Data;
using RootRevise.DataAccess.Repository.IRepository;
using RootRevise.Models;

namespace RootRevise.DataAccess.Repository {
   public class StatusRepository : Repository<Status>, IStatusRepository {
      private ApplicationDbContext _appDb;
      public StatusRepository(ApplicationDbContext appDb) : base(appDb) {
         _appDb = appDb;
      }
   }
}
