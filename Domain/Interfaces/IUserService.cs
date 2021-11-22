using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        User SelectByEmailAndPassword(string email, string password);
    }
}
