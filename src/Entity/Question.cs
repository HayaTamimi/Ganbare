using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ganbare.src.Entity
{
    public class Question // 10 Questions in each Quiz
    {
        public Guid QuestionID { get; set; }
        public string JpQuestion { get; set; }
        public List<Question>? Questions { get; set; }
        public Guid? QuizId { get; set; }

        public Level Jplevel { get; set; }

        public enum Level
        {
            N5,
            N4,
            N3,
            N2,
            N1
        }

    }
}