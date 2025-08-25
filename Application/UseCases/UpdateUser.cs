using server_tic_tac_toe.Application.Services;
using server_tic_tac_toe.Domain.UseCases;
using server_tic_tac_toe.Domain.Entities;
using server_tic_tac_toe.Domain.Exceptions;

namespace server_tic_tac_toe.Application.UseCases
{
    public class UpdateUser //: IUseCases<User,CreateUserDto>
    {
        private readonly UserService _service;
        
        public UpdateUser(UserService userService)  
        {

            _service = userService;
        }

        public async Task<Guid> ExecuteAsync(Guid userId, UpdateUserDto dto)
        {
            // apenas validações de entrada simples, regras de negócio ficam na entidade/service
            if (string.IsNullOrWhiteSpace(dto.name) || string.IsNullOrWhiteSpace(dto.email) || string.IsNullOrWhiteSpace(dto.nickname))
                throw new DomainException("Nome, nickname e e-mail são obrigatórios.");

            return await _service.UpdateAsync(userId, dto);
        }
    }

}