using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Coop.Repository
{
    public abstract class BaseRepository<TContext, TModel> : IRepository<TModel> where TContext : BaseContext where TModel : class
    {
        protected DbSet<TModel> DbSet;
        protected TContext Context;
        protected BaseRepository(TContext context)
        {
            DbSet = context.Set<TModel>();
            Context = context;
        }

        public void RefLoad(TModel model,string refName)
        {
            Context.Set<TModel>().Attach(model);
            Context.Entry(model).Reference(refName).Load();
        }

        public void CollectionLoad(TModel model, string collectionName)
        {
            Context.Set<TModel>().Attach(model);
            Context.Entry(model).Collection(collectionName).Load();
        }

        public void DataLoad(TModel model, string[] collectionNames)
        {
            Context.Set<TModel>().Attach(model);
            foreach (var collection in collectionNames)
            {
                Context.Entry(model).Collection(collection).Load();
            }
        }

        public TModel CollectionLoadandGetById(int id, string collectionName)
        {
            var item = DbSet.Find(id);
            Context.Entry(item).Collection(collectionName).Load();
            return item; 
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

        public DbQuery<TModel> Include(string str)
        {
            return DbSet.Include(str);
        }

        public void Create(TModel item)
        {
            DbSet.Add(item);
            SaveChanges();
        }

        public void UpdateById(TModel model,int id)
        {
            Context.Entry(model).State = EntityState.Modified;
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