using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB_WebAPI.Model.Concrete;
using MongoDB_WebAPI.Repositories.Abstract;
using MongoDB_WebAPI.Service.Abstract;
using MongoDB_WebAPI.Settings;
using System.Collections.Generic;

namespace MongoDB_WebAPI.Service.Concrete
{
    public class ProductService :IProductService
    {
        private readonly IGenericRepository<Product> _repository;

        public ProductService(IGenericRepository<Product> repository)
        {
            _repository = repository;
        }

        public List<Product> GetAll()
        {
            return _repository.GetAll();
        }

        public Product GetSingle(string id)
        {
            return _repository.Get(x => x.Id == id);
        }

        public Product Add(Product product)
        {
            _repository.Add(product);
            return product;
        }

        public long Update(Product currentProduct)
        {
            //ReplaceOne : databasede koleksiyonda(tabloda) güncelleme yapan komut
            //ModifiedCount : değiştirilen satır sayısını tutar. Bu, kullanıcının güncellenip güncellenmediğini belirlemek için kullanılılır
            return _repository.Update(u => u.Id == currentProduct.Id, currentProduct);
        }

        public long Delete(string id)
        {
            //veritabanından silinen ürünlerin sayısını dönderir.Bu yüzden;geri dönüş tipini long verildi.
            return _repository.Delete(u => u.Id == id);
        }
    }
}
