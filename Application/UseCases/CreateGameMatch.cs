using server_tic_tac_toe.Application.Services;
using server_tic_tac_toe.Domain.UseCases;
using server_tic_tac_toe.Domain.Entities;

namespace server_tic_tac_toe.Application.UseCases
{
    public class CreateGameMatch : IUseCases<GameMatch>
    {
        private readonly GameMatchService _service;

        public Task<GameMatch> ExecuteAsync(string id)
        {
            throw new NotImplementedException();
        }
    }

}