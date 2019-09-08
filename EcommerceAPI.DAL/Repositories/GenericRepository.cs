using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EcommerceAPI.DAL.Context;
using EcommerceAPI.DAL.Interfaces;
namespace EcommerceAPI.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        MyDbContext _context = null;
        private DbSet<T> table = null;
        string errormessage = string.Empty;
        public GenericRepository()
        {
            this._context = new MyDbContext();
            table = _context.Set<T>();

        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public IEnumerable<T> SelectAll() {
            return table.ToList();
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate) {
            if (predicate == null)
            {
                return table.ToList();
            }
            else
            {
                return table.Where(predicate).ToList();
            }

        }

        public  T FindOneRecord(Expression<Func<T, bool>> predicate)
        {
            if (predicate == null)
            {
                return null;
            }
            else
            {
                return table.Where(predicate).FirstOrDefault();
            }

        }


        public ICollection<T> ExecuteQuery(string sqlQuery, CommandType commandType, SqlParameter[] parameters)
        {
            if (commandType == CommandType.Text)
            {
                return SqlQuery(sqlQuery, parameters);
            }
            else if (commandType == CommandType.StoredProcedure)
            {
                return StoredProcedure(sqlQuery, parameters);
            }
            return null;
        }

        public void Save(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this.table.Add(entity);
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errormessage += string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }
                throw new Exception(errormessage, dbEx);
            }

        }

        public T SaveReturnId(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this.table.Add(entity);
                this._context.SaveChanges();
                return entity;
            }
            catch (DbEntityValidationException dbEx)
            {

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errormessage += string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }
                throw new Exception(errormessage, dbEx);
            }

        }

        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                 
                }
                else
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                this._context.SaveChanges();
            }
            catch (Exception ex)
            {

            }

        }

        private ICollection<T> SqlQuery(string sqlQuery, SqlParameter[] parameters = null)
        {
            if (parameters != null && parameters.Any())
            {
                var parameterNames = new string[parameters.Length];
                for (int i = 0; i < parameters.Length; i++)
                {
                    parameterNames[i] = parameters[i].ParameterName;
                }
                var result = _context.Database.SqlQuery<T>(string.Format("{0}", sqlQuery, string.Join(",", parameterNames), parameters));
                return result.ToList();

            }
            else
            {
                var result = _context.Database.SqlQuery<T>(sqlQuery);
                return result.ToList();
            }
        }
        private ICollection<T> StoredProcedure(string storedProcedureName, SqlParameter[] parameters = null)
        {
            if (parameters != null && parameters.Any())
            {
                var parameterNames = new string[parameters.Length];
                string parametersList = "EXEC " + storedProcedureName;
                for (int i = 0; i < parameters.Length; i++)
                {
                    parameterNames[i] = parameters[i].ParameterName;
                    if (i == 0)
                    {
                        parametersList += " " + parameters[i].ParameterName + "=" + parameters[i].Value;
                        //parametersList = parameters[i].ParameterName +   
                    }
                    else
                    {
                        parametersList += "," + parameters[i].ParameterName + "=" + parameters[i].Value;
                    }
                }
                //var result = _context.Database.SqlQuery<T>(string.Format("EXEC {0} {1}", storedProcedureName, string.Join(",", parameterNames), parameters));
                var result = _context.Database.SqlQuery<T>(parametersList);
                return result.ToList();
            }
            else
            {
                var result = _context.Database.SqlQuery<T>(string.Format("EXEC {0}", storedProcedureName));
                return result.ToList();
            }
        }

    }
}
