using System;
using System.Collections.Generic;
using System.Linq;
using MMALeavePPortal.DomainModels;

namespace MMALeavePortal.Repositories
{
    public interface ILeaveApplicationRepository
    {
        void InsertLeaveApplication(LeaveApplication l);
        void UpdateLeaveApplication(LeaveApplication l);
        void DeleteLeaveApplication(int l);
        List<LeaveApplication> GetLeaveApplication();
        List<LeaveApplication> GetLeaveApplicationByID(int lid);
    }
    public class LeaveApplicationRepository: ILeaveApplicationRepository
    {
        LPDatabase2022DBContext db;
        public LeaveApplicationRepository()
        {
            db = new LPDatabase2022DBContext();
        }
        public void InsertLeaveApplication(LeaveApplication l)
        {
            db.LeaveApplications.Add(l);
            db.SaveChanges();
        }

        public void UpdateLeaveApplication(LeaveApplication l)
        {
            LeaveApplication le = db.LeaveApplications.Where(temp => temp.LeaveID == l.LeaveID).FirstOrDefault();
            if (le != null)
            {
                le.LeaveText = l.LeaveText; 
                le.LeaveID = l.LeaveID; 
                le.LeaveDateAndTime = l.LeaveDateAndTime;
                db.SaveChanges();
            }
        }

        public void DeleteLeaveApplication(int l)
        {
            LeaveApplication les = db.LeaveApplications.Where(temp => temp.LeaveID == l).FirstOrDefault();
            if (les != null)
            {
                db.LeaveApplications.Remove(les);
                db.SaveChanges();
            }
        }

        public List<LeaveApplication> GetLeaveApplication()
        {
            List<LeaveApplication> lv = db.LeaveApplications.ToList();
            return lv;
        }


        public List<LeaveApplication> GetLeaveApplicationByID(int lid)
        {
            List<LeaveApplication> lv = db.LeaveApplications.Where(temp => temp.LeaveID == lid).ToList();
            return lv;
        }



    }
}
