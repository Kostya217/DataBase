using UserManager.Data.Model;

namespace UserManager.Data.Repository
{
    public interface IAccessRuleRepository
    {
        public List<AccessRule> GetAllRule();
    }
}
