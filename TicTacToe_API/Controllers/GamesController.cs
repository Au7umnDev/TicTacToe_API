using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using TicTacToe_API.Data;
using TicTacToe_API.Models;

namespace TicTacToe_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly TicTacToeContext _context;

        public GamesController(TicTacToeContext context)
        {
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all games info", Description = "Returns a list of all games")]
        public async Task<ActionResult<IEnumerable<Game>>> GetGames()
        {
            return await _context.Games.ToListAsync();
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get a single game info", Description = "Returns a single game info")]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
            var game = await _context.Games.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return game;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a single game", Description = "Creates a single game")]
        public async Task<ActionResult<Game>> CreateGame(Game game)
        {
            game.IsDraw = false;
            game.CurrentTurn = game.Player1Id;

            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGame), new { id = game.Id }, game);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Make a move", Description = "Makes a move in a game with a written {id}")]
        public async Task<IActionResult> MakeMove(int id, Move move)
        {
            var game = await _context.Games.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            // check if the game is over in a draw
            if (game.IsDraw == true)
            {
                return BadRequest("Game is already over. It's a draw!");
            }

            // check if the game is over in a player's victory
            if (!string.IsNullOrEmpty(game.WinnerId))
            {
                return BadRequest($"Game is already over. {game.WinnerId} won!");
            }

            // check if it's the player's turn
            if (move.Player != game.CurrentTurn)
            {
                return BadRequest("It's not your turn");
            }

            // check if the move is valid
            if (move.Row < 0 || move.Row > 2 || move.Column < 0 || move.Column > 2)
            {
                return BadRequest("Invalid move");
            }

            // check if the spot is already taken
            var existingMove = await _context.Moves
                .FirstOrDefaultAsync(m => m.GameId == id && m.Row == move.Row && m.Column == move.Column);
            if (existingMove != null)
            {
                return BadRequest("Spot is already taken");
            }

            // add the move to the database
            move.GameId = id;
            _context.Moves.Add(move);
            await _context.SaveChangesAsync();

            // fill the gameMoves arr
            var allGameMoves = _context.Moves.Where(m => m.GameId == id).ToList();

            string[,] gameMoves = new string[3,3];
            
            foreach(var el in allGameMoves)
            {
                gameMoves[el.Row,el.Column] = el.Player;
            }

            // check if the game is over
            var winnerId = CheckForWinner(game, gameMoves);

            if (!string.IsNullOrEmpty(winnerId))
            {
                game.WinnerId = winnerId;
                game.CurrentTurn = "";
                await _context.SaveChangesAsync();
                return Ok($"{winnerId} wins!");
            }

            //if some element is empty -> not a draw
            bool notDraw = false;
            for (int i = 0; i < 3; i++)
            {
                if (notDraw) break;

                for (int j = 0; j < 3; j++)
                {
                    if (string.IsNullOrEmpty(gameMoves[i, j]))
                    {
                        notDraw = true;
                        break;
                    }
                }
            }

            if (!notDraw)
            {
                game.IsDraw = true;
                game.CurrentTurn = "";
                await _context.SaveChangesAsync();
                return Ok("It's a draw!");
            }

            // update the current turn
            game.CurrentTurn = game.CurrentTurn == game.Player1Id ? game.Player2Id : game.Player1Id;
            await _context.SaveChangesAsync();

            return Ok("Made a move!");
        }

        private string? CheckForWinner(Game? thisGame, string[,] gameMoves)
        {
            // check rows
            for (int row = 0; row < 3; row++)
            {
                if (!string.IsNullOrEmpty(gameMoves[row, 0]) &&
                    gameMoves[row, 0] == gameMoves[row, 1] &&
                    gameMoves[row, 0] == gameMoves[row, 2])
                {
                    return gameMoves[row, 0];
                }
            }

            // check columns
            for (int col = 0; col < 3; col++)
            {
                if (!string.IsNullOrEmpty(gameMoves[0, col]) &&
                    gameMoves[0, col] == gameMoves[1, col] &&
                    gameMoves[0, col] == gameMoves[2, col])
                {
                    return gameMoves[0, col];
                }
            }

            // check diagonals
            if (!string.IsNullOrEmpty(gameMoves[0, 0]) &&
                gameMoves[0, 0] == gameMoves[1, 1] &&
                gameMoves[0, 0] == gameMoves[2, 2])
            {
                return gameMoves[0, 0];
            }

            if (!string.IsNullOrEmpty(gameMoves[0, 2]) &&
                gameMoves[0, 2] == gameMoves[1, 1] &&
                gameMoves[0, 2] == gameMoves[2, 0])
            {
                return gameMoves[0, 2];
            }

            return null;
        }
    }
}
