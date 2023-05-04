using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.Api.Features.Users.Contracts;
using PointOfSale.Api.Features.Users.Models;
using PointOfSale.Api.Features.Users.Repositories;

namespace PointOfSale.Api.Features.Users;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UsersController(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<UserResponse>> GetUsers()
    {
        var users = await _userRepository.FindAll();
        return _mapper.Map<List<UserResponse>>(users);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<UserResponse>> GetUser(int id)
    {
        var user = await _userRepository.FindById(id);

        if (user == null)
        {
            return NotFound();
        }

        return _mapper.Map<UserResponse>(user);
    }

    [HttpPost]
    public async Task<ActionResult> CreateUser(string password)
    {
        return Ok(password);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateUser(int id, UserDto userDto)
    {
        var alreadyExists = await _userRepository.AlreadyExists(id);

        if(!alreadyExists)
        {
            return NotFound();
        }

        var user = _mapper.Map<User>(userDto);
        user.Id = id;

        var result = await _userRepository.UpdateUser(user);

        if(result == 0) {
            return BadRequest();
        }

        return Ok("Usuario actualizado correctamente");
    }
}
