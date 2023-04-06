using MongoDB_WebAPI.Model.Concrete;
using System.Collections.Generic;

namespace MongoDB_WebAPI.Service.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetSingle(string id);
        Category Add(Category category);
        long Update(Category currentCategory);
        long Delete(string id);
    }
}
