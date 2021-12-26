using System.Web.Http;
using Unity;
using Unity.WebApi;
using Unity.Mvc5;
using MMALeavePortal.ServiceLayers;
using System.Web.Mvc;
namespace MMALEAVEPORTAL
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            
            
            container.RegisterType<ILeaveApplicationService, LeaveApplicationService>();

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}