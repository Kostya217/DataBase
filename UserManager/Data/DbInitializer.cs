namespace UserManager.Data
{
    public static class DbInitializer
    {
        public static void Initializer(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
