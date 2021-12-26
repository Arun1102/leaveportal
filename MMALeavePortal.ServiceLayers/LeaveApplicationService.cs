using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMALeavePPortal.DomainModels;
using MMALeavePortal.Repositories;
using MMALeavePortal.ViewModels;
using AutoMapper;
using AutoMapper.Configuration;

namespace MMALeavePortal.ServiceLayers
{
    public interface ILeaveApplicationService
    {
        void InsertLeaveApplication(NewApplicationViewModel avm);
        void UpdateLeaveApplication(EditApplicationViewModel avm);
        void DeleteLeaveApplication(int id);
        List<ApplicationViewModel> GetLeaveApplication();
        ApplicationViewModel GetLeaveApplicationByID(int LeaveID);
    }
    public class LeaveApplicationService : ILeaveApplicationService

    {

        ILeaveApplicationRepository lr;


        public LeaveApplicationService()
        {
            lr = new LeaveApplicationRepository();
        }


        public void InsertLeaveApplication(NewApplicationViewModel avm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<NewApplicationViewModel, LeaveApplication>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            LeaveApplication u = mapper.Map<NewApplicationViewModel, LeaveApplication>(avm);
            lr.InsertLeaveApplication(u);
        }

        public void UpdateLeaveApplication(EditApplicationViewModel avm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditApplicationViewModel, LeaveApplication>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            LeaveApplication u = mapper.Map<EditApplicationViewModel, LeaveApplication>(avm);
            lr.UpdateLeaveApplication(u);
        }

        public void DeleteLeaveApplication(int id)
        {
            lr.DeleteLeaveApplication(id);
        }

        public List<ApplicationViewModel> GetLeaveApplication()
        {
            List<LeaveApplication> d = lr.GetLeaveApplication();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<LeaveApplication, ApplicationViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<ApplicationViewModel> dvm = mapper.Map<List<LeaveApplication>, List<ApplicationViewModel>>(d);
            return dvm;
        }
        public ApplicationViewModel GetLeaveApplicationByID(int LeaveID)
        {
            LeaveApplication d = lr.GetLeaveApplicationByID(LeaveID).FirstOrDefault();
            ApplicationViewModel dvm = null;
            if (d != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<LeaveApplication, ApplicationViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                dvm = mapper.Map<LeaveApplication, ApplicationViewModel>(d);

            }

            return dvm;
        }

    }
}
