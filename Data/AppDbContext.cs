using Microsoft.EntityFrameworkCore;
using server_tic_tac_toe.Models;

namespace server_tic_tac_toe.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Player> Players => Set<Player>();
        public DbSet<Match> Matches => Set<Match>();
        public DbSet<Move> Moves => Set<Move>();
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Match → Player primario

            modelBuilder.Entity<Match>()
            .HasOne(match => match.FirstPlayer)
            .WithMany(player => player.MatchesAsFirstPlayer)
            .HasForeignKey(match => match.FirstPlayerID)
            .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento Match → Player (SecondPlayer)
            modelBuilder.Entity<Match>()
           .HasOne(match => match.SecondPlayer)
           .WithMany(player => player.MatchesAsSecondPlayer)
           .HasForeignKey(match => match.SecondPlayerId)
           .OnDelete(DeleteBehavior.Restrict);


            // Relacionamento Move → Match 

            modelBuilder.Entity<Move>()
            .HasOne(move => move.AssociatedMatch)
            .WithMany()
            .HasForeignKey(move => move.AssociatedMatchId)
            .OnDelete(DeleteBehavior.Restrict);
            
            // Relacionamento Move → Player 

            modelBuilder.Entity<Move>()
            .HasOne(move => move.AssociatedMatch)
            .WithMany()
            .HasForeignKey(move => move.AssociatedMatchId)
            .OnDelete(DeleteBehavior.Restrict);


        }
       
    }
}
