using server_tic_tac_toe.Domain.Enums;

namespace server_tic_tac_toe.Domain.Entities
{
    public class GameMatch
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        // Referencia aos modelos
        public Player FirstPlayer { get; private set; }
        public Player SecondPlayer { get; private set; }

        // Referencia aos ids dos modelos
        public Guid FirstPlayerId { get; private set; }
        public Guid SecondPlayerId { get; private set; }

        public MatchStatus Status { get; private set; } = MatchStatus.InProgress;

        public DateTime Closing { get; private set; }

        public ICollection<Move> MatchMovements { get; set; } = new List<Move>();
        
        private GameMatch()
        {
            
        }

        private GameMatch(Player firstPlayer, Player secondPlayer)
        {
            FirstPlayer = firstPlayer ?? throw new ArgumentNullException(nameof(firstPlayer));
            SecondPlayer = secondPlayer ?? throw new ArgumentNullException(nameof(secondPlayer));
            FirstPlayerId = firstPlayer.Id;
            SecondPlayerId = secondPlayer.Id;
            Status = MatchStatus.InProgress;
        }
        





    }
}