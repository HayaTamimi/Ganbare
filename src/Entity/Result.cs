using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ganbare.src.Entity
{
    public class Result // for the leaderboard
    {
        public Guid ResultId { get; set; }


        //var totalScoreSum = createDto.Results.Sum(r => r.TotalScore);
        //var userResults = results.Where(r =>
        //r.TotalScore == totalScoreSum).ToList();

        public double? TotalScore { get; set; } = 0;  //GetAll.Quiz.QuizScore

        public TimeSpan? Speed { get; set; } // 0-1 

        public Guid? UserId { get; set; }

        public List<Quiz>? Quizzes { get; set; }

        public Guid LeaderboardId { get; set; }

    } 
    } 
