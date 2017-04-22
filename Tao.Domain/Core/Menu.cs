using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.Infrastructure;

namespace Tao.Domain
{
    public class Menu:IAggregateRoot
    {
        public string RowGuid { get;private set; }
        public string Name { get; private set; }
        public string Url { get; private set; }
        public int IsDel { get; private set; }
        protected Menu() {

        }
        public static Menu CreateNew(string name,
            string url)
        {
            var menu = new Menu()
            {
                RowGuid = UniqueKeyGenerator.CreateNewKey(),
                Name=name,
                Url=url,
                IsDel=0
            };
            return menu;
        }
    }
}
