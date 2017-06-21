using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;
namespace Models
{
    public class Project
    {
        public Project()
        {
            Bugs = new List<Bug>();
            DeveloperAllotProjects = new List<DeveloperAllotProject>();        }
        [Key]
        public string ProjectID { set; get; }
        [Required]
        [MaxLength(100, ErrorMessage = "Project Name khong qua 200 ky tu")]
        [Index(IsUnique =true)]
        public string Name { set; get; }
        [Required]
        public string Description { set; get; }
        [Required]
        public string ManagerID { set; get; }
        [Required]
        public DateTime InitTime { set; get; }
        [ForeignKey("ManagerID")]
        public virtual User Users { set; get; }
        public virtual ICollection<Bug> Bugs { set; get; }
        public virtual ICollection<DeveloperAllotProject> DeveloperAllotProjects { set; get; }
  
    }
}
