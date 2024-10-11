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
            public Question Question { get; set; }
            public Guid? QuestionId { get; set; }

            public User User { get; set; }

        }
        public class QuizReadDto
        {
            [Key]
            public Guid QuizId { get; set; }
            public int? Score { get; set; }
            public float? Duration { get; set; }
            //public List<User>? Users { get; set; }
            public List<Question>? Questions { get; set; }
            public Guid? UserId { get; set; }
            public Guid? QuestionId { get; set; }

        }

        public class QuizUpdateDto
        {
            // nothing need to be updated

            //public Guid QuizId { get; set; }

        }
    }
}