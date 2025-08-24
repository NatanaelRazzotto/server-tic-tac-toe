using server_tic_tac_toe.Domain.Enums;

public class CreateGameMatchDto
{
    public Guid firstPlayerId { get; set; }
    public Guid secondPlayerId { get; set; }
    public MatchStatus status { get; set; }
    public DateTime open { get; set; }
}
