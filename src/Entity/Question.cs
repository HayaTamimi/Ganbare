using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ganbare.src.Entity
{
    public class Question // 10 Questions in each Quiz
    {
        public Guid QuestionId { get; set; }

        [Required, StringLength(50, MinimumLength = 5,
        ErrorMessage = "Question must be between 5 and 50 characters.")]
        public string QuestionText { get; set; }

        // [Required]
        //public string Options { get; set; } // change it to array

        [Required]
        public string Answer { get; set; }

        [Required]
        public QuestionLevel Jlptlevel { get; set; }

        public List<Option> Options { get; set; }

        public Guid? QuizId { get; set; }

    }

    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum QuestionLevel
    {
        One, // easiest level
        Two,
        Three,
        Four,
        Five // hardest level
    }
}