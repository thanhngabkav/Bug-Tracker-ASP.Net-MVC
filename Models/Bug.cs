using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Bug
    {
        public string BugID { set; get; }
        public DateTime DetectionTime { set; get; }
        public string Owner { set; get; }//TesterID
        public string Description { set; get; }
        public int PriorityID { set; get; }
        public string ProjectID { set; get; }
        public int StatusID { set; get; }
        [ForeignKey("Owner")]
        public virtual User Tester { set; get; }
        [ForeignKey("PriorityID")]
        public virtual BugPriority Priority { set; get; }
        [ForeignKey("ProjectID")]
        public virtual Project Project { set; get; }
        [ForeignKey("StatusID")]
        public virtual BugStatus Status { set; get; }
       
    }
}
