
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IEmpRepository
    {
        IEnumerable<EmpInfo> GetALLEmps();
        EmpInfo GetByEmail(string email);
        void InsertEmp(EmpInfo emp);
        void UpdateEmp(EmpInfo emp);
        void DeleteEmp(string email);
        void Save();

    }
}
