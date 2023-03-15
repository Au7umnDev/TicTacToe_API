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

    }
}
