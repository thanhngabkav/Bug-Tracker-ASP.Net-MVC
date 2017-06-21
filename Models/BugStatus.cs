using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models
{
    public class BugStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BugStatusID { set; get; }
        [Required]
        [MaxLength(100, ErrorMessage = "Status Name khong qua 200 ky tu")]
        [Index(IsUnique =true)]
        public string StatusName { set; get; }
        public virtual ICollection<Bug> BugStatusses{ set; get; }
    }
}
