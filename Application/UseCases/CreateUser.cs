using server_tic_tac_toe.Application.Services;
using server_tic_tac_toe.Domain.UseCases;
using server_tic_tac_toe.Domain.Entities;
using server_tic_tac_toe.Domain.Exceptions;

namespace server_tic_tac_toe.Application.UseCases
{
    public class CreateUser //IUseCases<User,CreateUserDto>
    {
        private readonly UserService _service;

        public CreateUser(UserService service)
        {
            _service = service;
        }

        public async Task<Guid?> ExecuteAsync(CreateUserDto dto)
        {
            // apenas validações de entrada simples, regras de negócio ficam na entidade/service
            if (string.IsNullOrWhiteSpace(dto.name) || string.IsNullOrWhiteSpace(dto.email) || string.IsNullOrWhiteSpace(dto.nickname))
                throw new DomainException("Nome e e-mail são obrigatórios.");

            return await _service.CreateAsync(dto);
        }
    }

}