using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StruggleBus.Models;
using StruggleBus.Repositories;

namespace StruggleBus.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {   

            _userRepository = userRepository;
        }

        [HttpGet("{firebaseUserId}")]
        public IActionResult GetByFirebaseUserId(string firebaseUserId)
        {
            var user = _userRepository.GetByFirebaseUserId(firebaseUserId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        
        [HttpGet("details/{userId}")]
        public IActionResult GetUserById(int userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            
            _userRepository.Add(user);
            return CreatedAtAction(nameof(GetByFirebaseUserId), new { firebaseUserId = user.FirebaseUserId }, user);
        }

        
        [HttpPut("{id}")]
        public IActionResult Update(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _userRepository.Edit(user);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userRepository.Remove(id);

            return NoContent();
        }
    }
}
