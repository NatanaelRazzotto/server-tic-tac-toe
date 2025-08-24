using server_tic_tac_toe.Domain.Entities;
using server_tic_tac_toe.Domain.Exceptions;
using server_tic_tac_toe.Domain.Repositories;
using server_tic_tac_toe.Infrastructure.Repositories;

namespace server_tic_tac_toe.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {

            var user = await _repository.GetByIdAsync(id);
            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {

            var users = await _repository.GetAllAsync();
            return users;
        }

        public async Task<int> CreateAsync(CreateUserDto dto)
        {
            User? existing = await _repository.GetByEmailAsync(dto.email);
            if (existing != null)
                throw new DomainException("E-mail já cadastrado.");

            User user = new User(dto.name, dto.nickname, dto.email);

            return await _repository.AddAsync(user);
        }
        
        public async Task<int> UpdateAsync(Guid id, string name, string email)
        {
            var user = await _repository.GetByIdAsync(id)
                    ?? throw new DomainException("Usuário não encontrado.");

            user.UpdateName(name);
            user.UpdateEmail(email);
            
            return await _repository.UpdateAsync(user);
        }
    }

}