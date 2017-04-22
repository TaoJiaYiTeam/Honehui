using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Tao.IRepository;
using Tao.Domain;
using Tao.Infrastructure;
using AutoMapper;

namespace Tao.Repository
{
    public class BaseRepository<TAggregate, TModel> : IBaseRepository<TAggregate>
        where TAggregate : IAggregateRoot
        where TModel : class
    {

        #region 私有变量
        private string _tableName
        {
            get
            {
                return getTableName();
            }
        }
        private string _keyName
        {
            get
            {
                return getKey();
            }
        }
        #endregion

        public string TableName
        {
            get { return _tableName; }
        }

        public string KeyName
        {
            get { return _keyName; }
        }

        public bool Delete(TAggregate entity)
        {
            using (var conn = DbClient.GetConnection())
            {
                var model = Mapper.Map<TModel>(entity);
                //string sql = string.Format("delete from {0} where {1} = @{1}", _tableName, _keyName);
                var result=conn.Delete(model);
                //var result = conn.Execute(sql, model);
                return result >= 1 ? true : false;
            }
        }

        public bool DeleteByGuid(object key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregate> FindAll(string wheresql = "", object obj = null)
        {
            using (var conn = DbClient.GetConnection())
            {
                var result = Mapper.Map<IEnumerable<TAggregate>>(conn.GetList<TModel>(wheresql, obj));
                return result;
            }
        }

        public IEnumerable<TAggregate> FindAll(object whereObj)
        {
            using (var conn = DbClient.GetConnection())
            {
                var result = Mapper.Map<IEnumerable<TAggregate>>(conn.GetList<TModel>(whereObj));
                return result;
            }
        }

        public TAggregate FindOne(object key)
        {
            using (var conn = DbClient.GetConnection())
            {
                var result = Mapper.Map<TAggregate>(conn.GetList<TModel>(key).FirstOrDefault());
                return result;
            }
        }

        public bool Insert(TAggregate entity)
        {
            using (var conn = DbClient.GetConnection())
            {
                var model = Mapper.Map<TModel>(entity);
                var result = conn.Insert(model);

                return result > 0 ? true : false;
            }
        }

        public bool Update(TAggregate entity)
        {
            using (var conn = DbClient.GetConnection())
            {
                var model = Mapper.Map<TModel>(entity);
                var result = conn.Update(model);
                return result > 0 ? true : false;
            }
        }


        #region 私有变量
        private string getTableName()
        {
            var customAttrs = typeof(TModel).GetCustomAttributes(true);
            foreach (var obj in customAttrs)
            {
                TableAttribute table = obj as TableAttribute;
                if (table != null)
                {
                    return table.Name;
                }
            }
            return typeof(TModel).Name;
        }
        private string getKey()
        {
            var props = typeof(TModel).GetProperties();
            if (!props.Any(o => o.GetCustomAttributes(true).Any(attr => attr.GetType() == typeof(KeyAttribute))))
                throw new ArgumentException("实体至少有一个[Key]");
            var keyprop = props.Where(o => o.GetCustomAttributes(true).Any(attr => attr.GetType() == typeof(KeyAttribute))).First();
            return keyprop.Name;
        }
        #endregion
    }
}
