using Microsoft.AspNetCore.Mvc;
using server_tic_tac_toe.Application.UseCases;

namespace server_tic_tac_toe.Controllers;


[ApiController]
[Route("api/[controller]")]
public class GameMatchController : ControllerBase
{
    private readonly CreateGameMatch _createGameMatch;

    public GameMatchController(CreateGameMatch createMatch)
    {
        _createGameMatch = createMatch;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] string player1)
    {
        var match = await _createGameMatch.ExecuteAsync(player1);
        return Ok(match);
    }
    
}
