using UserManager.Data.Model;

namespace UserManager.Models
{
    public class UserManagerViewModel
    {
        public User User { get; set; }
        public IEnumerable<UserViewModel> Users { get; set; }
        public IEnumerable<AccessRole> AccessRoles { get; set; }
    }
}
