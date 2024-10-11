using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ganbare.src.Entity;
using static ganbare.src.DTO.LeaderboardDTO;
using static ganbare.src.DTO.QuestionDTO;
using static ganbare.src.DTO.QuizDTO;
using static ganbare.src.DTO.ResultDTO;
using static ganbare.src.DTO.UserDTO;

namespace ganbare.src.Utils
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            CreateMap<Leaderboard, LeaderboardReadDto>();
            CreateMap<LeaderboardCreateDto, Leaderboard>();
            CreateMap<LeaderboardUpdateDto, Leaderboard>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcProperty) => srcProperty != null)
                );

            CreateMap<Question, QuestionReadDto>();
            CreateMap<QuestionCreateDto, Question>();
            CreateMap<QuestionUpdateDto, Question>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcProperty) => srcProperty != null)
                );

            CreateMap<Quiz, QuizReadDto>();
            CreateMap<QuizCreateDto, Quiz>();
            CreateMap<QuizUpdateDto, Quiz>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcProperty) => srcProperty != null)
                );

            CreateMap<Result, ResultReadDto>();
            CreateMap<ResultCreateDto, Result>();
            CreateMap<ResultUpdateDto, Result>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcProperty) => srcProperty != null)
                );

            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcProperty) => srcProperty != null)
                );

        }
    }
}