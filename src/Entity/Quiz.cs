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
    public class Quiz
    {
        public Guid QuizId { get; set; }

        public int QuizScore { get; set; } = 0; 

        public float? TimeTaken { get; set; }

        public QuizLevel Level { get; set; }

        [Required]
        public List<Question> Questions { get; set; }

        public Guid? UserId { get; set; }  

        public Guid? ResultId { get; set; } 

    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum QuizLevel 
    {
        N5, // easiest level
        N4,
        N3,
        N2,
        N1 // hardest level
    }
}