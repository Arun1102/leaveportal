using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;




namespace MMALeavePPortal.DomainModels
{
    public class LeaveApplication
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeaveID { get; set; }
        public string LeaveText { get; set; }
        public DateTime LeaveDateAndTime { get; set; }
        public int UserID { get; set; }
        public int DepartmentID { get; set; }

        

        

       

        [ForeignKey("UserID")]
        public virtual User user { get; set; }
        [ForeignKey("DepartmentID")]
        public virtual Department Department { get; set; }

        

    }
}
