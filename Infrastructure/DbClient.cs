using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.Odbc;
using MySql.Data.MySqlClient;
using DBManager;

namespace Tao.Infrastructure
{
    public class DbClient
    {
        private string _dbName;
        private const string _conStr = DBManager.DBManager.connectStr;

        public static IDbConnection GetConnection()
        {

            try
            {
                var connection = new MySqlConnection(_conStr);
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                return connection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DbClient(string dbName)
        {
            if (string.IsNullOrEmpty(dbName))
                throw new ArgumentNullException(nameof(dbName));
            _dbName = dbName;
        }
        public IEnumerable<T> Query<T>(string sql, object param = null, bool isWrite = false) where T : class
        {
            if (string.IsNullOrEmpty(sql))
            {
                throw new ArgumentNullException(nameof(sql));
            }
            using (IDbConnection con = GetConnection())
            {
                IEnumerable<T> tList = con.Query<T>(sql, param);
                con.Close();
                return tList;
            }
        }
        public int Update<T>(T t)
        {
            using (IDbConnection con = GetConnection())
            {
                return con.Update(t);
            }

        }

        public int Excute(string sql, object param = null, IDbTransaction transaction = null)
        {
            if (string.IsNullOrEmpty(sql))
            {
                throw new ArgumentNullException(nameof(sql));
            }
            using (IDbConnection con = GetConnection())
            {
                return con.Execute(sql, param, transaction);
            }
        }

        public int Insert<T>(T t)
        {
            using (IDbConnection con = GetConnection())
            {
                return con.Insert<long>(t);
            }
        }

        public T ExecuteScalar<T>(string sql, object param = null, bool isWrite = false)
        {
            if (string.IsNullOrEmpty(sql))
            {
                throw new ArgumentNullException(nameof(sql));
            }
            using (IDbConnection con = GetConnection())
            {
                return con.ExecuteScalar<T>(sql, param);
            }
        }

        public T QueryScalar<T>(string sql, object parameters = null, bool isWriteDatabase = false) where T : struct
        {
            if (string.IsNullOrWhiteSpace(sql))
            {
                throw new ArgumentNullException("sql");
            }

            IDbConnection conn = null;
            try
            {
                using (conn = GetConnection())
                {
                    return conn.Query<T>(sql, parameters).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}
