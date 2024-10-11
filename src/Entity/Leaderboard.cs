using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ganbare.src.Entity
{
    public class Leaderboard
    {
        [Key]
        public Guid LeaderboardId { get; set; }
        public List<Result>? Results { get; set; }//= new List<Result>();
        
    }
}