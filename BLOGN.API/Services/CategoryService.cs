using BLOGN.API.Services.IService;
using BLOGN.Data.Repositories.IRepository;
using BLOGN.Models;

namespace BLOGN.API.Services
{
    public class CategoryService : Services<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork, repository)
        {
        }
    }
}
