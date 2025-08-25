using server_tic_tac_toe.Domain.Enums;
using server_tic_tac_toe.Domain.Exceptions;

namespace server_tic_tac_toe.Domain.Entities
{
    public class GameMatch
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        // Referencia aos modelos
        public User FirstPlayer { get; private set; }
        public User SecondPlayer { get; private set; }

        // Referencia aos ids dos modelos
        public Guid FirstPlayerId { get; private set; }
        public Guid SecondPlayerId { get; private set; }

        public MatchStatus Status { get; private set; } = MatchStatus.InProgress;

        public DateTime? Closing { get; private set; }

        public DateTime Open { get; private set; }

        public ICollection<Move> MatchMovements { get; set; } = new List<Move>();

        public GameMatch()
        {

        }

        public GameMatch(User firstPlayer, User secondPlayer)
        {
            FirstPlayer = firstPlayer ?? throw new ArgumentNullException(nameof(firstPlayer));
            SecondPlayer = secondPlayer ?? throw new ArgumentNullException(nameof(secondPlayer));
            FirstPlayerId = firstPlayer.Id;
            SecondPlayerId = secondPlayer.Id;
            Status = MatchStatus.InProgress;
            Open = DateTime.UtcNow;   // inicializa abertura
            Closing = null;
        }

        // método de negócio para encerrar partida
        public void EndMatch( MatchStatus matchStatus ,User? firstPlayer, User? secondPlayer)
        {
            if (Status != MatchStatus.InProgress)
                throw new DomainException("A partida já foi encerrada.");   

             if (matchStatus == MatchStatus.InProgress)
                throw new DomainException("A partida deve ter um resultado.");          

            if (firstPlayer == null || secondPlayer == null)
                throw new DomainException("Um dos participantes nao foi informado");

            if (IsPlayerInMatch(firstPlayer) == false)
                  throw new DomainException("Player 1 não pertence à partida.");

            if (IsPlayerInMatch(secondPlayer)  == false)
                  throw new DomainException("Player 2 não pertence à partida.");

            
            Status = matchStatus;
            Closing = DateTime.UtcNow;   

        }

        public void CloseGame(MatchStatus finalStatus)
        {
            if (Status != MatchStatus.InProgress)
                throw new InvalidOperationException("Jogo já está finalizado.");

            Status = finalStatus;
            Closing = DateTime.UtcNow;
        }

        public bool IsPlayerInMatch(User player)
        {
            return FirstPlayer.Id == player.Id || SecondPlayer.Id == player.Id;
        }
        public MatchStatus WhoIsThePlayer(User player)
        {
            if (FirstPlayer.Id == player.Id)
                return MatchStatus.FirstPlayerWon;
            else if (SecondPlayer.Id == player.Id)
                return MatchStatus.SecondPlayerWon;

            throw new DomainException("O vencedor informado não pertence à partida.");
        }


        public bool HasMoveAt(int row, int column)
        {
            return MatchMovements.Any(m => m.PositionRow == row && m.PositionColumn == column);
        }

        





    }
}