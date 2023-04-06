using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB_WebAPI.Model.Concrete;
using MongoDB_WebAPI.Repositories.Abstract;
using MongoDB_WebAPI.Service.Abstract;
using MongoDB_WebAPI.Settings;
using System;
using System.Collections.Generic;

namespace MongoDB_WebAPI.Service.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _repository;

        public CategoryService(IGenericRepository<Category> repository)
        {
            _repository = repository;
        }

        public List<Category> GetAll()
        {
            return _repository.GetAll();
        }

        public Category GetSingle(string id)
        {
            return _repository.Get(x => x.Id == id);
        }

        public Category Add(Category category)
        {
            _repository.Add(category);
            return category;
        }

        public long Update(Category currentCategory)
        {
            //ReplaceOne : databasede koleksiyonda(tabloda) güncelleme yapan komut
            //ModifiedCount : değiştirilen satır sayısını tutar. Bu, kullanıcının güncellenip güncellenmediğini belirlemek için kullanılılır
            return _repository.Update(u => u.Id == currentCategory.Id, currentCategory);
        }

        public long Delete(string id)
        {
            //veritabanından silinen ürünlerin sayısını dönderir.Bu yüzden;geri dönüş tipini long verildi.
            return _repository.Delete(u => u.Id == id);
        }
    }
}