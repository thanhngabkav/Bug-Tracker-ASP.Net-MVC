using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;


namespace Models
{
    public class BugPriority
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PriorityID { set; get; }
        [Required]
        [MaxLength(100, ErrorMessage = "Priority Name khong qua 100 ky tu")]
        [Index(IsUnique =true)]
        public string PriorityName { set; get; }
        public virtual ICollection<Bug> Bugs { set; get; }
    }
}
