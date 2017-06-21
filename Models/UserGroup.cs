using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Models
{
    public class UserGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserGroupID { set; get; }
        [Required]
        [MaxLength(100, ErrorMessage = "User Group Name khong qua 200 ky tu")]
        [Index(IsUnique =true)]
        public string UserGroupName { set; get; }
        public virtual ICollection<UserGroup_Role> UserGroup_Roles { set; get; }
    }
}
