using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Tao.Repository
{
    [Table("R_Role_Menu")]
    public class RRoleMenuModel
    {
        [Key]
        public string RowGuid { get; set; }
        public string RoleGuid { get; set; }
        public string MenuGuid { get; set; }
        public int IsDel { get; set; }

    }
}
