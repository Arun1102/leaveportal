using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MMALeavePortal.ViewModels
{
    public class NewApplicationViewModel
    {
        [Required]
        public String ApplicationId { get; set; }

        [Required]
        public DateTime LeaveDateAndTime { get; set; }

        [Required]
        public int UserID { get; set; }
        [Required]
        public int DepartmentID { get; set; }
    }
}
