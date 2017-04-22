using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Tao.Repository
{
    [Table("Menu")]
    public class MenuModel
    {
        [Key]
        public string RowGuid { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int IsDel { get; set; }

    }
}
