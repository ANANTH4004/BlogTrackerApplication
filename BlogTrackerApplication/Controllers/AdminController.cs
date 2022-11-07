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
        public UnitOfWork unitOfWork = new UnitOfWork();
        public IEnumerable<AdminInfo> Get()
        {
            var admin = unitOfWork.AdminRepo.GetAll();
            return admin;
        }
        public AdminInfo Get(string id)
        {
            return unitOfWork.AdminRepo.GetByID(id);
        }
        public void Post([FromBody] AdminInfo value)
        {
            unitOfWork.AdminRepo.Insert(value);
            unitOfWork.Save();
        }
        public void Put([FromBody] AdminInfo value)
        {
            unitOfWork.AdminRepo.Update(value);
            unitOfWork.Save();
        }
        public void Delete(string id)
        {
            unitOfWork.AdminRepo.Delete(id);
            unitOfWork.Save();
        }
    }
}