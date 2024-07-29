namespace Core.Domain.Model.User
{
    public class User   
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;   
        public string Password { get; set; } = string.Empty;
        public ICollection<Role> Roles { get; set; }

        public User()
        {
            Roles = new HashSet<Role>();
        }
    }
}
