using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;

namespace BlogTracker.Controllers
{
    public class EmpController : ApiController
    {
        //IRepository<EmpInfo> _repository;
        //public EmpController()
        //{
        //    _repository = new Repo<EmpInfo>();
        //}
        //private IEmpRepository empRepository;
        //public EmpController()
        //{
        //    this.empRepository = new EmpRepository(new BlogContext());
        //}
        //// GET api/<controller>
        //public IEnumerable<EmpInfo> Get()
        //{
        //    var ans =  empRepository.GetALLEmps();
        //    return ans;
        //}
        //public IEnumerable<EmpInfo> Get()
        //{
        //    var ans = _repository.GetAll();
        //    return ans;
        //}
        public UnitOfWork unitOfWork = new UnitOfWork();
        public IEnumerable<EmpInfo> Get()
        {
            var ans = unitOfWork.EmpRepo.GetAll();
            return ans;
        }
        public EmpInfo Get(string id)
        {
            return unitOfWork.EmpRepo.GetByID(id);
        }
        public void Post([FromBody] EmpInfo value)
        {
            unitOfWork.EmpRepo.Insert(value);
            unitOfWork.Save();
        }
        public void Put([FromBody] EmpInfo value)
        {
            unitOfWork.EmpRepo.Update(value);
            unitOfWork.Save();
        }
        public void Delete(string id)
        {
            unitOfWork.EmpRepo.Delete(id);
            unitOfWork.Save();
        }
    }
}