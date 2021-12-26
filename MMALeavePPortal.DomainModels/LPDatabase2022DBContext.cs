using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace MMALeavePPortal.DomainModels
{
    public class LPDatabase2022DBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<LeaveApplication> LeaveApplications { get; set; }
    }
}
