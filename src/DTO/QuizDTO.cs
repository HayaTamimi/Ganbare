using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ganbare.src.DTO
{
    public class QuizDTO
    {

        public class QuizCreateDto
        {
            public int Result { get; set; }
            public float Duration { get; set; }


        }
        public class QuizReadDto
        {
            public Guid QuizId { get; set; }
            public int Result { get; set; }
            public float Duration { get; set; }

        }

        public class QuizUpdateDto
        {
            public Guid QuizId { get; set; }
            public int Result { get; set; }
            public float Duration { get; set; }

        }
    }
}