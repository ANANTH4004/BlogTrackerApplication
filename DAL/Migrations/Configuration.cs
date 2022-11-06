namespace DAL.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DAL.BlogContext context)
        {
            List<AdminInfo> adminInfos = new List<AdminInfo>();
            adminInfos.Add(new AdminInfo() { Email = "anand@gamil.com", Password = "anand" });
            adminInfos.Add(new AdminInfo() { Email = "varun@gamil.com", Password = "varun" });
            context.AdminInfos.AddRange(adminInfos);
            context.SaveChanges();
            List<EmpInfo> empInfos = new List<EmpInfo>();
            empInfos.Add(new EmpInfo() { Email = "karthi@gmail.com", Passcode = 123, DateOfJoining = new DateTime(2020, 09, 11), Name = "karthi" });
            empInfos.Add(new EmpInfo() { Email = "nithya@gmail.com", Passcode = 111, DateOfJoining = new DateTime(2019, 04, 11), Name = "nithya" });
            empInfos.Add(new EmpInfo() { Email = "sam@gmail.com", Passcode = 321, DateOfJoining = new DateTime(2020, 03, 22), Name = "sam" });
            context.EmpInfos.AddRange(empInfos);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
