using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ganbare.src.Entity;

namespace ganbare.src.DTO
{
    public class ResultDTO
    {
        public class ResultCreateDto
        {
            public double? TotalScore { get; set; }
            public Guid LeaderboardId { get; set; }

            public DateTime? CreatedAt { get; private set; } = DateTime.UtcNow;// can't be edited

            //public double? Speed { get; set; }
            //public Quiz? Quiz { get; set; } //  instead of Quiz? Quiz, we only need the QuizId
            //public Guid? QuizId { get; set; }
            public Guid? UserId { get; set; }

            public List<Quiz>? Quizzes { get; set; } 

        }
        public class ResultReadDto
        {
            public Guid ResultId { get; set; }
            public double? TotalScore { get; set; }
            public List<Quiz> Quizzes { get; set; }
            public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;// can't be edited
            // public double? Speed { get; set; }
            public Guid? UserId { get; set; } 
            public required User User { get; set; } 
            public Guid? LeaderboardId { get; set; }

        }

        public class ResultUpdateDto
        {

           // public User User { get; set; }

        }
    }
}