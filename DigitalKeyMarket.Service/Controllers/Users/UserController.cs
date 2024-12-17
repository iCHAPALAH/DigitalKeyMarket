using AutoMapper;
using DigitalKeyMarket.BL.Roles.Exceptions;
using DigitalKeyMarket.BL.Users.Exceptions;
using DigitalKeyMarket.BL.Users.Model;
using DigitalKeyMarket.BL.Users.Manager;
using DigitalKeyMarket.BL.Users.Provider;
using DigitalKeyMarket.Service.Controllers.Users.Model;
using DigitalKeyMarket.Service.Validators.User;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace DigitalKeyMarket.Service.Controllers.Users;

[ApiController]
[Route("[controller]")]
public class UserController(
    IUsersManager usersManager,
    IUsersProvider usersProvider,
    IMapper mapper,
    ILogger logger)
    : ControllerBase
{
    [HttpGet]
    public IActionResult GetUsers()
    {
        try
        {
            var users = usersProvider.GetUsers();
            return Ok(users.ToList());
        }
        catch (Exception e)
        {
            logger.Error(e.Message);
            return BadRequest();
        }
    }
    
    [HttpGet]
    [Route("filter")]
    public IActionResult GetUsers([FromQuery] UserFilter filter)
    {
        try
        {
            var userFilterModel = mapper.Map<FilterUserModel>(filter);
            var users = usersProvider.GetUsers(userFilterModel);
            return Ok(users.ToList());
        }
        catch (Exception e)
        {
            logger.Error(e.Message);
            return BadRequest();
        }
    }

    [HttpGet]
    [Route("info")]
    public IActionResult GetUserInfo([FromQuery] int id)
    {
        try
        {
            var user = usersProvider.GetUserInfo(id);
            return Ok(user);
        }
        catch (UserNotFoundException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            logger.Error(e.Message);
            return BadRequest();
        }
    }

    [HttpPost]
    [Route("update")]
    public IActionResult UpdateUser([FromQuery] UpdateUserRequest request)
    {
        try
        {
            var validationResult = new UpdateUserRequestValidator().Validate(request);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var updateUserModel = mapper.Map<UpdateUserModel>(request);

            var userModel = usersManager.UpdateUser(request.Id, updateUserModel);

            return Ok(userModel);
        }
        catch (UserNotFoundException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            logger.Error(e.Message);
            return BadRequest();
        }
    }
    
    [HttpPost]
    [Route("permissions")]
    public IActionResult UpdateUsersRole([FromBody] UpdateUsersRoleRequest request)
    {
        try
        {
            var validationResult = new UpdateUsersRoleRequestValidator().Validate(request);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var userModel = usersManager.UpdateUsersRole(request.Id, request.RoleId);
            
            return Ok(userModel);
        }
        catch (UserNotFoundException e)
        {
            return BadRequest(e.Message);
        }
        catch (RoleNotFoundException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            logger.Error(e.Message);
            return BadRequest();
        }
    }

    [HttpDelete]
    [Route("delete")]
    public IActionResult DeleteUser([FromQuery] int id)
    {
        try
        {
            usersManager.DeleteUser(id);
            return Ok();
        }
        catch (UserNotFoundException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            logger.Error(e.Message);
            return BadRequest();
        }
    }
}