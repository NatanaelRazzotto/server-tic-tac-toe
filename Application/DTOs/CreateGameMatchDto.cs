using server_tic_tac_toe.Domain.Enums;

public class CreateGameMatchDto
{
    public string id { get; set; }
    public Guid firstPlayerId { get; set; }
    public Guid secondPlayerId { get; set; }
    public MatchStatus status { get; set; }
    public MatchStatus closing { get; set; }
}
