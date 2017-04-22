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
    public class AdminApp
    {
        private IUserRepo _userRepo;
        private IRUserRoleRepo _ruserroleRepo;
        private IRoleRepo _roleRepo;
        private IRTeaStuRepo _rteastuRepo;

        public AdminApp(IUserRepo userRepo, 
            IRUserRoleRepo ruserroleRepo, 
            IRoleRepo roleRepo,
            IRTeaStuRepo rteastuRepo)
        {
            _userRepo = userRepo;
            _ruserroleRepo = ruserroleRepo;
            _roleRepo = roleRepo;
            _rteastuRepo = rteastuRepo;

        }

        public IEnumerable<UserVm> GetTeachers()
        {
            var role=_roleRepo.FindOne(new { Type=2,IsDel=0});
            if (null == role)
            {
                return null;
            }
            var relation=_ruserroleRepo.FindAll(new {RoleGuid=role.RowGuid,IsDel=0 });
            if (null == relation)
            {
                return null;
            }

            var result=_userRepo.FindAll(" where RowGuid in @UserGuid and IsDel=0 ", new { UserGuid = relation.Select(o => o.UserGuid) });

            return Mapper.Map<IEnumerable<UserVm>>(result);
        }
        public IEnumerable<UserVm> GetStudents()
        {
            var role = _roleRepo.FindOne(new { Type = 1, IsDel = 0 });
            if (null == role)
            {
                return null;
            }
            var relation = _ruserroleRepo.FindAll(new { RoleGuid = role.RowGuid, IsDel = 0 });
            if (null == relation)
            {
                return null;
            }

            var result = _userRepo.FindAll(" where RowGuid in @UserGuid and IsDel=0 ", new { UserGuid = relation.Select(o => o.UserGuid) });

            return Mapper.Map<IEnumerable<UserVm>>(result);
        }

        public bool InsertToTeacher(string teaGuid, string stuGuid)
        {
            if (IsHaveTeacher(stuGuid))
            {
                return false;
            }

            var relation = RTeaStu.CreateNew(teaGuid, stuGuid);
            return _rteastuRepo.Insert(relation);
        }
        public bool DeleteToTeacher(string stuGuid)
        {
            var relation = _rteastuRepo.FindOne(new { StudentGuid = stuGuid, IsDel = 0 });
            if (null == relation)
            {
                return false;
            }
            relation.Delete();
            return _rteastuRepo.Update(relation);
        }
        public bool IsHaveTeacher(string StuGuid)
        {
            var stu = _rteastuRepo.FindOne(new { StudentGuid = StuGuid, IsDel = 0 });
            return (stu != null);
        }
        public IEnumerable<UserVm> GetAllStuByTeacher(string teaGuid)
        {
            var relation=_rteastuRepo.FindAll(new { TeacherGuid = teaGuid, IsDel = 0 });
            if (null==relation || !relation.Any())
            {
                return new List<UserVm>();
            }
            var result= _userRepo.FindAll(" where RowGuid in @UserGuid ", new { UserGuid = relation.Select(o => o.StudentGuid) });

            return Mapper.Map<IEnumerable<UserVm>>(result);
        }



        public IEnumerable<UserVm> GetUserList(UserSearchVm search,out int total)
        {
            
            var users=_userRepo.GetList(Mapper.Map<UserSearch>(search), out total);
            var userVms = Mapper.Map<IEnumerable<UserVm>>(users);
            foreach (var item in userVms)
            {
                var roleGuid=_ruserroleRepo.FindOne(new { UserGuid = item.RowGuid, IsDel = 0 }).RoleGuid;
                var role = _roleRepo.FindOne(new { RowGuid = roleGuid ,IsDel=0});
                item.RoleName = role.Name;
                item.RoleGuid = role.RowGuid;
            }
            return userVms;
        }

        public bool InsertUser(UserVm vm)
        {
            var validUser=_userRepo.FindOne(new { LogonNo = vm.LogonNo, IsDel = 0 });
            if (validUser != null)
            {
                return false;
            }

            var user = User.CreateNew(vm.UserName, vm.LogonNo, vm.PassWord);
            var flag = _userRepo.Insert(user);
            var relation = RUserRole.CreateNew(user.RowGuid, vm.RoleGuid);
            flag = _ruserroleRepo.Insert(relation);
            return flag;
        }
        public bool DeleteUser(UserVm vm)
        {
            var user = _userRepo.FindOne(new { RowGuid = vm.RowGuid });
            user.Delete();
            var flag = _userRepo.Update(user);
            return flag;
        }
        public IEnumerable<RoleVm> GetRoles()
        {
            var roles = _roleRepo.FindAll(new { IsDel = 0 });
            return Mapper.Map<IEnumerable<RoleVm>>(roles);
        }
    }
}
