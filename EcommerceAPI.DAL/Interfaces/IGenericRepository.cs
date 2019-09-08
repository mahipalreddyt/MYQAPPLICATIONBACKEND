using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.DAL.Interfaces
{
    public interface IGenericRepository <T> where T : class
    {
        IEnumerable<T> SelectAll();
        IEnumerable<T> Find(Expression<Func<T, bool>>  predicate);
        ICollection<T> ExecuteQuery(string sqlQuery, CommandType commandType, SqlParameter[] parameters);
        T GetById(object id);
        void Save(T entity);
        void Update(T entity);
        T FindOneRecord(Expression<Func<T, bool>> predicate);
        T SaveReturnId(T entity);

    }
}
