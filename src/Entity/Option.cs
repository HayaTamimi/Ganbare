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

        [Required]
        [Range(4, 4)]
        public string choice { get; set; }

        // calculate the score based on the number of correct answers.

        [Required]
        public bool IsCorrect { get; set; }

        public Guid? QuesitionId { get; set; }
    }
}