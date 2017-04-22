using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tao.Facade
{
    public class UserVm
    {
        public string RowGuid { get; set; }
        public string UserName { get; set; }
        public string LogonNo { get; set; }
        public string PassWord { get; set; }
        public string RoleGuid { get; set; }
        public string RoleName { get; set; }
    }
}