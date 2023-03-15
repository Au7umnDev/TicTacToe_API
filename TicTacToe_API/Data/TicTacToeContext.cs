using Microsoft.EntityFrameworkCore;
using TicTacToe_API.Models;

namespace TicTacToe_API.Data
{
    public class TicTacToeContext : DbContext
    {
        public TicTacToeContext(DbContextOptions<TicTacToeContext> options) : base(options)
        {

        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Move> Moves { get; set; }

/*        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasMany(g => g.Moves)
                .WithOne(m => m.Game)
                .HasForeignKey(m => m.GameId);
        }
*/    }
}
