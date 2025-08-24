using Microsoft.AspNetCore.Mvc;
using server_tic_tac_toe.Application.UseCases;
using server_tic_tac_toe.Domain.Exceptions;
using server_tic_tac_toe.Domain.Entities;
using server_tic_tac_toe.Application.Services;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserService _userService;
    private readonly CreateUser _createUser;
    private readonly UpdateUser _updateUser;

    public UsersController(
        CreateUser createUser,
        UserService userService,
        UpdateUser updateUser)
    {
        _userService = userService;
        _createUser = createUser;      
        _updateUser = updateUser;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
           Console.WriteLine("ex testado");
        try
        {
            var users = await _userService.GetAllAsync();
            var dtoList = users.Select(u => new UserDto
            {
                id = u.Id,
                name = u.Name,
                nickname = u.Nickname,
                email = u.Email
            }).ToList();

            return Ok(dtoList);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }



    // POST /api/users
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
    {
        
        try
        {
            Console.WriteLine($"Recebido CreateUserDto: Name={dto.name}, Nickname={dto.nickname}, Email={dto.email}");
            Guid? userId = await _createUser.ExecuteAsync(dto);
            return Ok(new { id = userId });
        }
        catch (DomainException ex)
        {
            Console.WriteLine(ex);
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
              Console.WriteLine(ex);
            return StatusCode(500, new { message = ex.Message });
        }
    }

    // // GET /api/users/{id}
    // [HttpGet("{id}")]
    // public async Task<IActionResult> GetById(Guid id)
    // {
    //     try
    //     {
    //         var user = await _getUserById.ExecuteAsync(id);
    //         if (user == null) return NotFound();
    //         return Ok(user);
    //     }
    //     catch (Exception ex)
    //     {
    //         return StatusCode(500, new { message = ex.Message });
    //     }
    // }

    // PUT /api/users/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] CreateUserDto dto)
    {
        try
        {
            var updatedUser = await _updateUser.ExecuteAsync( dto);
            return Ok(updatedUser);
        }
        catch (DomainException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }
}
