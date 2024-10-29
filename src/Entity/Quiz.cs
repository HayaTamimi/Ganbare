using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ganbare.src.Entity
{//GET /api/quizzes/levels/{level_id}/: Retrieve or update a specific level.
// GET /api/quizzes/{quiz_id}/questions/: Retrieve a list of questions for a specific quiz or create a new question.
// GET /api/quizzes/start/: Start a quiz by providing the quiz ID.
// POST /api/quizzes/submit/: Submit a quiz with the answers.
    public class Quiz
    {
        //We will have an array of questions and their options 
        //(including correct answers) in the quiz as a navigation property,
        // and we can easily get the score of each question of the 
        //number/percentage of questions passed/failed.
        public Guid QuizId { get; set; }

        // if above 80% then pass if not then fail (80% = 8 out of 10 questions)

        public int QuizScore { get; set; } = 0; // this is the score by default


        // caculate the time taken
        //public float TimeTaken { get; set; } // changed the previous name which was duration

        // to caculate the time taken (better than the above idea)
        //public DateTime StartTime { get; set; } = DateTime.Now;
        //public DateTime EndTime { get; set; }

        public float? TimeTaken { get; set; }

        public QuizLevel Level { get; set; }

        [Required]
        [Range(10, 10)]  // 10 Questions in each Quiz
        public List<Question> Questions { get; set; }

        public Guid? UserId { get; set; } // id always in many side 

        public Guid? ResultId { get; set; } // id always in many side

    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum QuizLevel // QuizScore caculated depending on the level
    {
        One, // easiest level
        Two,
        Three,
        Four,
        Five // hardest level
    }
}