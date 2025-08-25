

using Microsoft.AspNetCore.Mvc;
using server_tic_tac_toe.Application.Services;
using server_tic_tac_toe.Application.UseCases;
using server_tic_tac_toe.Domain.Exceptions;

[ApiController]
[Route("api/[controller]")]
public class MoveController : ControllerBase
{
    private readonly MakeMove _createMove;
    private readonly MoveService _moveService;

    public MoveController(MakeMove createMove, MoveService moveService)
    {
        _createMove = createMove;
        _moveService = moveService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var gameMatch = await _moveService.GetAllAsync();

            return Ok(gameMatch);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMoveDTO dto)
    {
       try
        {           
            Guid? gameMatchId = await _createMove.ExecuteAsync(dto);
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
