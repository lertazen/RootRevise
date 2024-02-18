using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RootRevise.DataAccess.Data;
using RootRevise.DataAccess.Repository.IRepository;

namespace RootRevise.DataAccess.Repository {
   public class Repository<T> : IRepository<T> where T : class {
      private readonly ApplicationDbContext _appDb;
      internal DbSet<T> dbSet;

      public Repository(ApplicationDbContext appDb) {
         _appDb = appDb;
         dbSet = _appDb.Set<T>();
      }

      public void Add(T entity) {
         dbSet.Add(entity);
      }

      public void Delete(T entity) {
         dbSet.Remove(entity);
      }

      public T Get(Expression<Func<T, bool>> predicate, string? includeProperties = null) {
         IQueryable<T> query = dbSet.Where(predicate);
         if (!string.IsNullOrEmpty(includeProperties)) { 
            foreach (var property in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries)) {
               query = query.Include(property);
            }
         }
         return query.FirstOrDefault();
      }

      public IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate, string? includeProperties = null) {
         IQueryable<T> query;
         if(predicate != null) {
            query = dbSet.Where(predicate);
         } else {
            query = dbSet;
         }
         if (!string.IsNullOrEmpty(includeProperties)) { 
            foreach (var property in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries)) {
               query = query.Include(property);
            }
         }
         return query.ToList();
      }
   }
}
