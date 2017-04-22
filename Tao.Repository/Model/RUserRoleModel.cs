using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Tao.Repository
{
    [Table("R_User_Role")]
    public class RUserRoleModel
    {
        [Key]
        public string RowGuid { get; set; }
        public string UserGuid{ get; set; }
        public string RoleGuid { get; set; }
        public int IsDel { get; set; }

    }
}
