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
        public string choice { get; set; }

        [Required]
        public bool IsCorrect { get; set; } = false;

        public Guid? QuestionId { get; set; }
    }
}