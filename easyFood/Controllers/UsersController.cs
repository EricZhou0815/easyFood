using System.Collections.Generic;
using easyFood.Models;
using easyFood.Services;
using Microsoft.AspNetCore.Mvc;


namespace easyFood.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        // GET api/users
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return _userService.Get();
        }

        // GET api/users/5
        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<User> Get(string id)
        {
            var user = _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST api/users
        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            var _user = _userService.GetByEmail(user.Email);

            if (_user==null) 
            {
                _userService.Create(user);

                return CreatedAtRoute("GetUser", new { id = user.Id.ToString() }, user);
            }
            
            return NoContent();
        }

        // PUT api/users/5
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, User userIn)
        {
            var user = _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.Update(id, userIn);

            return NoContent();
        }

        // DELETE api/users/5
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var user = _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.Remove(user.Id);

            return NoContent();
        }

        // Login api/users/login
        [HttpPost("login", Name="Login")]
        public IActionResult Login(string email, string password)
        {
            var user = _userService.Get(email);

            if (user == null)
            {
                return NotFound();
            }
            else if (user.Password!=password)
            {
                return NoContent();
            }
            else
            {
                return user.Id;
            }
        }
    }
}