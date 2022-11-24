using UserManager.Data.Model;

namespace UserManager.Data.Repository
{
    public interface IAccessRoleRepository
    {
        public AccessRole? GetAccessRoleById(int id);
        public List<AccessRole> GetAllAccessRole();
    }
}
