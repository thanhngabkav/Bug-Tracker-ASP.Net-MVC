using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace Models
{
    public class User
    {
        public User()
        {
            Bugs = new List<Bug>();
            Projects = new List<Project>();
            DeveloperAllotProjects = new List<DeveloperAllotProject>();
        }
        [Key]
        public string UserID { set; get; }
        [Required]
        public string FullName { set; get; }
        [MaxLength(200,ErrorMessage ="UserName khong qua 200 ky tu")]
        [Required]
        [Index(IsUnique =true)]
        public string UserName { set; get; }
        [MaxLength(200, ErrorMessage = "Password khong qua 200 ky tu")]
        [MinLength(6, ErrorMessage = "Password duoc nho hon 6 ky tu")]
        [Required]
        public string Password { set; get; }
        [EmailAddress]
        public string Email { set; get; }
        [Phone(ErrorMessage = "So Dien Thoai Khong Hop Le")]
        public string Phone { set; get; }
        public int UserGroupID { set; get; }
        [ForeignKey("UserGroupID")]
        public virtual UserGroup UserGroup { set; get; }

        public virtual ICollection<Bug> Bugs { set; get; }
        public virtual ICollection<Project> Projects { set; get; }
        public virtual ICollection<DeveloperAllotProject> DeveloperAllotProjects { set; get; }
    }
}
