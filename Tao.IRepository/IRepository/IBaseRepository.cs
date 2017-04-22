using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.Domain;

namespace Tao.IRepository
{
    public interface IBaseRepository<TAggregate>
       where TAggregate : IAggregateRoot
    {
        bool Insert(TAggregate entity);
        bool Update(TAggregate entity);
        bool Delete(TAggregate entity);
        bool DeleteByGuid(object key);
        IEnumerable<TAggregate> FindAll(string wheresql = "", object obj = null);
        IEnumerable<TAggregate> FindAll(object whereObj);

        TAggregate FindOne(object key);
    }
}
