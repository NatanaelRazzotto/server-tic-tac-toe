using Microsoft.EntityFrameworkCore;
using server_tic_tac_toe.Domain.Entities;
using server_tic_tac_toe.Domain.Repositories;
using server_tic_tac_toe.Infrastructure.Persistence;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace server_tic_tac_toe.Infrastructure.Repositories
{
    public class MoveRepository : Repository<Move>
    {

        public MoveRepository(AppDbContext context) : base(context)
        {

        }

    }

}