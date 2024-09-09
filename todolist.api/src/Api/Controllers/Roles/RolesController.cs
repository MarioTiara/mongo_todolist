using api.Controllers.Roles.Requests;
using Core.Entities;
using Core.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Roles;

[ApiController]
[Route("api/[controller]")]
public class RolesController : ControllerBase
{
    private readonly IRoleRepository _roleRepository;
    public RolesController(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var roles= await _roleRepository.GetAllAsync();
        return Ok(roles);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var role= await _roleRepository.GetByIdAsync(id);
        return Ok(role);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRoleRequest request)
    {
        var role = new Role(request.Name, request.Description);
        await _roleRepository.AddAsync(role);
        return Ok(new { Message = "User created" });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, UpdateRoleRequest request)
    {
        var role = new Role(request.Name, request.Description);
        var isUpdated = await _roleRepository.UpdateAsync(id, role);
        return  Ok(new { Message = "User updated" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _roleRepository.DeleteAsync(id);
        return Ok(new { Message = "User deleted" });
    }
}
