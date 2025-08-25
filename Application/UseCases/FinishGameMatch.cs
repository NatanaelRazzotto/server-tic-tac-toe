using server_tic_tac_toe.Application.Services;
using server_tic_tac_toe.Domain.Entities;
using server_tic_tac_toe.Domain.Enums;
using server_tic_tac_toe.Domain.Exceptions;

namespace server_tic_tac_toe.Application.UseCases
{
    public class FinishGameMatch
    {
        private readonly GameMatchService _gameMatchService;
        private readonly UserService _userService;

        public FinishGameMatch(GameMatchService gameMatchService, UserService userService)
        {
            _gameMatchService = gameMatchService;
            _userService = userService;
        }

        public async Task<Guid> ExecuteAsync(Guid gameMatchId, UpdateGameMatchDto updateGameMatchDto)
        {

            if (!Enum.IsDefined(typeof(MatchStatus), updateGameMatchDto.statusWinner))
                throw new DomainException("Status não encontrado.");

            User firstPlayerId = await _userService.GetByIdAsync(updateGameMatchDto.firstPlayerId)
                    ?? throw new DomainException("Participante não encontrado.");

            User secondPlayerId = await _userService.GetByIdAsync(updateGameMatchDto.secondPlayerId)
                    ?? throw new DomainException("Participante não encontrado.");
            

            return await _gameMatchService.EndMatchAsync(gameMatchId, updateGameMatchDto.statusWinner ,firstPlayerId, secondPlayerId);
        }
        
    }

}