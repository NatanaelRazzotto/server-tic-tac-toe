using Microsoft.AspNetCore.Mvc;
using server_tic_tac_toe.Application.UseCases;

namespace server_tic_tac_toe.Controllers;


[ApiController]
[Route("api/[controller]")]
public class GameMatchController : ControllerBase
{
    private readonly CreateGameMatch _createGameMatch;
}
