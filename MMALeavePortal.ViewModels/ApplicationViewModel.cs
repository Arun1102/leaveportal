using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace MMALeavePortal.ViewModels
{
    public class ApplicationViewModel
    {
        public int LeaveID { get; set; }
        public string LeaveText { get; set; }
        public DateTime LeaveDateAndTime{ get; set; }
        public int UserID { get; set; }
        public int DepartmentID { get; set; }

       
        
    }
}
