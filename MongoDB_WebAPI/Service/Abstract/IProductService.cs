using MongoDB_WebAPI.Model.Concrete;
using System.Collections.Generic;

namespace MongoDB_WebAPI.Service.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetSingle(string id);
        Product Add(Product product);
        long Update(Product currentProduct);
        long Delete(string id);
    }
}
