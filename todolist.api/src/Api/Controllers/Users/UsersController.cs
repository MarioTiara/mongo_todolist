

using api.Controllers.Users.Requests;
using Core.Entities;
using Core.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository    _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
         [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users= await _userRepository.GetAllAsync();
            return Ok(users);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var user= await _userRepository.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create (CreateUserRequest request)
        {
            await _userRepository.AddAsync(new User(
                request.Username, 
                request.FirstName, request.LastName,
                request.Email));
            return Ok(new { Message = "User created" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _userRepository.DeleteAsync(id);
            return Ok(new { Message = "User deleted" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, UpdateUserRequest request)
        {
            var user = await _userRepository.GetByIdAsync(id);
            user.Update(request.Username, request.FirstName, request.LastName, request.Email);
            await _userRepository.UpdateAsync( id,user);
            return Ok(new { Message = "User updated" });
        }
    }

    
}