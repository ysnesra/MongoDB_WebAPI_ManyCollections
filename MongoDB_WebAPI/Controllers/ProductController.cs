using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB_WebAPI.Model.Concrete;
using MongoDB_WebAPI.Service.Abstract;
using MongoDB_WebAPI.Service.Concrete;
using MongoDB_WebAPI.Settings;
using System.Collections.Generic;

namespace MongoDB_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _productService;

        public ProductController(IProductService productService )
        {
            _productService=productService; 
        }
        

        [HttpGet("getall")]
        public ActionResult<List<Product>> GetAll()
        {
            return _productService.GetAll();
        }

        //Tek bir kullanıcıyı getirme
        [HttpGet("getbyid")]
        public ActionResult<Product> GetById(string id)
        {
            return _productService.GetSingle(id);
        }

        [HttpPost("add")]
        public ActionResult<Product> Add(Product product)
        {
            return _productService.Add(product);
        }

        [HttpPost("update")]
        public ActionResult Update(Product currentProduct)
        {
            var user = _productService.GetSingle(currentProduct.Id);
            if (user == null)
                return NotFound();

            _productService.Update(currentProduct);
            return Ok();
        }

        //Kullanıcıyı silme
        [HttpPost("delete")]
        public ActionResult Delete(string id)
        {
            var user = _productService.GetSingle(id);

            if (user == null)
                return NotFound();

            _productService.Delete(id);
            return Ok();
        }
    }
}
