using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Models
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleID { set; get; }
        [Required]
        [MaxLength(100, ErrorMessage = "RoleName khong qua 100 ky tu")]
        [Index(IsUnique =true)]
        public string RoleName { set; get; }
        public virtual ICollection<UserGroup_Role> UserGroup_Roles { set; get; }
    }
}
