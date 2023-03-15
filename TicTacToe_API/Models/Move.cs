using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicTacToe_API.Models
{
    public class Move
    {
        public int? Id { get; set; }
        public int GameId { get; set; }
        [ForeignKey("GameId")]
        [ValidateNever]
        public Game Game { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public string Player { get; set; }
    }
}
