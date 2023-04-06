using MongoDB_WebAPI.Model.Concrete;
using System.Collections.Generic;

namespace MongoDB_WebAPI.Service.Abstract
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetSingle(string id);
        User Add(User user);
        long Update(User currentUser);
        long Delete(string id);
    }
}
