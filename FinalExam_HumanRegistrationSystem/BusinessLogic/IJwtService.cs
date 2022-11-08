using Domain;

namespace BusinessLogic
{
    public interface IJwtService
    {
        string GetJwt(User user);
    }
}
