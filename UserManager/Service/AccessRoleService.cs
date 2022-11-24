using UserManager.Data.Model;
using UserManager.Data.Repository;

namespace UserManager.Service
{
    public class AccessRoleService : IAccessRoleService
    {
        private readonly IAccessRoleRepository _accessRoleRepository;
        
        public AccessRoleService(IAccessRoleRepository accessRoleRepository)
        {
            _accessRoleRepository = accessRoleRepository;

        }

        public List<AccessRole> GetAllRoles()
        {
            return _accessRoleRepository.GetAllAccessRole();
        }

        public AccessRole? GetRoleById(int id)
        {
            return _accessRoleRepository.GetAccessRoleById(id);
        }
    }
}
