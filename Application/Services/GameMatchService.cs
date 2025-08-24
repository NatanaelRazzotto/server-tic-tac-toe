using server_tic_tac_toe.Domain.Entities;
using server_tic_tac_toe.Domain.Exceptions;
using server_tic_tac_toe.Domain.Repositories;

namespace server_tic_tac_toe.Application.Services
{
    public class GameMatchService
    {
        private readonly IGameMatchRepository _gameMatchRepository;
           private readonly UserService _userService;

        public GameMatchService(IGameMatchRepository gameMatchRepository, UserService userService)
        {
            _gameMatchRepository = gameMatchRepository;
            _userService = userService;
        }

        public async Task<IEnumerable<GameMatch>> GetAllAsync()
        {

            var users = await _gameMatchRepository.GetAllAsync();
            return users;
        }

        public async Task<int> CreateAsync(CreateGameMatchDto dto)
        {

             // Buscar usuários
            var firstPlayer = await _userService.GetByIdAsync(dto.firstPlayerId)
                ?? throw new DomainException("Primeiro jogador não encontrado.");

            var secondPlayer = await _userService.GetByIdAsync(dto.secondPlayerId)
                ?? throw new DomainException("Segundo jogador não encontrado.");

            // Aqui poderia ter outras regras, ex.: jogadores não podem ser iguais
            if (firstPlayer.Id == secondPlayer.Id)
                throw new DomainException("Jogadores não podem ser iguais.");

            //Validar negocio
            GameMatch user = new GameMatch(firstPlayer, secondPlayer);

            return await _gameMatchRepository.AddAsync(user);
        }
    }

}