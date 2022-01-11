using BLOGN.Models;

namespace BLOGN.API.Services.IService
{
    public interface IUserService 
    {
        bool IsUniqueUser(string username);
        User Authentice(string username, string password);
        User Register(string username, string password);
    }
}
