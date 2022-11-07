using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UnitOfWork : IDisposable
    {
        private BlogContext blog = new BlogContext();
        private Repo<EmpInfo> empRepo;
        private Repo<AdminInfo> adminRepo;
        private Repo<BlogInfo> blogRepo;
        public Repo<EmpInfo> EmpRepo { get { 
                if(this.empRepo == null)
                {
                    this.empRepo = new Repo<EmpInfo>(blog);
                }
                return empRepo;
            } 
        }
        public Repo<AdminInfo> AdminRepo
        {
            get
            {
                if (this.adminRepo == null)
                {
                    this.adminRepo = new Repo<AdminInfo>(blog);
                }
                return adminRepo;
            }
        }
        public Repo<BlogInfo> BlogRepo
        {
            get
            {
                if (this.blogRepo == null)
                {
                    this.blogRepo = new Repo<BlogInfo>(blog);
                }
                return blogRepo;
            }
        }
        public void Save()
        {
            blog.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    blog.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
