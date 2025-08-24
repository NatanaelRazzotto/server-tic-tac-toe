using System.ComponentModel.DataAnnotations;

namespace server_tic_tac_toe.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        [Required]              // Campo obrigatório
        [MaxLength(50)]          // Máximo de 50 caracteres
        public string Name { get; private set; }
        [Required]              // Campo obrigatório
        [MaxLength(15)]          // Máximo de 15 caracteres
        public string Nickname { get; private set; }
        [Required]              // Campo obrigatório
        [MaxLength(100)]          // Máximo de 50 caracteres
        public string Email { get; private set; }

        public ICollection<GameMatch> MatchesAsFirstPlayer { get; set; } = new List<GameMatch>();
        public ICollection<GameMatch> MatchesAsSecondPlayer { get; set; } = new List<GameMatch>();

        public ICollection<Move> PlayerMovements { get; set; } = new List<Move>();


        // Construtor para o EF
        private User() { }

        // Construtor de domínio
        public User(string name, string nickname, string email)
        {
            UpdateName(name);
            UpdateNickname(nickname);
            UpdateEmail(email);
        }

        // Método de domínio para mudar o nome
        public void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Nome não pode ser vazio.");

            Name = name;
        }

        public void UpdateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new ArgumentException("E-mail inválido.");

            Email = email;
        }
        
        public void UpdateNickname(string nickname)
        {
            if (string.IsNullOrWhiteSpace(nickname))
                throw new ArgumentException("Nickname não pode ser vazio.");

                Nickname = nickname;
            }
        }
}