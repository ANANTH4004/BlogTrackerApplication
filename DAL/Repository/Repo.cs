
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetByID(object id);
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(object id);
        void Save();
    }

    public class Repo<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private BlogContext db;
        DbSet<TEntity> dbset;
        public Repo(BlogContext context)
        {
            db = context;
            dbset = db.Set<TEntity>();
        }
        public void Delete(object id)
        {
            TEntity obj = dbset.Find(id);
            dbset.Remove(obj);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return dbset.ToList();
        }
        public TEntity GetByID(object id)
        {
            TEntity obj = dbset.Find(id);
            return obj;
        }
        public void Insert(TEntity obj)
        {
            dbset.Add(obj);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.db != null)
                {
                    this.db.Dispose();
                    this.db = null;
                }
            }
        }
    }
}
