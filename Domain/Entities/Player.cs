namespace server_tic_tac_toe.Domain.Entities
{
    public class Player
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }

        public ICollection<GameMatch> MatchesAsFirstPlayer { get; set; } = new List<GameMatch>();
        public ICollection<GameMatch> MatchesAsSecondPlayer { get; set; } = new List<GameMatch>();

        public ICollection<Move> PlayerMovements { get; set; } = new List<Move>();


        // Construtor para o EF
        private Player() { }

        // Construtor de domínio
        public Player(string name)
        {
            Name = name;
        }

        // Método de domínio para mudar o nome
        public void ChangeName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Nome inválido.");

            Name = newName;
        }
    }
}