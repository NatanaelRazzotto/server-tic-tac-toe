using Microsoft.EntityFrameworkCore;
using server_tic_tac_toe.Domain.Entities;
using server_tic_tac_toe.Domain.Repositories;
using server_tic_tac_toe.Infrastructure.Persistence;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace server_tic_tac_toe.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<User?> GetByEmailOrNicknameAsync(string email, string nickname, Guid excludeUserId)
        {
            return await _dbSet
                .Where(u => (u.Email == email || u.Nickname == nickname) && u.Id != excludeUserId)
                .FirstOrDefaultAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(p => p.Email == email);
        }

        public async Task<User?> GetByNameAsync(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(p => p.Name == name);
        }

        }
}