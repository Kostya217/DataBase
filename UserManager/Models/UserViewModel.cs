namespace UserManager.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string AccessRole { get; set; } = null!;
    }
}
