namespace server_tic_tac_toe.Domain.Entities
{
    public class Move
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public Guid AssociatedMatchId { get; private set; }
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
            AssociatedMatch = associatedMatch ?? throw new ArgumentNullException(nameof(associatedMatch));
            ResponsiblePlayer = responsiblePlayer ?? throw new ArgumentNullException(nameof(responsiblePlayer));
            AssociatedMatchId = associatedMatch.Id;
            ResponsiblePlayerId = responsiblePlayer.Id;
            PositionColumn = positionColumn;
            PositionRow = positionRow;
            Symbol = symbol;
            MovementTime = movementTime;
        }




    }
}