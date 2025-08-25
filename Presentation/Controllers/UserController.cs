using Microsoft.AspNetCore.Mvc;
using server_tic_tac_toe.Application.UseCases;
using server_tic_tac_toe.Domain.Exceptions;
using server_tic_tac_toe.Domain.Entities;
using server_tic_tac_toe.Application.Services;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;
    private readonly CreateUser _createUser;
    private readonly UpdateUser _updateUser;

    public UserController(
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
         
            Guid? userId = await _createUser.ExecuteAsync(dto);
            return Ok(new { id = userId });
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

    // PUT /api/users/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserDto dto)
    {
        try
        {
            var updatedUser = await _updateUser.ExecuteAsync(id, dto);
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
