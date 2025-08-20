using server_tic_tac_toe.Domain.Entities;

namespace server_tic_tac_toe.Domain.Repositories
{
    public interface IPlayerRepository
    {
        Task<Player?> GetByNameAsync(string name);
    }
}