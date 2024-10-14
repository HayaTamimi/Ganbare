using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ganbare.src.Entity
{
    public class Option
    {
        public Guid OptionId { get; set; }
        public string Choice { get; set; } 

        // calculate the score based on the number of correct answers.
        public bool IsCorrect { get; set; } 

        public Guid? QuizId { get; set; } 
    }
}