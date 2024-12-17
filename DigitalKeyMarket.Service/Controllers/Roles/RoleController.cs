using AutoMapper;
using DigitalKeyMarket.BL.Roles.Model;
using DigitalKeyMarket.BL.Roles.Provider;
using DigitalKeyMarket.Service.Controllers.Roles.Request;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace DigitalKeyMarket.Service.Controllers.Roles;

[ApiController]
[Route("[controller]")]
public class RoleController(IRolesProvider rolesProvider, IMapper mapper, ILogger logger)
    : ControllerBase
{
    [HttpGet]
    public IActionResult GetRoles()
    {
        try
        {
            var roles = rolesProvider.GetRoles();
            return Ok(roles.ToList());
        }
        catch (Exception e)
        {
            logger.Error(e.Message);
            return BadRequest();
        }
    }
    
    [HttpGet]
    [Route("filter")]
    public IActionResult GetRoles([FromQuery] RoleFilter roleFilter)
    {
        try
        {
            var filterModel = mapper.Map<RoleFilterModel>(roleFilter);
            var roles = rolesProvider.GetRoles(filterModel);
            return Ok(roles.ToList());
        }
        catch (Exception e)
        {
            logger.Error(e.Message);
            return BadRequest();
        }
    }
}