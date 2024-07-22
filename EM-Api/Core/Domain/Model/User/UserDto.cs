namespace Core.Domain.Model.User
{
    public class UserDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public ICollection<Role>? Roles { get; set; }
    }
}
