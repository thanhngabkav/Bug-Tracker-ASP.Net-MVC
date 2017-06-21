using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models;

namespace Models
{
    public class DeveloperAllotProject
    {
        [Key]
        [Column(Order =1)]
        public string DeveloperID { set; get; }
        [Key]
        [Column(Order = 2)]
        public string ProjectID { set; get; }
        [ForeignKey("DeveloperID")]
        public virtual User Developer { set; get; }
        [ForeignKey("ProjectID")]
        public virtual Project Project { set; get; }

    }
}
