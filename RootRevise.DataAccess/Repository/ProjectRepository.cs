using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RootRevise.DataAccess.Data;
using RootRevise.DataAccess.Repository.IRepository;
using RootRevise.Models;

namespace RootRevise.DataAccess.Repository {
   public class ProjectRepository : Repository<Project>, IProjectRepository{
      private ApplicationDbContext _appDb;

      public ProjectRepository(ApplicationDbContext appDb) : base(appDb) { 
         _appDb = appDb;
      }

      public void Update(Project project) {
         _appDb.Projects.Update(project);
      }
   }
}
