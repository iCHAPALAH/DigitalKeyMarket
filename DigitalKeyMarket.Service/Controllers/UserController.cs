using AutoMapper;
using DigitalKeyMarket.BL.Users.Model;
using DigitalKeyMarket.BL.Users.Manager;
using DigitalKeyMarket.BL.Users.Provider;
using DigitalKeyMarket.Service.Validators.User;
using Microsoft.AspNetCore.Mvc;

namespace DigitalKeyMarket.Service.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUsersManager _usersManager;
    private readonly IUsersProvider _usersProvider;
    private readonly IMapper _mapper;
    
    public UserController(IUsersManager usersManager, IUsersProvider usersProvider, IMapper mapper)
    {
        _usersManager = usersManager;
        _usersProvider = usersProvider;
        _mapper = mapper;
    }
    
    [HttpPost]
    [Route("/user")]
    public IActionResult CreateUser([FromBody] CreateUserModel request)
    {
        try
        {
            var validationResult = new CreateUserModelValidator().Validate(request);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);
            var userModel = _usersManager.CreateUser(request);
            return Ok(userModel);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("/user/all")]
    public IActionResult GetAllUsers()
    {
        try
        {
            var users = _usersProvider.GetUsers();
            return Ok(users.Select(u => _mapper.Map<UserModel>(u)).ToList());
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("/user/{id:int}")]
    public IActionResult GetUserById(int id)
    {
        try
        {
            var user = _usersProvider.GetUserInfo(id);
            return Ok(user);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPut]
    [Route("/user")]
    public IActionResult UpdateUser([FromBody] UpdateUserModel request)
    {
        try
        {
            var validationResult = new UpdateUserModelValidator().Validate(request);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);
            var userModel = _usersManager.UpdateUser(request);
            return Ok(userModel);

        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpDelete]
    [Route("/user/{id:int}")]
    public IActionResult DeleteUser(int id)
    {
        try
        {
            _usersManager.DeleteUser(id);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}