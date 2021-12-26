using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MMALeavePortal.ViewModels
{
    public class DepartmentViewModel
    {
        [Required]
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }
    
    }
}
