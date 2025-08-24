using Microsoft.AspNetCore.Mvc;
using server_tic_tac_toe.Application.Services;
using server_tic_tac_toe.Application.UseCases;
using server_tic_tac_toe.Domain.Exceptions;

namespace server_tic_tac_toe.Controllers;


[ApiController]
[Route("api/gamematch")]
public class GameMatchController : ControllerBase
{
    private readonly CreateInitialGameMatch _createGameMatch;
    private readonly GameMatchService _gameMatchService;

    public GameMatchController(CreateInitialGameMatch createMatch, GameMatchService gameMatchService)
    {
        _createGameMatch = createMatch;
          _gameMatchService = gameMatchService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
           Console.WriteLine("ex testado");
        try
        {
            var gameMatch = await _gameMatchService.GetAllAsync();
            // var dtoList = users.Select(u => new UserDto
            // {
            //     id = u.Id,
            //     name = u.Name,
            //     nickname = u.Nickname,
            //     email = u.Email
            // }).ToList();

            return Ok(gameMatch);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateGameMatchDto dto)
    {
       try
        {           
            Guid? gameMatchId = await _createGameMatch.ExecuteAsync(dto);
            return Ok(new { id = gameMatchId });
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
    
}
