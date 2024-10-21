using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ganbare.src.Entity;

namespace ganbare.src.Utils
{
    public class Logic
    {
        
        public int GetTotalScore { get; set; } = 0;// get the total score for all thr quizzes taken by user
        public int GetQuizScore { get; set; } = 0;// get the score based on the right anwsers
        public string? LevelScore { get; set; } 
        
    }
}