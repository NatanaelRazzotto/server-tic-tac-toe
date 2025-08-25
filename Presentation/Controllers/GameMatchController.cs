using Microsoft.AspNetCore.Mvc;
using server_tic_tac_toe.Application.Services;
using server_tic_tac_toe.Application.UseCases;
using server_tic_tac_toe.Domain.Exceptions;

namespace server_tic_tac_toe.Controllers;


[ApiController]
[Route("api/[controller]")]
public class GameMatchController : ControllerBase
{
    private readonly CreateGameMatch _createGameMatch;
    private readonly FinishGameMatch _finishGameMatch;
    private readonly GameMatchService _gameMatchService;

    public GameMatchController(CreateGameMatch createMatch, GameMatchService gameMatchService,  FinishGameMatch finishGameMatch)
    {
        _finishGameMatch = finishGameMatch; 
        _createGameMatch = createMatch;
        _gameMatchService = gameMatchService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var gameMatch = await _gameMatchService.GetAllAsync();

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
    
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
           
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpPut("finish/{id}")]
    public async Task<IActionResult> FinishMatch(Guid id, [FromBody] UpdateGameMatchDto dto)
    {
        try
        {
            var updatedUser = await _finishGameMatch.ExecuteAsync(id, dto);
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
