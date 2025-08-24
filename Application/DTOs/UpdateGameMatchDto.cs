using server_tic_tac_toe.Domain.Enums;

public class UpdateGameMatchDto
{
    public Guid firstPlayerId { get; set; }

    public Guid secondPlayerId { get; set; }
    public Guid gameMatchId { get; set; }

    public MatchStatus statusWinner { get; set; }

}
