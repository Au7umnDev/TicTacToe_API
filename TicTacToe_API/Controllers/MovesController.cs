using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using TicTacToe_API.Data;
using TicTacToe_API.Models;

namespace TicTacToe_API.Controllers
{
    [ApiController]
    [Route("api/games/{gameId}/[controller]")]
    public class MovesController : ControllerBase
    {
        private readonly TicTacToeContext _context;

        public MovesController(TicTacToeContext context)
        {
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all moves from a game", Description = "Gets all moves from a game with a written {id}")]
        public async Task<ActionResult<IEnumerable<Move>>> GetMoves(int gameId)
        {
            var game = await _context.Games.FindAsync(gameId);
            if (game == null)
            {
                return NotFound();
            }

            return await _context.Moves.Where(m => m.GameId == gameId).ToListAsync();
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get a single move info", Description = "Gets a single move info with a written game {id} and move {id}")]
        public async Task<ActionResult<Move>> GetMove(int gameId, int id)
        {
            var game = await _context.Games.FindAsync(gameId);

            if (game == null)
            {
                return NotFound();
            }

            var move = await _context.Moves.FindAsync(id);

            if (move == null)
            {
                return NotFound();
            }

            return move;
        }
    }
}
