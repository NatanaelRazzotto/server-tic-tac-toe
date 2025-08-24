using Microsoft.EntityFrameworkCore;
using server_tic_tac_toe.Domain.Entities;
using server_tic_tac_toe.Domain.Repositories;
using server_tic_tac_toe.Infrastructure.Persistence;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace server_tic_tac_toe.Infrastructure.Repositories
{
    public class GameMatchRepository : Repository<GameMatch>, IGameMatchRepository
    {

        public GameMatchRepository(AppDbContext context) : base(context)
        {

        }

       public override async Task<IEnumerable<GameMatch>> GetAllAsync()
    {
        return await _dbSet
            .Include(m => m.FirstPlayer)
            .Include(m => m.SecondPlayer)
            .Include(m => m.MatchMovements)
            .ToListAsync();
    }
        
    }


}