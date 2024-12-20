using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ganbare.src.DTO
{
    public class OptionDTO
    {
        public class OptionCreateDto
        {

            [Required]
            public string Choice { get; set; }

            [Required]
            public bool IsCorrect { get; set; }

            // removed the ? because we don't want it consider null
            public Guid QuestionId { get; set; }


        }

        public class OptionReadDto
        {

            public Guid OptionId { get; set; }
            public string Choice { get; set; }
            public bool IsCorrect { get; set; }
            public Guid? QuestionId { get; set; }

        }

        public class OptionUpdateDto
        {
            [Required]
            public string Choice { get; set; }

            [Required]
            public bool IsCorrect { get; set; }

        }
    }
}