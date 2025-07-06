using AutoMapper;
using FootballLeague.BLL.DTOs;
using FootballLeague.BLL.DTOs.Match;
using FootballLeague.BLL.DTOs.MatchGoal;
using FootballLeague.BLL.DTOs.Player;
using FootballLeague.BLL.DTOs.Stadium;
using FootballLeague.BLL.DTOs.Team;
using FootballLeague.DAL.Entities;

namespace FootballLeague.BLL.Profiles
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<Player, PlayerDTO>().ReverseMap();
            CreateMap<PlayerCreateDTO, Player>().ReverseMap();
            CreateMap<Team, TeamDTO>().ReverseMap();
            CreateMap<TeamCreateDTO, Team>().ReverseMap();
            CreateMap<Stadium, StadiumDTO>().ReverseMap();
            CreateMap<StadiumCreateDTO, Stadium>().ReverseMap();

            CreateMap<Match, MatchDTO>().ReverseMap();
            CreateMap<MatchCreateDTO, Match>().ReverseMap();
            CreateMap<CreateMatchGoalDTO, MatchGoal>().ReverseMap();
            CreateMap<MatchGoal, MatchGoalDTO>().ReverseMap();
        }
    }
}
