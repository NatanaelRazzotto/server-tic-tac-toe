using Microsoft.EntityFrameworkCore;
using server_tic_tac_toe.Domain.Entities;
using server_tic_tac_toe.Domain.Repositories;
using server_tic_tac_toe.Infrastructure.Persistence;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace server_tic_tac_toe.Infrastructure.Repositories
{
    public class PlayerRepository : Repository<User>, IPlayerRepository
    {
        public PlayerRepository(AppDbContext context) : base(context)
        {

        }
        
        public async Task<User?> GetByNameAsync(string name)
        {
            return await _context.Users.FirstOrDefaultAsync(p => p.Name == name);
        }
    }
}