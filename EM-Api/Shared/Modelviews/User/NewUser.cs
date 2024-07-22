namespace Shared.Modelviews.User    
{
    public class NewUser
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        
        public ICollection<RoleReference>? RoleReferences { get; set; }
    }
}
