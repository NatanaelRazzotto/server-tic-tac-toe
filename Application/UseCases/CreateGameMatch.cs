using server_tic_tac_toe.Application.Services;
using server_tic_tac_toe.Domain.UseCases;
using server_tic_tac_toe.Domain.Entities;

namespace server_tic_tac_toe.Application.UseCases
{
    public class CreateGameMatch //: IUseCases<GameMatch>
    {
        private readonly GameMatchService _service;

          public CreateGameMatch(GameMatchService service)
        {
            _service = service;
        }

        public async Task<Guid> ExecuteAsync(CreateGameMatchDto dto)
        {
           return await _service.CreateAsync(dto);
        }
    }

}