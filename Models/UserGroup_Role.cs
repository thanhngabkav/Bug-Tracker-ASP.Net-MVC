using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class UserGroup_Role
    {
        [Key]
        [Column(Order =1)]
        public int UserGroupID { set; get; }
        [Key]
        [Column(Order =2)]
        public int RoleID { set; get; }
        [ForeignKey("UserGroupID")]
        public virtual UserGroup UserGoup { set; get; }
        [ForeignKey("RoleID")]
        public virtual Role Role { set; get; }
    }
}
