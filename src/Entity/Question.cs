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
        [Key]
        public Guid QuestionId { get; set; }

        [Required, StringLength(50, MinimumLength = 5,
        ErrorMessage = "Question must be between 5 and 50 characters.")]
        public string JpQuestion { get; set; }

        [Required]
        public string Options { get; set; }

        [Required]
        public string Anwser { get; set; }

        [Required]
        public Level Jlptlevel { get; set; }

        public Guid? QuizId { get; set; }

    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Level
    {
        N5,
        N4,
        N3,
        N2,
        N1
    }
}