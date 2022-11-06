using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BlogContext : DbContext
    {
        public BlogContext() : base("BlogTracker")
        {
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer<BlogContext>(new BlogInitializer());
        }
        public virtual DbSet<EmpInfo> EmpInfos { get; set; }
        public virtual DbSet<AdminInfo> AdminInfos { get; set; }
        public virtual DbSet<BlogInfo> BlogInfos { get; set; }
    }
}
