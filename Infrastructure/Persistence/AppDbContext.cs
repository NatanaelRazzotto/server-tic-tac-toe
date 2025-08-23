using Microsoft.EntityFrameworkCore;
using server_tic_tac_toe.Domain.Entities;

namespace server_tic_tac_toe.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Players => Set<User>();
        public DbSet<GameMatch> GameMatches => Set<GameMatch>();
        public DbSet<Move> Moves => Set<Move>();
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Match → Player primario

            modelBuilder.Entity<GameMatch>()
            .HasOne(match => match.FirstPlayer)
            .WithMany(player => player.MatchesAsFirstPlayer)
            .HasForeignKey(match => match.FirstPlayerId)
            .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento Match → Player (SecondPlayer)
            modelBuilder.Entity<GameMatch>()
           .HasOne(match => match.SecondPlayer)
           .WithMany(player => player.MatchesAsSecondPlayer)
           .HasForeignKey(match => match.SecondPlayerId)
           .OnDelete(DeleteBehavior.Restrict);


            // Relacionamento Move → Match 

            modelBuilder.Entity<Move>()
            .HasOne(move => move.AssociatedMatch)
            .WithMany(math => math.MatchMovements)
            .HasForeignKey(move => move.AssociatedMatchId)
            .OnDelete(DeleteBehavior.Restrict);
            
            // Relacionamento Move → Player 

            modelBuilder.Entity<Move>()
            .HasOne(move => move.ResponsiblePlayer)
            .WithMany(player => player.PlayerMovements)
            .HasForeignKey(move => move.ResponsiblePlayerId)
            .OnDelete(DeleteBehavior.Restrict);


        }
       
    }
}
