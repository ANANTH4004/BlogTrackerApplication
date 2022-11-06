
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class EmpRepository : IEmpRepository
    {
        private BlogContext blog;
        public EmpRepository(BlogContext _blog)
        {
           blog = _blog;
        }
        public void DeleteEmp(string email)
        {
            EmpInfo emp = blog.EmpInfos.Find(email);
            blog.EmpInfos.Remove(emp);
        }

        public IEnumerable<EmpInfo> GetALLEmps()
        {
           return blog.EmpInfos.ToList();
        }

        public EmpInfo GetByEmail(string email)
        {
            return blog.EmpInfos.Find(email);
        }

        public void InsertEmp(EmpInfo emp)
        {
           blog.EmpInfos.Add(emp);
        }

        public void Save()
        {
            blog.SaveChanges();
        }


        public void UpdateEmp(EmpInfo emp)
        {
            blog.Entry(emp).State = EntityState.Modified;
        }
    }
}
