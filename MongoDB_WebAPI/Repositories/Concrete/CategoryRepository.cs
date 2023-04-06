using MongoDB_WebAPI.Model.Concrete;
using MongoDB_WebAPI.Repositories.Abstract;
using MongoDB_WebAPI.Settings;

namespace MongoDB_WebAPI.Repositories.Concrete
{
    public class CategoryRepository : GenericRepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbSettings dbSettings) : base(dbSettings)
        {

        }
    }
}

