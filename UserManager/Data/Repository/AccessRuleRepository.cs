using UserManager.Data.Model;

namespace UserManager.Data.Repository
{
    public class AccessRuleRepository : IAccessRuleRepository
    {
        private readonly ApplicationDbContext _context;

        public AccessRuleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<AccessRule> GetAllRule()
        {
            return _context.AccessRules.ToList();
        }
    }
}
