using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB_WebAPI.Model.Concrete;
using MongoDB_WebAPI.Service.Abstract;
using MongoDB_WebAPI.Service.Concrete;
using MongoDB_WebAPI.Settings;
using System.Collections.Generic;

namespace MongoDB_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getall")]
        public ActionResult<List<User>> GetAll()
        {
            return _userService.GetAll();
        }

        //Tek bir kullanıcıyı getirme
        [HttpGet("getbyid")]
        public ActionResult<User> GetById(string id)
        {
            return _userService.GetSingle(id);
        }

        [HttpPost("add")]
        public ActionResult<User> Add(User user)
        {
            return _userService.Add(user);
        }

        [HttpPut("update")]
        public ActionResult Update(User currentUser)
        {
            var user = _userService.GetSingle(currentUser.Id);
            if (user == null)
                return NotFound();

            _userService.Update(currentUser);
            return Ok();
        }

        //Kullanıcıyı silme
        [HttpDelete("delete")]
        public ActionResult Delete(string id)
        {
            var user = _userService.GetSingle(id);

            if (user == null)
                return NotFound();

            _userService.Delete(id);
            return Ok();
        }
    }
}

