using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoStoreAPI.Models;
using MongoStoreAPI.Services;

namespace MongoStoreAPI.Controllers
{
    // For Authenticatinon with JWT
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController: ControllerBase
    {
        private readonly UserService service;

        public UserController(UserService _service)
        {
            service = _service;
        }

        [HttpGet]
        public ActionResult<List<User>> GetUsers()
        {
            return service.GetUsers();
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<User> GetUser(string id)
        {
            var user = service.GetUser(id);
            return Ok(user);
        }

        // For Authenticatinon with JWT
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public ActionResult Login([FromBody] User user)
        {
            var token = service.Authenticate(user.Email, user.Password);

            if(token == null){
                return Unauthorized();
            }

            return Ok(new {token, user});
        }


        // For Authenticatinon with JWT
        [AllowAnonymous]
        [HttpPost]
        // [HttpPost]
        [Route("register")]
        public ActionResult<User> Register(User user)
        {
            service.Create(user);
            return Ok(user);    
        }
    }
}