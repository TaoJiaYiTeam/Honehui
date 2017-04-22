using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Tao.Repository
{
    [Table("R_Tea_Stu")]
    public class RTeaStuModel
    {
        [Key]
        public string RowGuid { get; set; }
        public string TeacherGuid { get; set; }
        public string StudentGuid { get; set; }
        public int IsDel { get; set; }

    }
}
