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
    public interface IDepartmentService
    {
        void InsertDepartment(DepartmentViewModel dvm);
        void UpdateDepartment(DepartmentViewModel dvm);
        void DeleteDepartment(int idd);
        List<DepartmentViewModel> GetDepartments();
        DepartmentViewModel GetDepartmentByID(int id);
    }
    public class DepartmentService : IDepartmentService
    {
        IDepartmentRepositories dr;

        public DepartmentService()
        {
            dr = new DepartmentRepositories();
        }

        public void InsertDepartment(DepartmentViewModel dvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<DepartmentViewModel, Department>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Department u = mapper.Map<DepartmentViewModel, Department>(dvm);
            dr.InsertDepartment(u);
        }

        public void UpdateDepartment(DepartmentViewModel dvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<DepartmentViewModel, Department>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Department u = mapper.Map<DepartmentViewModel, Department>(dvm);
            dr.UpdateDepartment(u);
        }

        public void DeleteDepartment(int idd)
        {
            dr.DeleteDepartment(idd);
        }

        public List<DepartmentViewModel> GetDepartments()
        {
            List<Department> d = dr.GetDepartments();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap< Department, DepartmentViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<DepartmentViewModel> dvm = mapper.Map<List<Department>,List<DepartmentViewModel>>(d);
            return dvm;
        }

        public DepartmentViewModel GetDepartmentByID(int id)
        {
            Department d = dr.GetDepartmentsByID(id).FirstOrDefault();
            DepartmentViewModel dvm = null;
            if (d != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Department, DepartmentViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                dvm = mapper.Map<Department, DepartmentViewModel>(d);
            }
            
            return dvm;
        }



    }
}
