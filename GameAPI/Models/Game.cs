using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameAPI.Models
{
    public class Game
    {
        [Required]
        public string GameName { get; set; }

        [Key]
        public int GameId { get; set; }
    }
}
