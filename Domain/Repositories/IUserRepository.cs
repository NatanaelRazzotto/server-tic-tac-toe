using server_tic_tac_toe.Domain.Entities;

namespace server_tic_tac_toe.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByNameAsync(string name);

        Task<User?> GetByEmailAsync(string email);

        public Task<User?> GetByEmailOrNicknameAsync(string email, string nickname, Guid excludeUserId);
    }
}