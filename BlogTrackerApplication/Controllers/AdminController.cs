using DAL;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BlogTracker.Models;

namespace BlogTracker.Controllers
{
    public class AdminController : ApiController
    {
        // GET api/<controller>
        //IRepository<AdminModel> _repo;
        //public AdminController()
        //{
        //    _repo = new Repo<AdminModel>();
        //}
        public UnitOfWork unitOfWork = new UnitOfWork();

        //public IEnumerable<AdminModel> Get()
        //{
        //    var ans = _repo.GetAll();
        //    return ans;
        //}
        // GET api/<controller>/5
        public IEnumerable<AdminInfo> Get()
        {
            var admin = unitOfWork.AdminRepo.GetAll();
            return admin;
        }
        public AdminInfo Get(string id)
        {
            return unitOfWork.AdminRepo.GetByID(id);
        }

        // POST api/<controller>
        public void Post([FromBody] AdminInfo value)
        {
            unitOfWork.AdminRepo.Insert(value);
            unitOfWork.Save();
        }

        // PUT api/<controller>/5
        public void Put([FromBody] AdminInfo value)
        {
            unitOfWork.AdminRepo.Update(value);
            unitOfWork.Save();
        }

        // DELETE api/<controller>/5
        public void Delete(string id)
        {
            unitOfWork.AdminRepo.Delete(id);
            unitOfWork.Save();
        }
    }
}