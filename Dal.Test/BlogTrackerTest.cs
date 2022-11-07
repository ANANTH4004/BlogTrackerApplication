using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Repository;

namespace Dal.Test
{
    [TestFixture]
    public class BlogTrackerTest
    {
        BlogContext blog = new BlogContext();
        UnitOfWork unit = new UnitOfWork();
        [TestCase("anand@gmail.com" ,ExpectedResult =true )]
        [TestCase("nithya@gmail.com",ExpectedResult = true)]
        [TestCase("varun@gmail.com", ExpectedResult = true)]
        [TestCase("samantha@gmail.com", ExpectedResult = true)]
        public bool Validate(string ans)
        {
            var found = unit.AdminRepo.GetByID(ans);
            if(found != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
