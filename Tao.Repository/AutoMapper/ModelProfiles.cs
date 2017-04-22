using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Tao.Domain;

namespace Tao.Repository
{
    public class ModelProfiles : Profile
    {
        public ModelProfiles()
        {
            CreateMap<DailyModel, Daily>().ReverseMap();
            CreateMap<UserModel, User>().ReverseMap();
            CreateMap<RUserRoleModel, RUserRole>().ReverseMap();
            CreateMap<RoleModel, Role>().ReverseMap();
            CreateMap<DailyMissionModel, DailyMission>().ReverseMap();
            CreateMap<DailyModel, Daily>().ReverseMap();

            CreateMap<RRoleMenuModel, RRoleMenu>().ReverseMap();
            CreateMap<MenuModel, Menu>().ReverseMap();

            CreateMap<RTeaStuModel, RTeaStu>().ReverseMap();
        }
    }
}
