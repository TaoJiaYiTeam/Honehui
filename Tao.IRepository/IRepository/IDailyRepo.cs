using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.Domain;

namespace Tao.IRepository
{
    public interface IDailyRepo : IBaseRepository<Daily>
    {
        IEnumerable<Daily> GetList(DailySearch search, out int total);
    }
}
