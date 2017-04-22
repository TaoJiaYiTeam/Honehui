using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tao.Infrastructure
{
    public static class UniqueKeyGenerator
    {
        public static string  CreateNewKey()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
