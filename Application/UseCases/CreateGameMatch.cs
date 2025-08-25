using server_tic_tac_toe.Application.Services;
using server_tic_tac_toe.Domain.UseCases;
using server_tic_tac_toe.Domain.Entities;
using server_tic_tac_toe.Domain.Exceptions;

namespace server_tic_tac_toe.Application.UseCases
{
    public class CreateGameMatch //: IUseCases<GameMatch>
    {
        private readonly GameMatchService _gameMatchservice;
        private readonly UserService _userService;

        public CreateGameMatch(GameMatchService service, UserService userService)
        {
            _gameMatchservice = service;
            _userService = userService;
        }

        public async Task<Guid> ExecuteAsync(CreateGameMatchDto dto)
        {

          // Buscar usuários
            var firstPlayer = await _userService.GetByIdAsync(dto.firstPlayerId)
                ?? throw new DomainException("Primeiro jogador não encontrado.");

            var secondPlayer = await _userService.GetByIdAsync(dto.secondPlayerId)
                ?? throw new DomainException("Segundo jogador não encontrado.");

            // Validar disponibilidade dos jogadores
            //await _gameMatchservice.ValidatePlayersAvailability(firstPlayer, secondPlayer);

            return await _gameMatchservice.CreateAsync(firstPlayer, secondPlayer);
        }
    }

}