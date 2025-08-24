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

        public async Task<User?> GetByNameAsync(string name)
        {
            return await _context.Users.FirstOrDefaultAsync(p => p.Name == name);
        }
        
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(p => p.Email == email);
        }
    }
}