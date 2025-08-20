namespace server_tic_tac_toe.Models
{
    public class Move
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public Match AssociatedMatchId { get; private set; }
        public Match AssociatedMatch { get; private set; }

        public Guid ResponsiblePlayerId { get; private set; }
        public Player ResponsiblePlayer { get; private set; }

        public int PositionColumn { get; private set; }

        public int PositionRow { get; private set; }

        public char Symbol { get; private set; }

        public DateTime MovementTime { get; private set; }


        private Move() { }

        public Move(Match associatedMatch, Player responsiblePlayer, int positionColumn, int positionRow, char symbol, DateTime movementTime)
        {
            
        }




    }
}