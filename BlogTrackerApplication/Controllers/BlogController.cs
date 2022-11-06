using DAL;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogTracker.Controllers
{
    public class BlogController : ApiController
    {
        UnitOfWork unit = new UnitOfWork();
        // GET api/<controller>
        public IEnumerable<BlogInfo> Get()
        {
            var blogs = unit.BlogRepo.GetAll();
            return blogs;
        }

        // GET api/<controller>/5
        public BlogInfo Get(int id)
        {
            return unit.BlogRepo.GetByID(id);
        }

        // POST api/<controller>
        public void Post([FromBody] BlogInfo value)
        {
            unit.BlogRepo.Insert(value);
            unit.Save();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] BlogInfo value)
        {
            unit.BlogRepo.Update(value);
            unit.Save();
        }

        // DELETE api/<controller>/5
        public void Delete(string id)
        {
            unit.BlogRepo.Delete(id);
            unit.Save();
        }
    }
}