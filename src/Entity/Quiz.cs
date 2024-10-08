using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ganbare.src.Entity
{
    public class Quiz
    {
        public Guid QuizId { get; set; }
        public int Result { get; set; }
        public float Duration { get; set; }
        public Guid? UserId { get; set; }

    }
}