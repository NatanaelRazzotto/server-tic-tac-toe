using server_tic_tac_toe.Domain.Enums;

namespace server_tic_tac_toe.Domain.Entities
{
    public class Move
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public Guid AssociatedMatchId { get; private set; }
        public GameMatch AssociatedMatch { get; private set; }

        public Guid ResponsiblePlayerId { get; private set; }
        public User ResponsiblePlayer { get; private set; }

        public int PositionColumn { get; private set; }

        public int PositionRow { get; private set; }

        public TypePlay TypeOfPlay { get; private set; } = TypePlay.NoneType;

        public DateTime MovementTime { get; private set; }


        private Move() { }

        public Move(GameMatch associatedMatch, User responsiblePlayer, int positionColumn, int positionRow, TypePlay typeOfPlay)
        {
            AssociatedMatch = associatedMatch ?? throw new ArgumentNullException(nameof(associatedMatch));
            ResponsiblePlayer = responsiblePlayer ?? throw new ArgumentNullException(nameof(responsiblePlayer));
            AssociatedMatchId = associatedMatch.Id;
            ResponsiblePlayerId = responsiblePlayer.Id;
            PositionColumn = positionColumn;
            PositionRow = positionRow;
            TypeOfPlay = typeOfPlay;
            MovementTime = DateTime.UtcNow;    // = movementTime;
        }




    }
}