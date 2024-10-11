using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ganbare.src.Entity;
using static ganbare.src.Entity.Question;

namespace ganbare.src.DTO
{
    public class QuestionDTO
    {
        public class QuestionCreateDto
        {
            [Required, StringLength(50, MinimumLength = 5,
   ErrorMessage = "Question must be between 5 and 50 characters.")]
            public string JpQuestion { get; set; }
            public string Options { get; set; }

            public string Anwser { get; set; }
            public Level Jlptlevel { get; set; }

            public Guid? QuizId { get; set; }

        }

        public class QuestionReadDto
        {
            [Key]
            public Guid QuestionId { get; set; }

            public string JpQuestion { get; set; }

            public string Options { get; set; }

            public string Anwser { get; set; }

            public Level Jlptlevel { get; set; }

            public Guid? QuizID { get; set; }

        }

        public class QuestionUpdateDto
        {
            [Required, StringLength(50, MinimumLength = 5,
            ErrorMessage = "Question must be between 5 and 50 characters.")]
            public string? JpQuestion { get; set; }

            public string? Options { get; set; }

            public string? Anwser { get; set; }

        }
    }
}