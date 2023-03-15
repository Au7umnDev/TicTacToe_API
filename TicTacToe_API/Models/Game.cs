using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace TicTacToe_API.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Player1Id { get; set; }
        public string Player2Id { get; set; }
        public string? CurrentTurn { get; set; }
        public string? WinnerId { get; set; }
        public bool? IsDraw { get; set; }
    }
}
