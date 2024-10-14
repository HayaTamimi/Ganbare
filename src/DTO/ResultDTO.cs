using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ganbare.src.DTO
{
    public class ResultDTO
    {
        public class ResultCreateDto
        {
            public double? TotalScore { get; set; }

            public double? Speed { get; set; }

            public Guid? UserId { get; set; }

        }
        public class ResultReadDto
        {
            public Guid ResultId { get; set; }
            public double TotalScore { get; set; }

            public double Speed { get; set; }

            public Guid? UserId { get; set; }
            //public Guid? LeaderboardId { get; set; }

        }

      /*  public class ResultUpdateDto
        {

            // nothing need to be updated

        }*/
    }
}