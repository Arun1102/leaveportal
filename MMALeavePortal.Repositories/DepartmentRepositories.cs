using System;
using System.Collections.Generic;
using System.Linq;
using MMALeavePPortal.DomainModels;

namespace MMALeavePortal.Repositories
{
    public interface IDepartmentRepositories
    {
        void InsertDepartment (Department D);
        void UpdateDepartment(Department D);
        void DeleteDepartment(int idd);
        List<Department> GetDepartments();

        List<Department> GetDepartmentsByID(int D);

    }

    public class DepartmentRepositories: IDepartmentRepositories
    {

        LPDatabase2022DBContext db;
        public DepartmentRepositories()
        {
            db = new LPDatabase2022DBContext();
        }


        public void InsertDepartment(Department D)
        {
             
                db.Departments.Add(D);
                db.SaveChanges();   
            
        }

        public void UpdateDepartment(Department D)
        {
            Department De = db.Departments.Where(temp=>temp.DepartmentID == D.DepartmentID).FirstOrDefault();
            if (De != null)
            {
                De.DepartmentName = De.DepartmentName;
                db.SaveChanges();
            }
        }

        public void DeleteDepartment(int idd)
        {
            Department De = db.Departments.Where(temp => temp.DepartmentID == idd).FirstOrDefault();
            if (De != null)
            {
                db.Departments.Remove(De);
                db.SaveChanges();
            }
        }

        public List<Department> GetDepartments()
        {
            List<Department> De = db.Departments.ToList();
            return De;
        }

        public List<Department> GetDepartmentsByID(int D)
        {
            List<Department> De = db.Departments.Where(temp => temp.DepartmentID == D).ToList();
            return De;
        }

    }
}
