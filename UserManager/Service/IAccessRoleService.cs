using UserManager.Data.Model;

namespace UserManager.Service
{
    public interface IAccessRoleService
    {
        public AccessRole? GetRoleById(int id);
        public List<AccessRole> GetAllRoles();
    }
}
