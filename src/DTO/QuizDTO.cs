using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ganbare.src.Entity;

namespace ganbare.src.DTO
{
    public class QuizDTO
    {
        public class QuizCreateDto
        {
            // when quiz is created, it's need the details of the 
            // questions and users otherwise it can't happen

            // [Required]
            // public List<Question> Question { get; set; }
      
            //public int? QuizScore { get; set; } // maybe add it later?

           // public Result Result { get; set; } // // maybe add it later?

        }
        public class QuizReadDto
        {
            public Guid QuizId { get; set; }
            public int? QuizScore { get; set; }
           public float TimeTaken { get; set; }
            public List<Question> Questions { get; set; }
            public QuizLevel Level { get; set; }
            public Guid? UserId { get; set; }
            public Guid? ResultId { get; set; }

        }

        /*
                public class QuizUpdateDto
                {
                    // nothing need to be updated
                    //public Guid QuizId { get; set; }
                }*/
    }
}