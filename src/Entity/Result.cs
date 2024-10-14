using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ganbare.src.Entity
{
    public class Result
    {
        public Guid ResultId { get; set; }

        // TotalScore caculated depending on the level 
        // for exampel
        public double TotalScore { get; set; } = 0; // to display in the leaderbaord

        //change the time and type of data // 100%
        public float Speed { get; set; } // 0-1 
        public Guid? UserId { get; set; }
        public Guid LeaderboardId { get; set; } // caculated using score

    }
}