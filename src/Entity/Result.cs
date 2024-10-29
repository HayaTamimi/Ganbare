using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ganbare.src.Entity
{
    public class Result // for the leaderboard
    {
        //copied from my backend project to study it
        // this is how we collect Book.Price * cartItems.Quantity
        public Guid ResultId { get; set; }

        // TotalScore caculated depending on the level 

        //var totalScoreSum = createDto.Results.Sum(r => r.TotalScore);
        //var userResults = results.Where(r =>
        //r.TotalScore == totalScoreSum).ToList();

        public double? TotalScore { get; set; } = 0;  //GetAll.Quiz.QuizScore

        //change the time and type of data // 100%
        public TimeSpan? Speed { get; set; } // 0-1 

        public Guid? UserId { get; set; }

        public List<Quiz>? Quizzes { get; set; }

        public Guid LeaderboardId { get; set; }

    } 
    } 
