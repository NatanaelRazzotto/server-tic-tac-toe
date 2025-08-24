using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using server_tic_tac_toe.Domain.Entities;
using server_tic_tac_toe.Domain.Enums;

namespace server_tic_tac_toe.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<GameMatch> GameMatches => Set<GameMatch>();
        public DbSet<Move> Moves => Set<Move>();
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User

            modelBuilder.Entity<User>()
                .HasIndex(user => user.Nickname)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(user => user.Email)
                .IsUnique();

            // Match → Player primario

            modelBuilder.Entity<GameMatch>()
            .HasOne(match => match.FirstPlayer)
            .WithMany(player => player.MatchesAsFirstPlayer)
            .HasForeignKey(match => match.FirstPlayerId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento Match → Player (SecondPlayer)
            modelBuilder.Entity<GameMatch>()
           .HasOne(match => match.SecondPlayer)
           .WithMany(player => player.MatchesAsSecondPlayer)
           .HasForeignKey(match => match.SecondPlayerId)
            .IsRequired()
           .OnDelete(DeleteBehavior.Restrict);

            // Converte MatchStatus para string no banco
            modelBuilder.Entity<GameMatch>()
                .Property(m => m.Status)
                .HasConversion(new EnumToStringConverter<MatchStatus>());




            // Relacionamento Move → Match 

            modelBuilder.Entity<Move>()
            .HasOne(move => move.AssociatedMatch)
            .WithMany(math => math.MatchMovements)
            .HasForeignKey(move => move.AssociatedMatchId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento Move → Player 

            modelBuilder.Entity<Move>()
            .HasOne(move => move.ResponsiblePlayer)
            .WithMany(player => player.PlayerMovements)
            .HasForeignKey(move => move.ResponsiblePlayerId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Move>()
                .Property(m => m.TypeOfPlay)
                .HasConversion(new EnumToStringConverter<TypePlay>());
            


        }
       
    }
}
