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
            public string QuestionText { get; set; }

            [Required]
            public string Answer { get; set; }
            // public QuestionLevel Jlptlevel { get; set; } not needed

            //public List<Option> Options { get; set; }

            //  public Guid? QuizId { get; set; } // maybe add it later?

        }

        public class QuestionReadDto
        {
            public Guid QuestionId { get; set; }

            public string QuestionText { get; set; }

            public string Answer { get; set; }

            //public QuestionLevel Jlptlevel { get; set; } not important

            public Guid? QuizId { get; set; }

            public List<Option> Options { get; set; }


        }

        public class QuestionUpdateDto
        {
            // [Required, StringLength(50, MinimumLength = 5,
            // ErrorMessage = "Question must be between 5 and 50 characters.")]
            // public string? QuestionText { get; set; }

            // public string? Answer { get; set; }

          // public List<Option> Options { get; set; }

            public Guid? QuizId { get; set; }

        }
    }
}