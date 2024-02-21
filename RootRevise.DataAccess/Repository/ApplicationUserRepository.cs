using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RootRevise.DataAccess.Data;
using RootRevise.DataAccess.Repository.IRepository;
using RootRevise.Models;

namespace RootRevise.DataAccess.Repository {
   public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository {
      private readonly ApplicationDbContext _appDb;
      public ApplicationUserRepository(ApplicationDbContext appDb) : base(appDb) {
         _appDb = appDb;
      }

      public void Update(ApplicationUser applicationUser) {
         _appDb.ApplicationUsers.Update(applicationUser);
      }
   }
}
