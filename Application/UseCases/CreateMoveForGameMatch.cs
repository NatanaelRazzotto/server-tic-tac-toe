using server_tic_tac_toe.Application.Services;
using server_tic_tac_toe.Domain.Entities;
using server_tic_tac_toe.Domain.Enums;
using server_tic_tac_toe.Domain.Exceptions;

namespace server_tic_tac_toe.Application.UseCases
{
    public class CreateMoveForGameMatch
    {
        private readonly MoveService _moveService;
        private readonly GameMatchService _gameMatchService;
        private readonly UserService _userService;

        public CreateMoveForGameMatch(
            MoveService moveService, 
            GameMatchService gameMatchService, 
            UserService userService)
        {
            _moveService = moveService ?? throw new ArgumentNullException(nameof(moveService));
            _gameMatchService = gameMatchService ?? throw new ArgumentNullException(nameof(gameMatchService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public async Task<Guid> ExecuteAsync(CreateMoveDTO dto)
        {
            //  Buscar jogador responsável
            var player = await _userService.GetByIdAsync(dto.responsiblePlayerId)
                ?? throw new DomainException("Jogador não encontrado.");

            // Buscar partida vinculada
            var gameMatch = await _gameMatchService.GetByIdAsync(dto.associatedMatchId)
                ?? throw new DomainException("Partida não encontrada.");

            //  Regras de negócio adicionais (exemplos)
            if (!gameMatch.IsPlayerInMatch(player))
                throw new DomainException("Jogador não pertence a esta partida.");

            if (gameMatch.Status != MatchStatus.InProgress)
                throw new DomainException("A partida já foi finalizada, não é possível realizar jogadas.");

            //  Criar movimento
            return await _moveService.CreateAsync(
                gameMatch,
                player,
                dto.positionColumn,
                dto.positionRow,
                dto.typeOfPlay
                //dto.movementTime
            );
        }
    }
}
