using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Coop.Repository
{
    public abstract class BaseRepository<TContext,TModel>:IRepository<TModel> where TContext:BaseContext where TModel:class
    {
        protected DbSet<TModel> DbSet;
        protected TContext Context;
        protected BaseRepository(TContext context)
        {
            DbSet = context.Set<TModel>();
            Context = context;
        }

        public List<TModel> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual TModel GetById(int id)
        {
            var item = DbSet.Find(id);
            return item;
        }

        public void Create(TModel item)
        {
            DbSet.Add(item);
            SaveChanges();
        }

        public void UpdateById(TModel model,int id)
        {
            var item = DbSet.Find(id);
            item = model;
            Context.SaveChanges();
        }

        public void Delete(TModel item)
        {
            DbSet.Remove(item);
            SaveChanges();
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}