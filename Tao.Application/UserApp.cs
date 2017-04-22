using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.Facade;
using Tao.IRepository;
using AutoMapper;
using Tao.Domain;

namespace Tao.Application
{
    public class UserApp
    {
        private IUserRepo _userRepo;
        private IRUserRoleRepo _ruserroleRepo;
        private IRoleRepo _roleRepo;
        private IMenuRepo _menuRepo;
        private IRRoleMenuRepo _rrolemenuRepo;
        public UserApp(IUserRepo userRepo, 
            IRUserRoleRepo ruserroleRepo, 
            IRoleRepo roleRepo,
            IMenuRepo menuRepo,
            IRRoleMenuRepo rrolemenuRepo)
        {
            _userRepo = userRepo;
            _ruserroleRepo = ruserroleRepo;
            _roleRepo = roleRepo;

            _menuRepo = menuRepo;
            _rrolemenuRepo = rrolemenuRepo;
        }
        public bool isCanLogon(string UserNo, string Password, out UserVm userVm, out RoleVm roleVm,out IEnumerable<MenuVm> menus)
        {
            userVm = null;
            roleVm = null;
            menus = null;
            var user = _userRepo.FindOne(new { LogonNo = UserNo, Password = Password ,IsDel=0});
            if (null != user)
            {
                userVm = Mapper.Map<UserVm>(user);
                roleVm = GetRoleByUser(userVm);
                menus = GetMenuByRole(roleVm);
                return true;
            }
            return false;
        }
        public RoleVm GetRoleByUser(UserVm user)
        {
            var relation = _ruserroleRepo.FindOne(new { UserGuid = user.RowGuid });
            if (null == relation)
            {
                return null;
            }
            var role = _roleRepo.FindOne(new { RowGuid= relation .RoleGuid});
            return Mapper.Map<RoleVm>(role);
        }
        public IEnumerable<MenuVm> GetMenuByRole(RoleVm role)
        {
            var relation = _rrolemenuRepo.FindAll(new { RoleGuid = role.RowGuid });
            if (null == relation)
            {
                return null;
            }
            var menu = _menuRepo.FindAll("where RowGuid in @RowGuid",new { RowGuid = relation.Select(o=>o.MenuGuid) });
            return Mapper.Map<IEnumerable<MenuVm>>(menu);
        }
    }
}
