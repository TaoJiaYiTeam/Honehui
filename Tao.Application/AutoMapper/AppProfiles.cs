using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Tao.Domain;
using Tao.Facade;

namespace Tao.Application
{
    public class AppProfiles:Profile
    {
        public AppProfiles()
        {
            CreateMap<Daily, DailyVm>().ReverseMap();
            CreateMap<User, UserVm>().ReverseMap();
            CreateMap<Role, RoleVm>().ReverseMap();
            CreateMap<Menu, MenuVm>().ReverseMap();
            CreateMap<DailyVm, Daily>().ReverseMap();
            CreateMap<DailyMission, DailyMissionVm>().ReverseMap();
            CreateMap<DailySearch, DailySearchVm>().ReverseMap();

            CreateMap<UserSearch, UserSearchVm>().ReverseMap();
        }
    }
}
