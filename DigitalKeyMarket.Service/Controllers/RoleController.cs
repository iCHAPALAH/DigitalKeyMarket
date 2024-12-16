using AutoMapper;
using DigitalKeyMarket.BL.Roles.Manager;
using DigitalKeyMarket.BL.Roles.Model;
using DigitalKeyMarket.BL.Roles.Provider;
using DigitalKeyMarket.Service.Validators.Role;
using Microsoft.AspNetCore.Mvc;

namespace DigitalKeyMarket.Service.Controllers;

[ApiController]
[Route("[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRolesManager _rolesManager;
    private readonly IRolesProvider _rolesProvider;
    private readonly IMapper _mapper;

    public RoleController(IRolesManager rolesManager, IRolesProvider rolesProvider, IMapper mapper)
    {
        _rolesManager = rolesManager;
        _rolesProvider = rolesProvider;
        _mapper = mapper;
    }
    
    [HttpPost]
    [Route("/role")]
    public IActionResult CreateRole([FromBody] CreateRoleModel request)
    {
        try
        {
            var validationResult = new CreateRoleValidator().Validate(request);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);
            var roleModel = _rolesManager.CreateRole(request);
            return Ok(roleModel);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("/role/all")]
    public IActionResult GetAllRoles()
    {
        try
        {
            var roles = _rolesProvider.GetRoles();
            return Ok(roles.Select(u => _mapper.Map<RoleModel>(u)).ToList());
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("/role/{id:int}")]
    public IActionResult GetRoleById(int id)
    {
        try
        {
            var role = _rolesProvider.GetRoleInfo(id);
            return Ok(role);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPut]
    [Route("/role")]
    public IActionResult UpdateRole([FromBody] UpdateRoleModel request)
    {
        try
        {
            var validationResult = new UpdateRoleValidator().Validate(request);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);
            var roleModel = _rolesManager.UpdateRole(request);
            return Ok(roleModel);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpDelete]
    [Route("/role/{id:int}")]
    public IActionResult DeleteRole(int id)
    {
        try
        {
            _rolesManager.DeleteRole(id);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}