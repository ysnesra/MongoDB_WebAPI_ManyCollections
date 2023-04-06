using MongoDB.Driver;
using MongoDB_WebAPI.Model.Concrete;
using MongoDB_WebAPI.Repositories.Abstract;
using MongoDB_WebAPI.Service.Abstract;
using MongoDB_WebAPI.Settings;
using System.Collections.Generic;
using System.Linq;

namespace MongoDB_WebAPI.Service.Concrete
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _repository;

        public UserService(IGenericRepository<User> repository)
        {
            _repository = repository;
        }

        //Tümünü Listeleme
        public List<User> GetAll()
        {
            return _repository.GetAll().ToList();
             
        }

        //Tek bir kullanıcı getirme
        public User GetSingle(string id)
        {
            return _repository.Get(x=>x.Id==id);
        }

        //Kullanıcı ekleme
        public User Add(User user)
        {
            _repository.Add(user);
            return user;
        }

        //Kullanıcı güncelleme
        public long Update(User currentUser)
        {
            //ReplaceOne : databasede koleksiyonda(tabloda) güncelleme yapan komut
            //ModifiedCount : değiştirilen satır sayısını tutar. Bu, kullanıcının güncellenip güncellenmediğini belirlemek için kullanılılır
            return _repository.Update(x => x.Id == currentUser.Id,currentUser);
        }

        //Kullanıcı silme
        public long Delete(string id)
        {
            return _repository.Delete(x=>x.Id==id);
        }
    }
}