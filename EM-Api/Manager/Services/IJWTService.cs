using Core.Domain.Model.User;

namespace Manager.Services
{
    public interface IJWTService
    {
        string TokenGenerate(User user);
    }
}
