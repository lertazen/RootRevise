﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RootRevise.DataAccess.Data;
using RootRevise.DataAccess.Repository.IRepository;
using RootRevise.Models;

namespace RootRevise.DataAccess.Repository {
   public class PriorityRepository : Repository<Priority>, IPriorityRepository {
      private ApplicationDbContext _appDb;
      public PriorityRepository(ApplicationDbContext appDb) : base(appDb) {
         _appDb = appDb;
      }

   }
}
