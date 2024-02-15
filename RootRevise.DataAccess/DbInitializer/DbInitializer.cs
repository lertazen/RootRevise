using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RootRevise.DataAccess.Data;

namespace RootRevise.DataAccess.DbInitializer {
   public class DbInitializer : IDbInitializer {
      private readonly ApplicationDbContext _appDb;

      public DbInitializer(ApplicationDbContext appDb) {
         _appDb = appDb;
      }

      public void Initialize() {
         try {
            if(_appDb.Database.GetPendingMigrations().Count() > 0) {
               _appDb.Database.Migrate();
            }
         } catch(Exception ex) { }
      }
   }
}
