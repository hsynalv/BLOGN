using BLOGN.API.Services.IService;
using BLOGN.Data.Repositories.IRepository;
using BLOGN.Models;

namespace BLOGN.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _repository;
        public UserService(IUnitOfWork unitOfWork, IUserRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public User Authentice(string username, string password)
        {
            var user = _repository.Authentice(username, password);
            return user;
        }

        public bool IsUniqueUser(string username)
        {
           return _repository.IsUniqueUser(username);
        }

        public User Register(string username, string password)
        {
            var user = _repository.Register(username, password);
            _unitOfWork.Save();
            return user;
        }
    }
}
