using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.Api.Domain.Interfaces;
using PointOfSale.Api.Features.Users.Contracts;

namespace PointOfSale.Api.Controllers;

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
}
