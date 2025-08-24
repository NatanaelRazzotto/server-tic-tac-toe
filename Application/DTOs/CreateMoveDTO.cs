using server_tic_tac_toe.Domain.Enums;

public class CreateMoveDTO
{
    public Guid associatedMatchId { get; set; }
    public Guid responsiblePlayerId { get; set; }
    public int positionRow { get; set; }
    public int positionColumn { get; set; }
    public TypePlay typeOfPlay { get; set; }//
   // public DateTime movementTime { get; set; }



           
}
