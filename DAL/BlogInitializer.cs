using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BlogInitializer : DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            List<AdminInfo> adminInfos = new List<AdminInfo>();
            adminInfos.Add(new AdminInfo() { Email = "anand@gamil.com", Password = "anand" });
            adminInfos.Add(new AdminInfo() { Email = "varun@gamil.com", Password = "varun" });
            context.AdminInfos.AddRange(adminInfos);
            context.SaveChanges();
            List<EmpInfo> empInfos = new List<EmpInfo>();
            empInfos.Add(new EmpInfo() { Email = "karthi@gmail.com" , Passcode =123 , DateOfJoining =new  DateTime(2020,09,11) , Name ="karthi"});
            empInfos.Add(new EmpInfo() { Email = "nithya@gmail.com" , Passcode =111 , DateOfJoining =new  DateTime(2019,04,11) , Name ="nithya"});
            empInfos.Add(new EmpInfo() { Email = "sam@gmail.com" , Passcode =321 , DateOfJoining =new  DateTime(2020,03,22) , Name ="sam"});
            context.EmpInfos.AddRange(empInfos);
            List<BlogInfo> blogInfos = new List<BlogInfo>();
            blogInfos.Add(new BlogInfo() { Email ="sam@gmail.com" , BlogUrl= "https://github.com/ANANTH4004?tab=repositories" , DateOfCreation = new DateTime(2020,02,02) , Subject="GitRepo" , Title ="My GitRepo"});
            blogInfos.Add(new BlogInfo() { Email ="karthi@gmail.com" , BlogUrl= "https://github.com/ANANTH4004?tab=repositories" , DateOfCreation = new DateTime(2020,02,02) , Subject="GitRepo" , Title ="My GitRepo"});
            context.BlogInfos.AddRange(blogInfos);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
