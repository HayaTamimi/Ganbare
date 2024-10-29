using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ganbare.src.Entity
{
// GET /api/questions/{question_id}/answers/: Retrieve a list of answers for a specific question or create a new answer.
    public class Question
    {
        public Guid QuestionId { get; set; }

        [Required, StringLength(50, MinimumLength = 5,
        ErrorMessage = "Question must be between 5 and 50 characters.")]
        public string QuestionText { get; set; }

        [Required]
        public string Answer { get; set; }

       // public QuestionLevel Jlptlevel { get; set; } not important here

        public List<Option> Options { get; set; }

        public Guid? QuizId { get; set; }

    }

}