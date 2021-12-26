using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMALeavePortal.ViewModels
{
    public class EditApplicationViewModel
    {
        [Required]
        public int LeaveID { get; set; }
        [Required]
        public string LeaveText { get; set; }
        [Required]
        public DateTime LeaveDateAndTime { get; set; }

        [Required]
        public int DepartmentID { get; set; }
     }
}
