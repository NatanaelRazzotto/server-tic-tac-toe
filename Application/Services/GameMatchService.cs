using server_tic_tac_toe.Domain.Entities;
using server_tic_tac_toe.Domain.Exceptions;
using server_tic_tac_toe.Domain.Repositories;

namespace server_tic_tac_toe.Application.Services
{
    public class GameMatchService
    {
        private readonly IGameMatchRepository _gameMatchRepository;


        public GameMatchService(IGameMatchRepository gameMatchRepository)
        {
            _gameMatchRepository = gameMatchRepository;

        }

        public async Task<IEnumerable<GameMatch>> GetAllAsync()
        {

            var users = await _gameMatchRepository.GetAllAsync();
            return users;
        }

        public async Task<Guid> CreateAsync(User firstPlayer, User secondPlayer)
        {
            // Aqui só regras de negócio da entidade
            if (firstPlayer.Id == secondPlayer.Id)
                throw new DomainException("Jogadores não podem ser iguais.");

            //Validar negocio
            GameMatch gameMatch = new GameMatch(firstPlayer, secondPlayer);

            GameMatch returnGameMatch = await _gameMatchRepository.AddAsync(gameMatch);

            return returnGameMatch.Id;
        }
        
         // Validação de regras entre agregados
        public async Task ValidatePlayersAvailability(User firstPlayer, User secondPlayer)
        {
            var activeMatches = await _gameMatchRepository.GetAllAsync();

            if (activeMatches.Any(m => m.FirstPlayer.Id == firstPlayer.Id || m.SecondPlayer.Id == firstPlayer.Id))
                throw new DomainException("Primeiro jogador já está em uma partida ativa.");

            if (activeMatches.Any(m => m.FirstPlayer.Id == secondPlayer.Id || m.SecondPlayer.Id == secondPlayer.Id))
                throw new DomainException("Segundo jogador já está em uma partida ativa.");
        }
    }

}