using server_tic_tac_toe.Domain.Entities;
using server_tic_tac_toe.Domain.Enums;
using server_tic_tac_toe.Domain.Exceptions;
using server_tic_tac_toe.Domain.Repositories;

namespace server_tic_tac_toe.Application.Services
{
    public class MoveService
    {
        private readonly IRepository<Move> _moveRepository;


        public MoveService(IRepository<Move> moveRepository)
        {
            _moveRepository = moveRepository;

        }

        public async Task<IEnumerable<Move>> GetAllAsync()
        {
            var movers = await _moveRepository.GetAllAsync();
            return movers;
        }

        public async Task<Guid> CreateAsync(
            GameMatch associatedMatch,
            User responsiblePlayer,
            int positionColumn,
            int positionRow,
            TypePlay typeOfPlay
            )
        {
            //  Regras de negócio da jogada
            if (positionRow < 0 || positionRow > 2 || positionColumn < 0 || positionColumn > 2)
                throw new DomainException("Posição inválida. O tabuleiro é 3x3.");

            if (associatedMatch.HasMoveAt(positionRow, positionColumn))
                throw new DomainException("Esta posição já foi ocupada.");

            // Criar entidade
            var move = new Move(associatedMatch, responsiblePlayer, positionColumn, positionRow, typeOfPlay);

            //  Persistir
            var returnMove = await _moveRepository.AddAsync(move);

            return returnMove.Id;
        }

    }

}