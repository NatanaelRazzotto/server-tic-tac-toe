namespace server_tic_tac_toe.Domain.Enums
{
    public enum MatchStatus
    {
        InProgress,// O jogo está em andamento, ainda não acabou
        FirstPlayerWon,  // O Primeiro jogador venceu
        SecondPlayerWon,  // O Segundo jogador venceu
        Draw  // O jogo terminou em empate (todas as casas preenchidas e ninguém venceu)
    }
}
