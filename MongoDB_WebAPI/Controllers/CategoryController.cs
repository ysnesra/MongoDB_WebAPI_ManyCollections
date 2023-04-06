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
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService=categoryService;   
        }
      
        [HttpGet("getall")]
        public ActionResult<List<Category>> GetAll()
        {
            return _categoryService.GetAll();
        }

        //Tek bir kullanıcıyı getirme
        [HttpGet("getbyid")]
        public ActionResult<Category> GetById(string id)
        {
            return _categoryService.GetSingle(id);
        }

        [HttpPost("add")]
        public ActionResult<Category> Add(Category category)
        {
            return _categoryService.Add(category);
        }

        [HttpPost("update")]
        public ActionResult Update(Category currentCategory)
        {
            var user = _categoryService.GetSingle(currentCategory.Id);
            if (user == null)
                return NotFound();

            _categoryService.Update(currentCategory);
            return Ok();
        }

        //Kullanıcıyı silme
        [HttpPost("delete")]
        public ActionResult Delete(string id)
        {
            var user = _categoryService.GetSingle(id);

            if (user == null)
                return NotFound();

            _categoryService.Delete(id);
            return Ok();
        }
    }
}
