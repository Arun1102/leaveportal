using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MMALeavePortal.ServiceLayers;
using MMALeavePortal.ViewModels;

namespace MMALEAVEPORTAL.Controllers
{
    public class HomeController : Controller
    {
        ILeaveApplicationService las;

        public HomeController(ILeaveApplicationService las)
        {
            this.las = las; 
        }
        
        public ActionResult Index()
        {
            List<ApplicationViewModel> leaveApplication = this.las.GetLeaveApplication().Take(10).ToList();
            return View(leaveApplication);
        }
    }
}