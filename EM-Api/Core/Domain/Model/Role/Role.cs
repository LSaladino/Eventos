using Core.Domain.Model.User;

namespace Core.Domain
{
    public class Role
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public ICollection<User> Users { get; set; }
    }
}