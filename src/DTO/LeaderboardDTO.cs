using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ganbare.src.Entity;

namespace ganbare.src.DTO
{
    public class LeaderboardDTO
    {
        public class LeaderboardCreateDto
        {
            public List<Result>? Results { get; set; }

        }
        public class LeaderboardReadDto
        {
            public Guid LeaderboardId { get; set; }

            public List<Result> Results { get; set; }

        }

        public class LeaderboardUpdateDto
        {

            public List<Result> Results { get; set; }

        }
    }
}