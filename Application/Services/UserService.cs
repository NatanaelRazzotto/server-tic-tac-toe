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

        public async Task<Guid> CreateAsync(CreateUserDto dto)
        {
            User? existing = await _repository.GetByEmailAsync(dto.email);
            if (existing != null)
                throw new DomainException("E-mail já cadastrado.");

            User user = new User(dto.name, dto.nickname, dto.email);

            User returnUser = await _repository.AddAsync(user);
            return returnUser.Id;
        }
        
        public async Task<Guid> UpdateAsync(Guid userId,UpdateUserDto dto)
        {
            var user = await _repository.GetByIdAsync(userId)
                    ?? throw new DomainException("Usuário não encontrado.");

            var conflictUser = await _repository.GetByEmailOrNicknameAsync(dto.email, dto.nickname, userId);
            if (conflictUser != null)
            {
                if (conflictUser.Email == dto.email)
                    throw new DomainException("Já existe um usuário com este e-mail.");
                if (conflictUser.Nickname == dto.nickname)
                    throw new DomainException("Já existe um usuário com este nickname.");
            }

            user.UpdateName(dto.name);
            user.UpdateEmail(dto.email);
            user.UpdateNickname(dto.nickname);
            
            User returnUser = await _repository.UpdateAsync(user);
            return returnUser.Id;
        }
    }

}