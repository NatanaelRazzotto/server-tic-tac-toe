namespace server_tic_tac_toe.Models
{
    public class Match
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        // Referencia aos modelos
        public Player FirstPlayer { get; private set; } 
        public Player SecondPlayer { get; private set; }

        // Referencia aos ids dos modelos
        public Guid FirstPlayerID { get; private set; } 
        public Guid SecondPlayerId { get; private set; } 
        


        private Match() { }





    }
}