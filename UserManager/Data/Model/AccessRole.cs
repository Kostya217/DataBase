using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManager.Data.Model
{
    [Table("Access Role")]
    public class AccessRole
    {
        [Key]
        public int AccessRoleId { get; set; }
        [Required]
        [StringLength(50)]
        public string Role { get; set; } = null!;
        public virtual ICollection<AccessRule> Rules { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
