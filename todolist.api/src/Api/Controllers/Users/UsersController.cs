

using api.Controllers.Users.Requests;
using Application.Commands;
using Core.Entities;
using Core.IRepositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController:BaseControllerV1
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UsersController(IUserRepository userRepository, IRoleRepository roleRepository) 
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userRepository.GetAllAsync();
            
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserRequest request)
        {
            var command = new CreateUserCommand(request.Username, request.FirstName, request.LastName, request.Email, request.Password);
            // await _userRepository.AddAsync(new User(
            //     request.Username,
            //     request.FirstName, request.LastName,
            //     request.Email));
            var resutl= await Mediator.Send(command);
            return Ok(new { Message = "User created" , id=resutl});
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
            await _userRepository.UpdateAsync(id, user);
            return Ok(new { Message = "User updated" });
        }

        [HttpPost("{id}/add-role")]
        // [Route("add-role/{roleId}")]
        public async Task<IActionResult> AddRoleToUser(string id, string roleId)
        {
            var role = await _roleRepository.GetByIdAsync(roleId);
            var user = await _userRepository.GetByIdAsync(id);
            user.AddRole(role);
            await _userRepository.UpdateAsync(id, user);
            return Ok(new { Message = "Role added to user" });
        }
    }


}