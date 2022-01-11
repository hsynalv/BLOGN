using BLOGN.API.Services.IService;
using BLOGN.Data.Repositories.IRepository;
using BLOGN.Models;

namespace BLOGN.API.Services
{
    public class ArticleService : Services<Article>, IArticleService
    {
        public ArticleService(IUnitOfWork unitOfWork, IRepository<Article> repository) : base(unitOfWork, repository)
        {
        }
    }
}
