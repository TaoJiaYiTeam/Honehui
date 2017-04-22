using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.Domain;
using Tao.IRepository;

namespace Tao.Repository
{
    public class MenuRepo : BaseRepository<Menu, MenuModel>, IMenuRepo
    {

    }
}
