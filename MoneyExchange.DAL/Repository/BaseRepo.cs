using Microsoft.EntityFrameworkCore;
using MoneyExchange.DAL.Repository.Templates;
using MoneyExchange.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyExchange.DAL.Repository
{
    public abstract class BaseRepo<T> : IRepo<T> where T : EntityBase, new()
    {
        protected readonly DbSet<T> _table;
        private readonly ExchangeContext _db;
        protected ExchangeContext Context => _db;
        public BaseRepo()
        {
            _db = new ExchangeContext();
            _table = _db.Set<T>();
        }
        public int Add(T entity)
        {
            _table.AddAsync(entity);
            return SaveChanges();
        }

        public void Dispose()
        {
            _db?.Dispose();
        }

        public virtual List<T> GetAll()// => _table.ToList();
        {
            return _table.ToList();
        }

        internal int SaveChanges()
        {
            try
            {
                return _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                //Thrown when there is a concurrency error
                //for now, just rethrow the exception
                throw;
            }
            catch (DbUpdateException ex)
            {
                //Thrown when database update fails
                //Examine the inner exception(s) for additional 
                //details and affected objects
                //for now, just rethrow the exception
                throw;
            }
            catch (Exception ex)
            {
                //some other exception happened and should be handled
                throw;
            }
        }
    }
}
