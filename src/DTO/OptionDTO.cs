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
            [Range(4, 4)]
            public string Choice { get; set; }

            [Required]
            public bool IsCorrect { get; set; }

            //public Guid? QuesitionId { get; set; } 

        }

        public class OptionReadDto
        {

            public Guid OptionId { get; set; }
            public string Choice { get; set; }
            public bool IsCorrect { get; set; }
            public Guid? QuesitionId { get; set; }

        }

        public class OptionUpdateDto
        {
            [Required]
            [Range(4, 4)]
            public string Choice { get; set; }

            [Required]
            public bool IsCorrect { get; set; }

        }
    }
}