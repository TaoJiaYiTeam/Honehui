using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.Domain;

namespace Tao.IRepository
{
    public interface IUserRepo : IBaseRepository<User>
    {
        IEnumerable<User> GetList(UserSearch search, out int total);
    }
}
