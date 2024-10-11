using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ganbare.src.Entity
{
    public class Result
    {
        [Key]
        public Guid ResultId { get; set; }
        public int Score { get; set; } // it supposed to be included manually after the user finish the quiz 

        public string Duration { get; set; } // it supposed to be included manually after the user finish the quiz 

        public Guid? UserId { get; set; }
        public Guid? LeaderboardId { get; set; }

    }
}