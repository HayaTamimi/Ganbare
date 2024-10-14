using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ganbare.src.DTO
{
    public class OptionDTO
    {
        public class OptionCreateDto
        {
        public string Choice { get; set; } 

        public bool IsCorrect { get; set; } 

        //public Guid? QuizId { get; set; } 

        }

        public class OptionReadDto
        {

        public Guid OptionId { get; set; }
        public string Choice { get; set; } 
        public bool IsCorrect { get; set; } 
        public Guid? QuizId { get; set; } 

        }

        public class OptionUpdateDto
        {
        public string Choice { get; set; } 
        public bool IsCorrect { get; set; } 

        }
    }
}