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
    public interface IUsersService
    {
        void UpdateUserDetails(EditUserViewModel uvm);
        void UpdateUserPassword(EditUserPasswordViewModel uvm);
        void DeleteUser(int uid);
        List<UserViewModel> GetUsers();
        UserViewModel GetUsersByEmailandPassword(string Email, string Password);
        UserViewModel GetUsersByEmail(string Email);
        UserViewModel GetUsersByUserID(int UserID);
    }
    public class UsersService : IUsersService
    {
        IUsersRepository ur;

        public UsersService()
        {
            ur = new UsersRepository();
        }


        public void UpdateUserDetails(EditUserViewModel uvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditUserViewModel, User>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            User u = mapper.Map<EditUserViewModel,User>(uvm);
            ur.UpdateUserDetails(u);
        }

        public void UpdateUserPassword(EditUserPasswordViewModel uvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditUserPasswordViewModel, User>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            User u = mapper.Map<EditUserPasswordViewModel, User>(uvm);
            u.PasswordHash = SHA256HashGenerator.GenerateHash(uvm.Password);
            ur.UpdateUserPassword(u);
        }

        public void DeleteUser(int uid)
        {
            ur.DeleteUser(uid);
        }

        public List<UserViewModel> GetUsers()
        {
            List<User> u =ur.GetUsers();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<UserViewModel> uvm = mapper.Map<List<User>, List<UserViewModel>>(u);
            return uvm;
        }

        public UserViewModel GetUsersByEmailandPassword(string Email, string Password)
        {
            User u = ur.GetUsersByEmailAndPassword(Email, SHA256HashGenerator.GenerateHash(Password)).FirstOrDefault();
            UserViewModel uvm = null;
            if (u != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                uvm = mapper.Map<User,UserViewModel>(u);
            }
            return uvm;
        }

        public UserViewModel GetUsersByEmail(string Email)
        {
            User u = ur.GetUsersByEmail(Email).FirstOrDefault();
            UserViewModel uvm = null;
            if (u != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                uvm = mapper.Map<User, UserViewModel>(u);
            }
            return uvm;
        }


        public UserViewModel GetUsersByUserID(int UserID)
        {
            User u = ur.GetUsersByUserID(UserID).FirstOrDefault();
            UserViewModel uvm = null;
            if (u != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                uvm = mapper.Map<User, UserViewModel>(u);
            }
            return uvm;
        }


    }
}
