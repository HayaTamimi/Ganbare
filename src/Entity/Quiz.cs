using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ganbare.src.Entity
{
    public class Quiz
    {
        [Key]
        public Guid QuizId { get; set; }
        public int? Score { get; set; } = 0;
        public float? Duration { get; set; } 
        //public List<User>? Users { get; set; }
        public List<Question>? Questions { get; set; }
        public Guid? UserId { get; set; }
        public Guid? QuestionId { get; set; }

    }
}