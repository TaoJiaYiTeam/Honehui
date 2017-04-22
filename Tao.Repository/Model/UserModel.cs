using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Tao.Repository
{
    [Table("User")]
    public class UserModel
    {
        [Key]
        public string RowGuid { get; set; }
        public string UserName { get; set; }
        public string LogonNo { get; set; }
        public string Password { get; set; }
        public int IsDel { get; set; }

    }
}
