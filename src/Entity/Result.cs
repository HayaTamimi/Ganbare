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

        public double? TotalScore { get; set; } = 0;

        //public TimeSpan? Speed { get; set; } // 0-1 
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;// can't be edited
        public required User User { get; set; } 
        public Guid? UserId { get; set; }

        //public Guid? QuizId { get; set; }

        public List<Quiz>? Quizzes { get; set; }

        public Guid LeaderboardId { get; set; }

    }
}
